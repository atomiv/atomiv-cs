﻿using Atomiv.Infrastructure.CsvHelper;
using Atomiv.Test.Xunit;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Dtos.Customers.Exports;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fake.Models;
using Atomiv.Web.AspNetCore.RestApi.IntegrationTest.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Atomiv.Web.AspNetCore.RestApi.IntegrationTest
{
    public class CustomersControllerTest : FixtureTest<TestClient>
    {
        public CustomersControllerTest(TestClient client)
            : base(client)
        {
        }

        [Fact(Skip = "Fails on server, need to re-check")]
        public async Task TestGetAllAsync()
        {
            var expected = new CustomerGetAllResponse
            {
                Records = new List<CustomerGetAllRecordResponse>
                {
                    new CustomerGetAllRecordResponse
                    {
                        Id = 1,
                        UserName = "jsmith",
                        FirstName = "John",
                        LastName = "Smith",
                        CreatedDateTime = new DateTime(2019, 1, 1, 8, 20, 36),
                        ModifiedDateTime = new DateTime(2019, 1, 2, 9, 30, 42),
                    },

                    new CustomerGetAllRecordResponse
                    {
                        Id = 2,
                        UserName = "mcdonald",
                        FirstName = "Mary",
                        LastName = "McDonald",
                        CreatedDateTime = new DateTime(2018, 7, 4, 14, 40, 12),
                        ModifiedDateTime = new DateTime(2018, 9, 8, 18, 50, 18),
                    }
                }
            };

            var actual = await Fixture.Customers.GetAllAsync();

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            AssertUtilities.Equal(expected, actual.Data);
        }

        [Fact(Skip = "Fails on server, need to re-check")]
        public async Task TestGetExportsCsvAsync()
        {
            var csvSerializationService = new CsvSerializer();

            var expectedDtos = new List<CustomerExportGetCollectionResponse>
            {
                new CustomerExportGetCollectionResponse
                {
                    Id = 1,
                    UserName = "jsmith",
                    FirstName = "John",
                    LastName = "Smith",
                },

                new CustomerExportGetCollectionResponse
                {
                    Id = 2,
                    UserName = "mcdonald",
                    FirstName = "Mary",
                    LastName = "McDonald",
                }
            };

            var expected = csvSerializationService.Serialize(expectedDtos);

            var actual = await Fixture.Customers.GetCsvExportsAsync();

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);

            AssertUtilities.Equal(expected, actual.ContentString);
        }

        [Fact(Skip = "Sometimes fails locally, need to re-check")]
        public async Task TestImportPostCsvAsync()
        {
            var csvSerializationService = new CsvSerializer();

            var request = new List<CustomerImportCollectionPostRequest>
            {
                new CustomerImportCollectionPostRequest
                {
                    UserName = "jsmith2",
                    FirstName = "John2",
                    LastName = "Smith2",
                },

                new CustomerImportCollectionPostRequest
                {
                    UserName = "mmcdonald2",
                    FirstName = "Mary2",
                    LastName = "McDonald2",
                }
            };

            var serialized = csvSerializationService.Serialize(request);

            var result = await Fixture.Customers.PostImportsAsync(serialized);

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);

            var retrieved = await Fixture.Customers.GetAllAsync();

            Assert.Equal(HttpStatusCode.OK, retrieved.StatusCode);

            Assert.Equal(4, retrieved.Data.Records.Count());

            // TODO: VC: Handle later

            /*
            var actualDtos = csvSerializationService.Deserialize<List<CustomerDto>>(result);

            AssertUtilities.AssertEqual(expectedDtos, actualDtos);
            */
        }

        [Fact]
        public async Task TestPostAsyncValid()
        {
            var request = new CustomerPostRequest
            {
                UserName = "jsmith3",
                FirstName = "John3",
                LastName = "Smith3",
            };

            var result = await Fixture.Customers.PostAsync(request);

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);

            var resultContent = result.Data;

            Assert.Equal(request.UserName, resultContent.UserName);
            Assert.Equal(request.FirstName, resultContent.FirstName);
            Assert.Equal(request.LastName, resultContent.LastName);
            Assert.True(resultContent.Id > 0);
        }

        [Fact]
        public async Task TestPostAsyncInvalid()
        {
            var request = new CustomerPostRequest
            {
                UserName = null,
                FirstName = null,
                LastName = null,
            };

            var response = await Fixture.Customers.PostAsync(request);

            Assert.Equal(HttpStatusCode.UnprocessableEntity, response.StatusCode);

            var problemDetails = response.ProblemDetails;

            Assert.NotNull(problemDetails);

            // TODO: VC: Supporting different custom problem details which do not conform to the standard

            Assert.Equal((int)HttpStatusCode.UnprocessableEntity, problemDetails.Status);
        }
    }
}
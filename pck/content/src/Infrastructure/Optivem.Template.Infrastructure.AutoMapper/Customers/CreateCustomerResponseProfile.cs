﻿using AutoMapper;
using Optivem.Framework.Infrastructure.AutoMapper;
using Optivem.Template.Core.Application.Customers.Responses;
using Optivem.Template.Core.Domain.Customers.Entities;

namespace Optivem.Template.Infrastructure.AutoMapper.Customers
{
    public class CreateCustomerResponseProfile : ResponseProfile<Customer, CreateCustomerResponse>
    {
        protected override void Extend(IMappingExpression<Customer, CreateCustomerResponse> map)
        {
            // TODO: VC: Separate mappings just for ids
            map.ForMember(dest => dest.Id, opt => opt.MapFrom(e => e.Id.Id));
        }
    }
}
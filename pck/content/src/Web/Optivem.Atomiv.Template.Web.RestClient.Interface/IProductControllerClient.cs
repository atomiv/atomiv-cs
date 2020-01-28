﻿using Optivem.Atomiv.Core.Common.Http;
using Optivem.Atomiv.Template.Core.Application.Products.Commands;
using Optivem.Atomiv.Template.Core.Application.Products.Queries;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Web.RestClient.Interface
{
    public interface IProductControllerClient : IHttpControllerClient
    {
        Task<IObjectClientResponse<BrowseProductsQueryResponse>> BrowseProductsAsync(BrowseProductsQuery request);

        Task<IObjectClientResponse<CreateProductCommandResponse>> CreateProductAsync(CreateProductCommand request);

        Task<IObjectClientResponse<FindProductQueryResponse>> FindProductAsync(FindProductQuery request);

        Task<IObjectClientResponse<ListProductsQueryResponse>> ListProductsAsync(ListProductsQuery request);

        Task<IObjectClientResponse<RelistProductCommandResponse>> RelistProductAsync(RelistProductCommand request);

        Task<IObjectClientResponse<UnlistProductCommandResponse>> UnlistProductAsync(UnlistProductCommand request);

        Task<IObjectClientResponse<UpdateProductCommandResponse>> UpdateProductAsync(UpdateProductCommand request);
    }
}
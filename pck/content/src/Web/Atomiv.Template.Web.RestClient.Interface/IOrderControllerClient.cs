﻿using Atomiv.Core.Common.Http;
using Atomiv.Template.Core.Application.Commands.Orders;
using Atomiv.Template.Core.Application.Queries.Orders;
using System.Threading.Tasks;

namespace Atomiv.Template.Web.RestClient.Interface
{
    public interface IOrderControllerClient : IHttpControllerClient
    {
        #region Commands

        Task<ObjectClientResponse<CancelOrderCommandResponse>> CancelOrderAsync(CancelOrderCommand request, HeaderData header);

        Task<ObjectClientResponse<CreateOrderCommandResponse>> CreateOrderAsync(CreateOrderCommand request, HeaderData header);

        Task<ObjectClientResponse<EditOrderCommandResponse>> EditOrderAsync(EditOrderCommand request, HeaderData header);

        Task<ObjectClientResponse<SubmitOrderCommandResponse>> SubmitOrderAsync(SubmitOrderCommand request, HeaderData header);

        #endregion

        #region Queries

        Task<ObjectClientResponse<BrowseOrdersQueryResponse>> BrowseOrdersAsync(BrowseOrdersQuery request, HeaderData header);

        Task<ObjectClientResponse<FilterOrdersQueryResponse>> FilterOrdersAsync(FilterOrdersQuery request, HeaderData header);

        Task<ObjectClientResponse<ViewOrderQueryResponse>> ViewOrderAsync(ViewOrderQuery request, HeaderData header);

        #endregion
    }
}

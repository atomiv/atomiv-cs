﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Platform.Core.Common.RestClient
{
    public interface IRestControllerClient<TId,
        TGetCollectionResponse, 
        TGetResponse,
        TPostRequest, TPostResponse,
        TPutRequest, TPutResponse,
        TPatchRequest, TPatchResponse>
        : IDisposable
    {
        Task<IEnumerable<TGetCollectionResponse>> GetCollectionAsync();

        Task<string> GetAsync(string uri, string acceptType);

        Task<TGetResponse> GetAsync(TId id);
        
        Task<TPostResponse> PostAsync(TPostRequest request);

        Task<string> PostAsync(string uri, string request, string contentType);

        Task<TPutResponse> PutAsync(TId id, TPutRequest request);

        Task PutCollectionAsync(string request, string contentType);

        Task<TPatchResponse> PatchAsync(TId id, TPatchRequest request);

        Task PatchCollectionAsync(string request, string contentType);

        Task DeleteAsync(TId id);
    }

    public interface IRestControllerClient<TId,
        TGetCollectionResponse, 
        TGetResponse,
        TPostRequest, TPostResponse,
        TPutRequest, TPutResponse>
        : IRestControllerClient<TId,
            TGetCollectionResponse, 
            TGetResponse,
            TPostRequest, TPostResponse,
            TPutRequest, TPutResponse,
            TPutRequest, TPutResponse>
    {

    }

    public interface IRestControllerClient<TId, TRequest, TResponse>
        : IRestControllerClient<TId, 
            TResponse, 
            TResponse,
            TRequest, TResponse,
            TRequest, TResponse,
            TRequest, TResponse>
    {

    }

    public interface IRestControllerClient<TId, TDto>
        : IRestControllerClient<TId, TDto, TDto>
    {

    }
}
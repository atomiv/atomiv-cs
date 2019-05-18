﻿using Optivem.Common.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Http.System
{
    public class BaseControllerClient
    {
        private BaseControllerClient(IControllerClient client)
        {
            Client = client;
        }

        public BaseControllerClient(IControllerClientFactory clientFactory, string controllerUri)
            : this(clientFactory.Create(controllerUri)) { }

        public IControllerClient Client { get; private set; }
    }
}
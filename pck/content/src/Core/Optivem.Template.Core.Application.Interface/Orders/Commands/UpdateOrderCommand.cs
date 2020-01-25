﻿using Optivem.Framework.Core.Application;
using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<UpdateOrderCommandResponse>
    {
        public Guid Id { get; set; }

        public List<UpdateOrderItemCommand> OrderItems { get; set; }
    }

    public class UpdateOrderItemCommand
    {
        public Guid? Id { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
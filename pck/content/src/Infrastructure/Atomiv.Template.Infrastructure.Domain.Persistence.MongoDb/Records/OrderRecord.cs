﻿using Atomiv.Infrastructure.MongoDB;
using Atomiv.Template.Core.Common.Orders;
using System;
using System.Collections.Generic;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB.Records
{
    public class OrderRecord : Record<Guid>
    {
        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus OrderStatusId { get; set; }

        public List<OrderItemRecord> OrderItems { get; set; }
    }
}

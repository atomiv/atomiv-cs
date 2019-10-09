﻿using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Orders.Handlers
{
    public class FindOrderHandler : FindAggregateRootHandler<DatabaseContext, Order, OrderIdentity, OrderRecord, int>
    {
        public FindOrderHandler(DatabaseContext context, IMapper mapper, IAggregateRootFactory<Order, OrderRecord> aggregateRootFactory) : base(context, mapper, aggregateRootFactory)
        {
        }
    }
}

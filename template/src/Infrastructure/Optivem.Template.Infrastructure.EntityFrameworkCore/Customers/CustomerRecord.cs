﻿using Optivem.Framework.Core.Domain;
using Optivem.Template.Infrastructure.EntityFrameworkCore.Orders;
using System.Collections.Generic;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers
{
    public class CustomerRecord : IIdentity<int>
    {
        public CustomerRecord()
        {
            Order = new HashSet<OrderRecord>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<OrderRecord> Order { get; set; }
    }
}
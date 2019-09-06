﻿using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerRepository : ICrudRepository<Customer, CustomerIdentity>
    {
    }
}
﻿using AutoMapper;
using Optivem.Template.Core.Application.Products.Commands;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Infrastructure.Mapping.Products
{
    public class RelistProductCommandResponseProfile : Profile
    {
        public RelistProductCommandResponseProfile()
        {
            CreateMap<Product, RelistProductCommandResponse>();
        }
    }
}
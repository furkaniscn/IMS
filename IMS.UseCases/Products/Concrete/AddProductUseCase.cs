﻿using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Products.Concrete
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository productRepository;
        public AddProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task ExecuteAsync(Product product)
        {
            await productRepository.AddProductAsync(product);
        }
    }
}

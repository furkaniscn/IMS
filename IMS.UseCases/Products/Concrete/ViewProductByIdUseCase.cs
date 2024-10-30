using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Products.Concrete
{
    public class ViewProductByIdUseCase : IViewProductByIdUseCase
    {
        IProductRepository productRepository;
        public ViewProductByIdUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<Product> ExecuteAsync(int productId)
        {
            return await productRepository.GetProductByIdAsync(productId);
        }
    }
}

using DeliveryManager.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Interfaces
{
    public interface IProductApplication
    {
        void CreateProduct(ProductDto productDto);

        List<ProductDto> GetAll();

        ProductDto GetProduct(long productId);

        void DeleteProduct(long productId);

        void UpdateProduct(ProductDto productDto, long productId);
    }
}

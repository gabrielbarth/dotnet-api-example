using System;
using System.Collections.Generic;

using ProductCatalog.Domain.Models;

namespace ProductCatalog.Domain.Interfaces
{
    public interface IProductRepository
    {
      IEnumerable<Product> GetProducts();
      Product GetProductById(int id);
      void SaveProduct(Product product);
      void UpdateProduct(Product product);
      void RemoveProduct(Product product);
      IEnumerable<Product> GetProductsByCategoryId(int id);
      
    }

}
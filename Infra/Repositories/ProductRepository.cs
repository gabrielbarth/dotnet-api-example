using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Context;
using ProductCatalog.Domain.Models;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Infra.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly StoreDataContext _context;

    // injeção de dependência para abrir apenas 1 conexão -> StoreDataContext
    public ProductRepository(StoreDataContext context)
    {
      _context = context;
    }

    public IEnumerable<Product> GetProducts()
    {
      return _context
          .Products
          .Include(x => x.Category)
          .Select(x => new Product(
              x.Id, x.Title, x.Description, x.Price, x.Quantity, x.Image, x.CreateDate, x.LastUpdateDate, x.CategoryId
          ))
          .AsNoTracking()
          .ToList();
    }

    public Product GetProductById(int id)
    {
      return _context.Products.Find(id);
    }

    public void SaveProduct(Product product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
      _context.Entry<Product>(product).State = EntityState.Modified;
      _context.SaveChanges();
    }
  
    public void RemoveProduct(Product product)
    {
        // _context.Remove(Product => .Id = id)
        _context.Entry<Product>(product).State = EntityState.Deleted;
        _context.SaveChanges();
    }
  
    public IEnumerable<Product> GetProductsByCategoryId(int id)
    {
        return _context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToList();
    }

  }
}
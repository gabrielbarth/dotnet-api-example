using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Context;
using ProductCatalog.Domain.Models;
using ProductCatalog.Domain.Interfaces;

namespace ProductCatalog.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDataContext _context;

        public CategoryRepository(StoreDataContext context) 
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        
        public Category GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void SaveCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
    
        public void RemoveCategory(Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Deleted;
            _context.SaveChanges();
        }
 
    }
}
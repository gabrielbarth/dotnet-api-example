using System;
using System.Collections.Generic;

using ProductCatalog.Domain.Models;

namespace ProductCatalog.Domain.Interfaces
{
    public interface ICategoryRepository
    {
      IEnumerable<Category> GetCategories();
      Category GetCategoryById(int id);
      void SaveCategory(Category category);
      void UpdateCategory(Category category);
      void RemoveCategory(Category category);
      

    }

}
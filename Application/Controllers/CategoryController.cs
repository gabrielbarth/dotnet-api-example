using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Models;
using ProductCatalog.Infra.Repositories;

namespace ProductCatalog.Controllers
{
    [Route("v1/categories")]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _repository.GetCategories();
        }

        [Route("{id}")]
        [HttpGet]
        public Category GetById(int id)
        {
            // Find() ainda não suporta AsNoTracking // FirstOrDefault -> primeiro que achar ou nullo se não achar
            return _repository.GetCategoryById(id); 
        }

        [Route("")]
        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            // _context.Categories.Add(category);
            // _context.SaveChanges();
            _repository.SaveCategory(category);

            return category;
        }

        [Route("")]
        [HttpPut]
        public Category Put([FromBody]Category category)
        {
            // _context.Entry<Category>(category).State = EntityState.Modified;
            // _context.SaveChanges();
            _repository.SaveCategory(category);

            return category;
        }

        [Route("")]
        [HttpDelete]
        public Category Delete([FromBody]Category category)
        {
            // _context.Categories.Remove(category);
            // _context.SaveChanges();
            _repository.RemoveCategory(category);

            return category;
        }

    }
}
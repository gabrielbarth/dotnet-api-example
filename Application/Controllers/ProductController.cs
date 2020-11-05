using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Domain.Models;
using ProductCatalog.Infra.Repositories;

namespace ProductCatalog.Controllers
{
    [Route("v1/products")]
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.GetProducts();
        }


        [Route("{id}")]
        [HttpGet]
        public Product GetById(int id)
        {
            return _repository.GetProductById(id);
        }


        [Route("{id}/category")]
        [HttpGet]
        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            return _repository.GetProductsByCategoryId(id);
        }

        [Route("")]
        [HttpPost]
        public Product Post([FromBody]Product product)
        {
            _repository.SaveProduct(product);

            return product;
        }


        [Route("")]
        [HttpPut]
        public Product Put([FromBody]Product product)
        {
            _repository.UpdateProduct(product);

            return product;
        }

        [Route("")]
        [HttpDelete]
        public Product Delete([FromBody]Product product)
        {
            _repository.RemoveProduct(product);

            return product;
        }

    }
}
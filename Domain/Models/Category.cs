using System;
using System.Collections.Generic;

namespace ProductCatalog.Domain.Models
{
    public class Category
    { 
        public int Id { get; private set; }
        public string Title { get; private set; }
        public IEnumerable<Product> Products { get; private set; }
    
        public void setId(int id) {
            this.Id = Id;
        }

        public void setTitle(string title) {
            this.Title = Title;
        }

        public void setProducts(IEnumerable<Product> products) {
		    this.Products = products;
	    }  
    
        public Category(int id, string title) {
            this.Id = id;
            this.Title = title;
        }

    }
}
using System;

namespace ProductCatalog.Domain.Models
{
  public class Product
  {
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public string Image { get; private set; }
    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }

    public void setId(int id)
    {
      this.Id = Id;
    }

    public void setTitle(string title)
    {
      this.Title = Title;
    }

    public void setDescription(string description)
    {
      this.Description = description;
    }

    public void setPrice(decimal price)
    {
      this.Price = price;
    }

    public void setQuantity(int quantity)
    {
      this.Quantity = quantity;
    }

    public void setImage(string image)
    {
      this.Image = image;
    }

    public void setCreateDate(DateTime createDate)
    {
      this.CreateDate = createDate;
    }

    public void setLastUpdateDate(DateTime lastUpdateDate)
    {
      this.LastUpdateDate = lastUpdateDate;
    }

    public void setCategoryId(int categoryId)
    {
      this.CategoryId = categoryId;
    }

    public void setCategory(Category category)
    {
      this.Category = category;
    }

    public Product(int id, string title, string description, decimal price, int quantity, string image, DateTime createDate, DateTime lastUpdateDate, int categoryId) {
      this.Id = id;
      this.Title = title;
      this.Description = description;
      this.Price = price;
      this.Quantity = quantity;
      this.Image = image;
      this.CreateDate = createDate;
      this.LastUpdateDate = lastUpdateDate;
      this.CategoryId = categoryId;
    }

  }
}
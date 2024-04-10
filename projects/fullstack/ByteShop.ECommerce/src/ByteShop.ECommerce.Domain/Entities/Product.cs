using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public Product(string name, decimal price, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        Description = description;
        Validate();
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new Exception("Name is required");
        }
        if (Price <= 0)
        {
            throw new Exception("Price must be greater than zero");
        }
    }
}

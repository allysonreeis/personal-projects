﻿using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.Application.ProductUseCases.Create;
public class CreateProductOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }

    public CreateProductOutput(Guid id, string name, decimal price, Category category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }
}

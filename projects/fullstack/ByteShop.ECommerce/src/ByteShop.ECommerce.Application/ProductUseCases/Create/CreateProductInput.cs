﻿using ByteShop.ECommerce.Domain.Entities;

namespace ByteShop.ECommerce.Application.ProductUseCases.Create;
public class CreateProductInput
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Guid CategoryId { get; set; }
    public int Quantity { get; set; }

    public CreateProductInput(string name, decimal price, string description, Guid categoryId, int quantity)
    {
        Name = name;
        Price = price;
        Description = description;
        CategoryId = categoryId;
        Quantity = quantity;
    }
}

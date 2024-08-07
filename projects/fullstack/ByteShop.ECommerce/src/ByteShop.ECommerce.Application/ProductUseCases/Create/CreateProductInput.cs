﻿using ByteShop.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.ProductUseCases.Create;
public class CreateProductInput
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public int Quantity { get; set; }

    public CreateProductInput(string name, decimal price, string description, Category category, int quantity)
    {
        Name = name;
        Price = price;
        Description = description;
        Category = category;
        Quantity = quantity;
    }
}

using ByteShop.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.OrderUseCases.Create;
public class OrderItemInput
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

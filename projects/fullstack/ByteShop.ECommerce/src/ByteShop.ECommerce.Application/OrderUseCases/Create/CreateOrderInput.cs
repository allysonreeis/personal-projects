using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.OrderUseCases.Create;

public class CreateOrderInput
{
    public Guid CustomerId { get; set; }
    public List<OrderItemInput> Items { get; set; } = [];

    public CreateOrderInput(Guid customerId, List<OrderItemInput> items)
    {
        CustomerId = customerId;
        Items = items;
    }
}

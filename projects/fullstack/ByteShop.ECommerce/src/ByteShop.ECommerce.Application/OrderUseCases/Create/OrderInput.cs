using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Application.OrderUseCases.Create;

public class OrderInput
{
    public List<OrderItemInput> Items { get; set; } = [];
}

using ByteShop.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Domain.Interfaces;
public interface IOrderRepository
{
    Task Insert(Order order, CancellationToken cancellationToken);
    Task<List<OrderItem>> Get(List<OrderItem> orderItems);
}

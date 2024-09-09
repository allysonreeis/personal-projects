using ByteShop.ECommerce.Domain.Entities;
using ByteShop.ECommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Infra.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ByteShopDbContext _context;

    public OrderRepository(ByteShopDbContext context)
    {
        _context = context;
    }

    public Task<List<OrderItem>> Get(List<OrderItem> orderItems)
    {
        throw new NotImplementedException();
    }

    public async Task Insert(Order order, CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(order, cancellationToken);
    }
}

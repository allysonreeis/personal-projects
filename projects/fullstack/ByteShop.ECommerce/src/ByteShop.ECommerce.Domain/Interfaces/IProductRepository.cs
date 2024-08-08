using ByteShop.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Domain.Interfaces;
public interface IProductRepository
{
    Task Insert(Product product, CancellationToken cancellationToken);
}

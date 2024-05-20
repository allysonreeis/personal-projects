using ByteShop.ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteShop.ECommerce.Infra;
public class ByteShopDbContext : DbContext
{
    public ByteShopDbContext(DbContextOptions<ByteShopDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
}

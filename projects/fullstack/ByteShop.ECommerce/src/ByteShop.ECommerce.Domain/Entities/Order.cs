namespace ByteShop.ECommerce.Domain.Entities;
public class Order
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> Items { get; set; } = [];
    public decimal Total { get; set; }

    public Order(List<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Items = new List<OrderItem>(items);
        Total = items.Sum(x => x.Total);
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
        Total += item.Total;
    }
}

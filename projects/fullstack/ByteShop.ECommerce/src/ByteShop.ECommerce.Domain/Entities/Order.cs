namespace ByteShop.ECommerce.Domain.Entities;
public class Order
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> Items { get; set; } = [];
    public decimal Total { get; set; }

    public Order()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
        Items = new List<OrderItem>();
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
        Total += item.Total;
    }
}

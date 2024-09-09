namespace ByteShop.ECommerce.Domain.Entities;
public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime CreatedAtUTC { get; set; }
    public List<OrderItem> Items { get; private set; } = [];
    private decimal _total; // backing field
    public decimal Total => Items.Sum(x => x.Total);

    private Order()
    {
    }

    public Order(Guid customerId, List<OrderItem> items)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        CreatedAtUTC = DateTime.UtcNow;
        Items = new List<OrderItem>(items);
    }

    public void AddItem(OrderItem item)
    {
        Items.Add(item);
        _total = Total;
    }

    public void AddItem(List<OrderItem> items)
    {
        Items.AddRange(items);
        _total = Total;
    }
}

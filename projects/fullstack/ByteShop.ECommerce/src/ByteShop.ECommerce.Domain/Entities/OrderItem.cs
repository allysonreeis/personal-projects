namespace ByteShop.ECommerce.Domain.Entities;
public class OrderItem
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; private set; }
    public decimal Total => Quantity * UnitPrice;

    public OrderItem(Guid productId, Guid orderId, int quantity, decimal unitPrice)
    {
        Id = Guid.NewGuid();
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}

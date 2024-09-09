namespace ByteShop.ECommerce.Api.Orders;

public class CreateOrderRequest
{
    public Guid CustomerId { get; set; }
    public List<OrderItemRequest> Items { get; set; } = [];

    public CreateOrderRequest(Guid customerId, List<OrderItemRequest> items)
    {
        CustomerId = customerId;
        Items = items;
    }
}

public class OrderItemRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    public OrderItemRequest(Guid productId, int quantity, decimal unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
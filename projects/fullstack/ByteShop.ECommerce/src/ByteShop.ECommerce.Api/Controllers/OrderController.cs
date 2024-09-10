using ByteShop.ECommerce.Application.OrderUseCases.Create;
using ByteShop.ECommerce.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ByteShop.ECommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    public OrderController(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderInput request, CancellationToken cancellationToken)
    {
        var createOrder = new CreateOrder(_orderRepository, _productRepository);
        var order = await createOrder.Handle(new CreateOrderInput(request.CustomerId, request.Items), cancellationToken);

        //return CreatedAtAction("nameof(Get)", new { id = order.Id }, order);
        return Ok(order);
    }
}

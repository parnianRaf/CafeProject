namespace Contracts.Dtos.RequestDtos;

public class OrderProductDto
{
    private OrderProductDto(string productId, string orderId , long quantity, decimal unitPrice)
    {
        ProductId = productId;
        OrderId = orderId;
        OrderNumber = quantity;
        OrderUnitPrice = unitPrice;
    }
    public string ProductId { get; set; }
    public string OrderId { get; set; }
    public long OrderNumber { get; set; }
    public decimal OrderUnitPrice { get;  set; }

    public static OrderProductDto Create(string productId, string orderId, long orderNumber,  decimal unitPrice)
    {
        return new(productId, orderId, orderNumber, unitPrice);
    }
}
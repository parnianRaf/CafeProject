namespace CafeService.FrameWorks.Dto.RequestDtos;

public class OrderDto
{
    private OrderDto(string cafeId, string customerId,string cafeTableId)
    {
        OrderProductDtos = new List<OrderProductDto>();
        CafeTableId = cafeTableId;
        CustomerId = customerId;
        CafeId =  cafeId;
    }
    public string CafeId { get; set; }
    public string CafeTableId { get; set; }
    public string CustomerId { get; set; }    
    public List<OrderProductDto> OrderProductDtos { get; set; }

    public static OrderDto Create(string cafeId, string customerId,string cafeTableId)
    {
        return new(cafeId, customerId, cafeTableId);
    }
}
namespace CafeService.FrameWorks.Dto.ProductAggDto;

public class AddProductDto
{
    public string Name { get; set; } = null!;
    public string? ProductCode { get; set; }
    public string? Description { get; set; }
}
namespace CafeFlow.Framework.CommonDtos.RedisDtos;

public record RedisResultDto(string CustomerId,Type Type, string ProductId, long Quantity);

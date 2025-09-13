namespace CafeFlow.Framework.CommonDtos.ResultDtos.ServiceDto;

public class CommonServiceDto<T>
{
    private CommonServiceDto(bool isSuccess,T? result)
    {
        IsSuccess = isSuccess;
        Result = result;
    }
    public bool IsSuccess { get; private set; }
    public T? Result { get; private set; }

    public static CommonServiceDto<T> CreateSuccess(T result) => new(true,  result);
    public static CommonServiceDto<T> CreateFailed(T? result = default) => new(false, result);

}
namespace CafeFlow.AuthenticationService.Extensions;

public static class ExtensionMethods
{
    public static Guid GenerateDeterministicGuid(string input, string salt)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
        var hash = md5.ComputeHash(bytes);
        return new Guid(hash);
    }
}
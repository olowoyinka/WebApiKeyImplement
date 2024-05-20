namespace WebApiKeyImplement.Utilities;

public interface IApiKeyValidation
{
    bool IsValidApiKey(string userApiKey);
}
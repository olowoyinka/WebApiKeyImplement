using Microsoft.AspNetCore.Mvc;

namespace WebApiKeyImplement.APIKey;

public class ApiKeyAttribute : ServiceFilterAttribute
{
    public ApiKeyAttribute() : base(typeof(ApiKeyAuthFilter))
    {
    }
}
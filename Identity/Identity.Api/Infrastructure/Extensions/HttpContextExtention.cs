using Microsoft.AspNetCore.Http;

namespace Identity.Api.Infrastructure.Extensions;

public static class HttpContextExtention
{
    public static string GetUserId(this HttpContext context)
    {
        if (context.User is null)
        {
            return string.Empty;
        }

        return context.User.Claims.Single(claim => claim.Type == "id").Value;
    }
}
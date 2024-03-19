using System.Security.Claims;

namespace Learning_MVC
{
    public static class ClaimsPrincipalExtensions
    {
         public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PrBeleBackend.API.Filters
{
    public class PermissionAuthorizeAttribute : TypeFilterAttribute
    {
        public PermissionAuthorizeAttribute(string permission)
            : base(typeof(PermissionAuthorizeFilter))
        {
            Arguments = new object[] { permission };
        }
    }

    public class PermissionAuthorizeFilter : IAuthorizationFilter
    {
        private readonly string _permission;

        public PermissionAuthorizeFilter(string permission)
        {
            _permission = permission;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated ||
                !user.HasClaim(c => c.Type == "Permission" && c.Value == _permission))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}

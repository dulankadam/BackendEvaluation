using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BackendEvaluation.API.Extensions;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class HasPermissionAttribute : Attribute, IAuthorizationFilter
{
    private string[] permissions { get; set; }
    private bool allowEServiceUser { get; set; }

    public HasPermissionAttribute(params string[] permissions)
    {
        if (permissions != null && permissions.Length > 0 && permissions.Any(x => string.IsNullOrWhiteSpace(x)))
            throw new ArgumentNullException("permissions", "Permissions value is not valid!");
        this.permissions = permissions;
        this.allowEServiceUser = false;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        throw new NotImplementedException();
    }
}

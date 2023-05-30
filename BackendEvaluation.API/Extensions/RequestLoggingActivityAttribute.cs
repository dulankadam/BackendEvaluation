using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using BackendEvaluation.Core.Common.Interfaces;

namespace BackendEvaluation.API.Extensions;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class RequestLoggingActivityAttribute : ActionFilterAttribute
{
    public readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    private readonly IConfiguration _configuration;

    public RequestLoggingActivityAttribute(IApplicationDbContext context,
        ICurrentUserService currentUserService,
        IConfiguration configuration)
    {
        _context = context;
        _currentUserService = currentUserService;
        _configuration = configuration;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var enableActivityLog = _configuration.GetValue<bool>("EnableActivityLog");

        if (!enableActivityLog)
            return;

        var sb = new StringBuilder();
        foreach (var key in filterContext.RouteData.Values.Keys)
        {
            sb.AppendFormat("{0}: {1}", key, filterContext.RouteData.Values[key].ToString());
        }

        base.OnActionExecuting(filterContext);
    }
}

using System.Security.Claims;
using BackendEvaluation.Core.Common.Interfaces;
using BackendEvaluation.Domain.Enum;
using IdentityModel;

namespace BackendEvaluation.Api.Services;
public class CurrentUserService : ICurrentUserService
{
    private readonly HttpContext _context;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _context = httpContextAccessor.HttpContext;
    }

    public IEnumerable<Claim> Claims
    {
        get
        {
            return (_context.User.Identity as ClaimsIdentity).Claims;
        }
    }

    public string UserId
    {
        get
        {
            return Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Id)?.Value;
        }
    }

    public string UserName
    {
        get
        {
            return Claims.FirstOrDefault(c => c.Type == "URL")?.Value;
        }
    }

    public string UserEmail
    {
        get
        {
            return Claims.FirstOrDefault(c => c.Type == "userEmail")?.Value;
        }
    }

    public string IdentifierNumber
    {
        get
        {
            return Claims.FirstOrDefault(c => c.Type == "IdentifierNumber")?.Value;
        }
    }

    public DateTime DOB
    {
        get
        {
            var dateValue = Claims.FirstOrDefault(c => c.Type == "DateOfBirth")?.Value;
            DateTime.TryParse(dateValue, out DateTime dateTime);

            return dateTime;
        }
    }

    public UserType UserType
    {
        get
        {
            var userType = Claims.FirstOrDefault(c => c.Type == "userType");
            return userType == null ? UserType.Anonymous : new UserType();
        }
    }

    UserType ICurrentUserService.UserType => throw new NotImplementedException();
}

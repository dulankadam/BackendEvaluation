using BackendEvaluation.Domain.Enum;
using BackendEvaluation.Domain.Models.Base;

namespace BackendEvaluation.Domain.Models.Users;
public class User : ModelBase
{
    public string IdentityUserId { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string IdentifierNumber { get; set; }

    public DateTime? DOB { get; set; }

    public string IdentityType { get; set; }

    public UserType UserType { get; set; }
}


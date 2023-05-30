using BackendEvaluation.Domain.Enum;
namespace BackendEvaluation.Core.Common.Interfaces;
public interface ICurrentUserService
{
    string UserId { get; }

    string UserName { get; }

    string UserEmail { get; }

    string IdentifierNumber { get; }

    UserType UserType { get; }

    DateTime DOB { get; }
}

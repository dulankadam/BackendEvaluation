using BackendEvaluation.Domain.Models.Common;
using BackendEvaluation.Domain.Models.Users;
namespace BackendEvaluation.Core.Common.Interfaces;

public interface IIdentityService
{
    Task<User> CurrentUser();
    Task<string> GetUserNameAsync(string userId);
    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
    Task<Result> DeleteUserAsync(string userId);
    Task<User> GetUserByIdentifierNumberAsync(string userId);
    Task<User> GetUserAsync(int userId);
    Task<(User, List<String>)> CurrentUserWithPermissionsAsync();
}


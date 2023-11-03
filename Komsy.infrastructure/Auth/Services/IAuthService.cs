using Komsy.infrastructure.Auth.Models;

namespace Komsy.infrastructure.Auth.Services;

public interface IAuthService {
  Task<UserModel> Login(LoginModel loginModel);
  Task Logout();
  Task<UserModel> Register(UserModel registerModel);
  Task<UserModel> RefreshToken();
  Task<bool> ResetPassword(string email);
}

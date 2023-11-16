using Komsy.infrastructure.Auth.Models;
using Komsy.Infrastructure.Auth.Models;

namespace Komsy.infrastructure.Auth.Services;

public interface IAuthService {
  Task<UserModel> Login(LoginModel loginModel);
  Task Logout();
  Task<UserModel> SignUp(SignUpModel signUpModel);
  Task<UserModel> RefreshToken();
  Task<bool> ResetPassword(string email);
}

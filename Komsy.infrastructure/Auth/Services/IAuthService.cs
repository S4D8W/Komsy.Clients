using Komsy.infrastructure.Auth.Models;
using Komsy.infrastructure.Models.Auth;

namespace Komsy.infrastructure.Services.Auth;

public interface IAuthService {
	Task<UserModel> Login(LoginModel loginModel);
	Task Logout();
	Task<UserModel> Register(UserModel registerModel);
	Task<UserModel> RefreshToken();

}

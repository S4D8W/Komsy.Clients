using Komsy.infrastructure.Auth.Models;
using Komsy.infrastructure.Models.Auth;
using Komsy.infrastructure.Routes;
using Komsy.infrastructure.Services.Http;

namespace Komsy.infrastructure.Auth.Services;

public class AuthService : IAuthService {

  private readonly IHttpService _httpService;

  public AuthService(IHttpService httpService) {
    _httpService = httpService;
  }

  public async Task<UserModel> Login(LoginModel loginModel) {

    var pAddress = AuthAdresses.Login;
    var result = await _httpService.Post<AuthResponse>(pAddress, loginModel);

    if (result is null || result.user is null) {
      return null!;
    }

    return new UserModel {
      FirstName = result.user.FirstName,
      LastName = result.user.LastName,
      Email = result.user.Email,
      UId = result.user.UId,
      Token = result.Token
    };
  }

  public Task Logout() {
    throw new NotImplementedException();
  }

  public Task<UserModel> RefreshToken() {
    throw new NotImplementedException();
  }

  public Task<UserModel> Register(UserModel registerModel) {
    throw new NotImplementedException();
  }
}

using Komsy.infrastructure.Auth.Models;
using Komsy.infrastructure.Routes;
using Komsy.infrastructure.Services.Http;
using Komsy.Infrastructure.Auth.Models;

namespace Komsy.infrastructure.Auth.Services;

public class AuthService : IAuthService {

  private readonly IHttpService _httpService;

  public AuthService(IHttpService httpService) {
    _httpService = httpService;
  }

  public async Task<bool> ResetPassword(string email) {

    string Address = AuthAdresses.ResetPassword;

    var result = await _httpService.Post<object>(Address, new {
      email = email
    });

    return true;
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

  public async Task<UserModel> SignUp(SignUpModel registerModel) {

    AuthResponse response = await
     _httpService.Post<AuthResponse>(AuthAdresses.Register, registerModel);


    if (response is null || response.user is null) {
      return null!;
    }

    return new UserModel {
      FirstName = response.user.FirstName,
      LastName = response.user.LastName,
      Email = response.user.Email,
      UId = response.user.UId,
      Token = response.Token
    };

  }
}

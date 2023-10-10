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
		var result = await _httpService.Post<LoginModel>(pAddress, loginModel);

		throw new NotImplementedException();
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

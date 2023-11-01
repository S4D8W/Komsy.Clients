using Komsy.infrastructure.Auth.Services;
using Microsoft.AspNetCore.Components;

namespace Komsy.web.Pages.Auth;


public class ForgotPage : ComponentBase {

	[Inject]
	IAuthService AuthService { get; set; } = null!;


	public string Email { get; set; } = null!;
	public bool ResetPasswprdVisible { get; set; } = false;
	public async Task ForgotPassword() {

		var result = await AuthService.ResetPassword(Email);



	}
}

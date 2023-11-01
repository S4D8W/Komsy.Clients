using System;
using System.ComponentModel;
using Komsy.infrastructure.Auth.Models;
using Komsy.infrastructure.Auth.Services;
using Komsy.infrastructure.Auth.Validators;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Komsy.web.Pages.Auth {

	public class LoginPage : ComponentBase {

		public LoginModel LoginModel { get; set; } = new LoginModel();
		public LoginValidator LoginValidator { get; set; } = new LoginValidator();
		public MudForm LoginFrm { get; set; } = null!;
		public InputType PasswordInput = InputType.Password;
		public bool ShowPassword { get; set; } = false;
		public string PasswordVisibilityIcon = Icons.Material.Filled.VisibilityOff;
		public bool ForogotPasswordVisible { get; set; } = true;
		public String foo => "hidden";

		[Inject] public IAuthService authService { get; set; } = null!;
		private NavigationManager _navigationManager;

		public async Task Login() {
			var result = await LoginValidator.ValidateAsync(LoginModel);

			if (!result.IsValid) {
				return;
			}

			var loginResult = await authService.Login(LoginModel);
			if (loginResult is null) {
				this.ForogotPasswordVisible = false;
			}

		}

		public void TogglePasswordVisibility() {
			ShowPassword = !ShowPassword;
			PasswordInput = ShowPassword ? InputType.Text : InputType.Password;
			PasswordVisibilityIcon = ShowPassword ? Icons.Material.Filled.Visibility : Icons.Material.Filled.VisibilityOff;
		}

	}
}

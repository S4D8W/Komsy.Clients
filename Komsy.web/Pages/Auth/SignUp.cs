using Komsy.infrastructure.Auth.Services;
using Komsy.infrastructure.Auth.Validators;
using Komsy.Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Komsy.web.Pages.Auth;

public class SignUp : ComponentBase {

	public SignUpModel SignUpModel { get; set; } = new SignUpModel();
	public SignUpValidator SignUpValidator { get; set; } = new SignUpValidator();
	public MudForm SignUpFrm { get; set; } = null!;
	public bool ShowPassword { get; set; } = false;
	public bool ShowConfirmPassword { get; set; } = false;
	public InputType PasswordInput = InputType.Password;
	public InputType ConfirmPasswordInput = InputType.Password;
	public string PasswordVisibilityIcon = Icons.Material.Filled.VisibilityOff;

	[Inject] public IAuthService AuthService { get; set; } = null!;


	public async Task SignUpSubmit() {

		var result = await SignUpValidator.ValidateAsync(SignUpModel);

		if (!result.IsValid) {
			return;
		}

		var user = await AuthService.SignUp(SignUpModel);

	}



	public async Task CheckEmailIsAllredyTaken(string email) {

		this.SignUpModel.Email = email;

		var result = await SignUpValidator.ValidateValue(SignUpModel, nameof(SignUpModel.Email));
		result.Append("Email is allredy taken");

		await SignUpValidator.SetFieldError(SignUpModel, nameof(SignUpModel.Email), "Email is allredy taken");
		await SignUpValidator.ValidateAsync(SignUpModel);

		StateHasChanged();

	}

	public void TogglePasswordVisibility() {
		ShowPassword = !ShowPassword;
		PasswordInput = ShowPassword ? InputType.Text : InputType.Password;
		PasswordVisibilityIcon = ShowPassword ? Icons.Material.Filled.Visibility : Icons.Material.Filled.VisibilityOff;
	}

	public void ToggleConfirmPasswordVisibility() {
		ShowConfirmPassword = !ShowConfirmPassword;
		ConfirmPasswordInput = ShowConfirmPassword ? InputType.Text : InputType.Password;
		PasswordVisibilityIcon = ShowConfirmPassword ? Icons.Material.Filled.Visibility : Icons.Material.Filled.VisibilityOff;
	}

}

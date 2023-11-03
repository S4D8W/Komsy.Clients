using Komsy.infrastructure.Auth.Validators;
using Komsy.Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Komsy.web.Pages.Auth;

public class SignUp : ComponentBase {

  public SignUpModel SignUpModel { get; set; } = new SignUpModel();
  public SignUpValidator SignUpValidator { get; set; } = new SignUpValidator();
  public MudForm SignUpFrm { get; set; } = null!;



  public async Task SignUpSubmit() {
    var result = await SignUpValidator.ValidateAsync(SignUpModel);
    if (result.IsValid) {
    }
  }



  public async Task CheckEmailIsAllredyTaken(string email) {

    this.SignUpModel.Email = email;

    var result = await SignUpValidator.ValidateValue(SignUpModel, nameof(SignUpModel.Email));
    result.Append("Email is allredy taken");

    await SignUpValidator.SetFieldError(SignUpModel, nameof(SignUpModel.Email), "Email is allredy taken");
    await SignUpValidator.ValidateAsync(SignUpModel);

    StateHasChanged();

  }

}

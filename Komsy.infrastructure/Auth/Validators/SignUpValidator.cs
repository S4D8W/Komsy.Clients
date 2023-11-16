using System.Dynamic;
using FluentValidation;
using Komsy.infrastructure.Languages;
using Komsy.Infrastructure.Auth.Models;

namespace Komsy.infrastructure.Auth.Validators;

public class SignUpValidator : AbstractValidator<SignUpModel> {
  public SignUpValidator() {

    RuleFor(x => x.Email)
    .NotEmpty().WithMessage(Lang.GetText(TextEnum.EmailDoesntEmpty))
    .EmailAddress().WithMessage(Lang.GetText(TextEnum.PleaseValidEmail));

    RuleFor(x => x.Password)
    .NotEmpty().WithMessage(Lang.GetText(TextEnum.PasswordDoesntEmpty))
    .MinimumLength(8).WithMessage(Lang.GetText(TextEnum.PasswordMinimumLength));

    RuleFor(x => x.ConfirmPassword)
      .Equal(x => x.Password).WithMessage(Lang.GetText(TextEnum.PasswordsNotMatch));

  }

  public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) => {
    var result = await ValidateAsync(ValidationContext<SignUpModel>.CreateWithOptions((SignUpModel)model, x => x.IncludeProperties(propertyName)));
    if (result.IsValid)
      return Array.Empty<string>();
    return result.Errors.Select(e => e.ErrorMessage);
  };

  public Func<object, string, string, Task> SetFieldError => async (model, propertyName, errorMessage) => {
    var result = await ValidateAsync(ValidationContext<SignUpModel>.CreateWithOptions((SignUpModel)model, x => x.IncludeProperties(propertyName)));
    if (result.IsValid)
      return;
    var error = result.Errors.FirstOrDefault();
    if (error != null)
      error.ErrorMessage = errorMessage;
  };



}

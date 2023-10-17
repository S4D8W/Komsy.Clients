using FluentValidation;
using Komsy.infrastructure.Auth.Models;

namespace Komsy.infrastructure.Auth.Validators;

public class LoginValidator : AbstractValidator<LoginModel> {
  public LoginValidator() {
    RuleFor(x => x.Email).NotEmpty().WithMessage("ddd")
      .EmailAddress().WithMessage("foo");
    RuleFor(x => x.Password).NotEmpty();
  }

  public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) => {
    var result = await ValidateAsync(ValidationContext<LoginModel>.CreateWithOptions((LoginModel)model, x => x.IncludeProperties(propertyName)));
    if (result.IsValid)
      return Array.Empty<string>();
    return result.Errors.Select(e => e.ErrorMessage);
  };
}

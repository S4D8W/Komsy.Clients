using Komsy.infrastructure.Models.Auth;

namespace Komsy.infrastructure.Auth;

public record AuthResponse(

   UserModel user,
  string Token
);


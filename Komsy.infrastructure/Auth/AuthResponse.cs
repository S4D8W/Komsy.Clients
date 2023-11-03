
using Komsy.infrastructure.Auth.Models;

namespace Komsy.infrastructure.Auth;

public record AuthResponse(

   UserModel user,
    string Token
);


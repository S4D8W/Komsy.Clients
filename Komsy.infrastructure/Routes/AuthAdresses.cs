

namespace Komsy.infrastructure.Routes {
  public static class AuthAdresses {


    public static string Login => BaseAddresses.BaseAddress + "api/auth/login";
    public static string Register => BaseAddresses.BaseAddress + "api/auth/register";
    public static string Refresh => BaseAddresses.BaseAddress + "api/auth/refresh";
  }
}

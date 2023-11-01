

namespace Komsy.infrastructure.Routes {
  public static class AuthAdresses {


    public static string Login => BaseAddresses.BaseAddress + "auth/login";
    public static string Register => BaseAddresses.BaseAddress + "auth/register";
    public static string Refresh => BaseAddresses.BaseAddress + "auth/refresh";
    public static string ResetPassword => BaseAddresses.BaseAddress + "auth/ResetPassword";
  }
}

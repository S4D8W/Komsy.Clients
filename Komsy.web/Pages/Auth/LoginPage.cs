using System.ComponentModel;
using Komsy.infrastructure.Auth.Models;
using Microsoft.AspNetCore.Components;

namespace Komsy.web.Pages.Auth {

	public class LoginPage : ComponentBase {

		public LoginModel LoginModel { get; set; } = new LoginModel();
	}
}

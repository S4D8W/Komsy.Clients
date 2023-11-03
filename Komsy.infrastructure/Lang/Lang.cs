using System.Globalization;
namespace Komsy.infrastructure.Languages {

	public enum LangEnum {
		PL = 1,
		EN = 2,
	}

	public enum TextEnum {
		LogIn = 1,
		Email = 2,
		Password = 3,
		ForgotPassword = 4,
		Remind = 5,
		SomethingWentWrong = 6,
		ErrorType = 7,
		Title = 8,
		StatusCode = 9,
		TraceId = 10,
		Send = 11,
		EnterYourEmailAddressAndWeWillWendYouNewPassword = 12,
		SignUp = 13,
		SingIn = 14,
		PleaseValidEmail = 15,
		EmailDoesntEmpty = 16,
		PasswordDoesntEmpty = 17,
		PasswordMinimumLength = 18,
		PasswordsNotMatch = 19,
		FirstName = 20,
		LastName = 21,
		ConfirmPassword = 22,
		DontHaveAccountSignIn = 23,
	}

	public static class Lang {

		private static Dictionary<int, string> PL_Textes;
		private static Dictionary<int, string> EN_Textes;

		private static LangEnum _lang = LangEnum.PL;

		private static void InitializeTextes() {
			AddText(TextEnum.LogIn, "Zaloguj", "Log In");
			AddText(TextEnum.Email, "Email", "Email");
			AddText(TextEnum.Password, "Hasło", "Password");
			AddText(TextEnum.ForgotPassword, "Zapomniałeś hasła?", "Forgot password?");
			AddText(TextEnum.Remind, "Przypomnij", "Remind");
			AddText(TextEnum.SomethingWentWrong, "Coś poszło nie tak", "Something went wrong");
			AddText(TextEnum.ErrorType, "Typ błędu", "Error type");
			AddText(TextEnum.Title, "Tytuł", "Title");
			AddText(TextEnum.StatusCode, "Kod błędu", "Status code");
			AddText(TextEnum.TraceId, "Id śladu", "Trace id");
			AddText(TextEnum.Send, "Wyślij", "Send");
			AddText(TextEnum.EnterYourEmailAddressAndWeWillWendYouNewPassword, "Wpisz swój adres e-mail, a wyślemy Ci nowe hasło", "Enter your email address and we will send you a new password");
			AddText(TextEnum.SignUp, "Zarejestruj się", "Sign up");
			AddText(TextEnum.SingIn, "Zaloguj się", "Sign in");
			AddText(TextEnum.PleaseValidEmail, "Proszę podać poprawny adres email", "Please enter a valid email address");
			AddText(TextEnum.EmailDoesntEmpty, "Email nie może być pusty", "Email can't be empty");
			AddText(TextEnum.PasswordDoesntEmpty, "Hasło nie może być puste", "Password can't be empty");
			AddText(TextEnum.PasswordMinimumLength, "Hasło musi mieć minimum 8 znaków", "Password must be at least 8 characters long");
			AddText(TextEnum.PasswordsNotMatch, "Hasła nie są takie same", "Passwords are not the same");
			AddText(TextEnum.FirstName, "Imię", "First name");
			AddText(TextEnum.LastName, "Nazwisko", "Last name");
			AddText(TextEnum.ConfirmPassword, "Potwierdź hasło", "Confirm password");
			AddText(TextEnum.DontHaveAccountSignIn, "Nie masz konta? Zarejestruj się", "Don't have an account? Sign up");
		}


		public static void SetCurrenLang(LangEnum lang) {
			_lang = lang;
		}

		public static void Init() {

			PL_Textes = new Dictionary<int, string>();
			EN_Textes = new Dictionary<int, string>();
			InitializeTextes();

		}


		public static string GetText(TextEnum key) {

			string? text;

			switch (_lang) {
				case LangEnum.PL:
					text = PL_Textes.TryGetValue((int)key, out text) ? text : "Empty Translation";
					break;
				case LangEnum.EN:
					text = EN_Textes.TryGetValue((int)key, out text) ? text : "Empty Translation";
					break;
				default:
					text = "Empty Translation";
					break;
			}

			return text;
		}



		private static void AddText(TextEnum key, string PL, string EN) {
			PL_Textes.Add((int)key, PL);
			EN_Textes.Add((int)key, EN);
		}



	}
}

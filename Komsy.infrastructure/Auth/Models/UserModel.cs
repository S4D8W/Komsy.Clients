namespace Komsy.infrastructure.Models.Auth {
	public class UserModel {

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public Guid Id { get; set; }
		public string Token { get; set; }


	}
}

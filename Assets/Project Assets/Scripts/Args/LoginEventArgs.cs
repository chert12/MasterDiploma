using System;

namespace AAStudio.Diploma.Args
{
	public class LoginEventArgs : EventArgs
	{
		public LoginEventArgs(string email, string password)
		{
			Email = email;
			Password = password;
		}

		public string Email { get; private set; }
		public string Password { get; private set; }
	}
}

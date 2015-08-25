using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace todolist
{
	public partial class LoginXamlPage : ContentPage
	{
		public LoginXamlPage ()
		{
			InitializeComponent ();
			this.Title = "User Login";

		}

		void loginButtonClicked(object sender, EventArgs e){
			if ((!String.IsNullOrEmpty(userNameEntry.Text)) && (!String.IsNullOrEmpty(passwordEntry.Text))) {
				Navigation.PushAsync (new TaskList ());
			} else {
				DisplayAlert ("Login Error", "Please enter text in both the entry fields", "OK");
			}
		}
}


}


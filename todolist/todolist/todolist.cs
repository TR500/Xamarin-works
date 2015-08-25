using System;

using Xamarin.Forms;

namespace todolist
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application

			//MainPage = new LoginXamlPage ();

			NavigationPage objNavPage = new NavigationPage (new LoginXamlPage ());
			this.MainPage = objNavPage;

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}


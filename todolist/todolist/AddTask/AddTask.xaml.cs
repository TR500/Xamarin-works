using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace todolist
{
	public partial class AddTask : ContentPage
	{
		SqliteHelper databaseOP;

		public AddTask ()
		{
			InitializeComponent ();

			databaseOP = new SqliteHelper ();
			dtPicker.Date = DateTime.Now;
			taskTime.Time = DateTime.Now.TimeOfDay;

			this.Title = "New Task";
			NavigationPage.SetBackButtonTitle(this,"List");

			ToolbarItems.Add(new ToolbarItem {
				Text = "Save",
				Order = ToolbarItemOrder.Primary,
				Command = new Command(() => this.saveTask()),
			});
		}

		void displayDateTimePicker(object sender, EventArgs e){
			dtPicker.IsVisible = true;
		}


		void saveTask(){
			
			if (!String.IsNullOrEmpty (addTaskEntry.Text)) {

				// Are you sure you want to save it in and then display another alert
				displaySomeAlert ();

			} else {
				DisplayAlert ("Alert", "Please add Taskname to add", "Ok");
			}

		}

		// Learning Reference: http://www.dotnetperls.com/async
		async void displaySomeAlert(){
			var answer = await DisplayAlert("Add","You sure you want to save this","YES","NO");
			if (answer.Equals (true)) {
				int operationResult = databaseOP.SaveRecord (this.prepareObject ());
				Console.WriteLine (operationResult);
				await DisplayAlert ("Alert", "Data saved", "Ok");
			} else {
				await DisplayAlert ("Alert", "Data saving failed", "OK");
			}
		}


		UserTask prepareObject(){
			UserTask task = new UserTask ();
			task.taskName = addTaskEntry.Text;
			task.taskDate = dtPicker.Date;
			task.taskTime = DateTime.Today + taskTime.Time;
			return task;
		}
	}
}


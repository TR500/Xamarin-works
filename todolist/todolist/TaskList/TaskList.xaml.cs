using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace todolist
{
	public partial class TaskList : ContentPage
	{
		public TaskList ()
		{
			InitializeComponent ();
			this.Title = "Task List";
			addBarButtonItem ();
			drawTaskListinPage ();
		}

		void drawTaskListinPage(){

			// hide the back button
			NavigationPage.SetHasBackButton (this, false);

			// create object of list view
			var listview = new ListView {
				RowHeight = 60
			};
					

			// feed data to the list item
			listview.ItemsSource = new UserTask[] {
				new UserTask("Learn Xamarin"),
				new UserTask("Go to Gym"),
			};

			// display which item is visible 
			listview.ItemTemplate = new DataTemplate(typeof(TaskCell));

			// add the list view to the current content page
			Content = new StackLayout {
				Children = { listview }
			};
		}

		void addBarButtonItem(){
			ToolbarItems.Add(new ToolbarItem {
				Text = "Add",
				Order = ToolbarItemOrder.Primary,
				Command = new Command(() => Navigation.PushAsync(new AddTask())),
			});
		}
	}
}


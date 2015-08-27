using System;
using Xamarin.Forms;

namespace todolist
{
	public class TaskCell : ViewCell
	{
		// Learning Reference : https://www.syntaxismyui.com/xamarin-forms-listview-custom-viewcell-recipe/
		public TaskCell ()
		{
			var taskImage = new Image {
				HeightRequest = 50,
				WidthRequest = 50,
				Aspect = Aspect.AspectFit,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Source = ImageSource.FromFile("img.png"),

			};
				
			var taskLabel = new Label () {
				FontFamily = "HelveticaNeue-Medium",
				FontSize = 12,
				TextColor = Color.Black
			};

			taskLabel.SetBinding (Label.TextProperty, "taskName");

			var viewLayout = new StackLayout {
				Padding  = new Thickness(15,10,0,0),
				Spacing = 0,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {taskLabel}
			};
					
			var cellLayout = new StackLayout {
				Spacing = 0,
				Padding = new Thickness(10,5,10,5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {taskImage,viewLayout}
			};
				
			this.View = cellLayout;
		}

	}
}


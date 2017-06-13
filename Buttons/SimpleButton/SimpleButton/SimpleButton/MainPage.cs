using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleButton
{
    
    public class MainPage:ContentPage
    {
        StackLayout loggerLayout = new StackLayout();
        private Button button;

        public MainPage()
        {
            button = new Button
            {
                Text = "Click Me!!"
            };

            this.Content = new StackLayout
            {
                Children =
                {
                    button,
                    new ScrollView
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Content = loggerLayout
                    }
                }
            };

            HandleEvents();
        }

        private void HandleEvents()
        {
            button.Clicked += delegate
            {
                loggerLayout.Children.Add(new Label
                {
                    Text = "Button clicked at " + DateTime.Now.ToString()
                });
            };
        }
    }
}

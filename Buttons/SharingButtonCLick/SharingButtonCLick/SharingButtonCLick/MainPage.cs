using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharingButtonCLick
{
    public class MainPage:ContentPage
    {
        private Button firstButton;
        private Button secondButton;

        StackLayout stackLayout = new StackLayout();

        private Label label;

        public MainPage()
        {
            SetViewElements();

            this.Content = new StackLayout
            {
                Children =
                { 
                    firstButton,
                    secondButton,
                    stackLayout,
                }
            };
                        
            HandleEvents();

        }

        private void SetViewElements()
        {
            firstButton = new Button
            {
                Text = "First Button"
            };
            secondButton = new Button
            {
                Text = "Second Button"
            };
        }

        private void HandleEvents()
        {
            firstButton.Clicked += SharedButtonClick;
            secondButton.Clicked += SharedButtonClick;
        }

        private void SharedButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(button == firstButton)
            {
                stackLayout.Children.Add(new Label
                {
                    Text = "First Button Clicked!!!"
                });
            }
            else
            { 
                stackLayout.Children.Add(new Label
                {
                    Text = "Second Button Clicked!!!"
                });

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleKeypad
{
    public class SimpleKeypadPage : ContentPage 
    {
        Label displayLabel;
        Button backspaceButton;

        public SimpleKeypadPage()
        {
            //Create a vertical stack for the entire keypad
            StackLayout mainStack = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            //First row is the label
            displayLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.End,
            };

            mainStack.Children.Add(displayLabel);

            //Second row is the backspace Button
            backspaceButton = new Button
            {
                Text = "\u21E6",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                IsEnabled = false,
            };
            backspaceButton.Clicked += BackspaceButton_Clicked;
            mainStack.Children.Add(backspaceButton);

            //Number Keys
            StackLayout rowStack = null;
            for (int num =1; num<=10; num++)
            {
                if((num-1)%3==0)
                {
                    rowStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                    };
                    mainStack.Children.Add(rowStack);
                }

                Button digitButton = new Button
                {
                    Text = (num % 10).ToString(),
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
                    StyleId = (num % 10).ToString(),
                };
                digitButton.Clicked += DigitButton_Clicked;

                //For Zero Button, expand to fill horizontally
                if(num==10)
                {
                    digitButton.HorizontalOptions = LayoutOptions.FillAndExpand;
                };
                rowStack.Children.Add(digitButton);

            }


            IDictionary<string, object> properties = Application.Current.Properties;
            if(properties.ContainsKey("displayLabelText"))
            {
                displayLabel.Text = properties["displayLabelText"] as string;
                backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
            }

            this.Content = mainStack;
        }

        private void DigitButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            displayLabel.Text += (string)button.StyleId;
            backspaceButton.IsEnabled = true;
            Application.Current.Properties["displayLabelText"] = displayLabel.Text;
        }

        private void BackspaceButton_Clicked(object sender, EventArgs e)
        {
            String text = displayLabel.Text;
            displayLabel.Text = text.Substring(0, text.Length - 1);
            backspaceButton.IsEnabled = displayLabel.Text.Length > 0;
            Application.Current.Properties["displayLabelText"] = displayLabel.Text;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _01_DataBinding
{
    public class OpacityBindingCodePage:ContentPage
    {
        public OpacityBindingCodePage()
        {
            Label label = new Label
            {
                Text = "Opacity Binding Demo",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider slider = new Slider
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            //First Method
            ////Set the binding context: target is Label; source is Slider.
            //label.BindingContext = slider;

            ////Bind the properties: target is Opacity; source is Value
            //label.SetBinding(Label.OpacityProperty, "Value");

            //Second Method
            Binding binding = new Binding
            {
                Source = slider,
                Path = "Value",
            };

            label.SetBinding(Label.OpacityProperty, binding);

            //Construct the Page
            Padding = new Thickness(10, 0);
            Content = new StackLayout
            {
                Children =
                {
                    label,
                    slider,
                }
            };
        }
    }
}

using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RotaryWheelUserControl;
using System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RotaryWheelDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            textBoxabc.Text = "a\rb\rc\rd\re";
            rotaryWheelDemo.PropertyChanged += RotaryWheelDemo_PropertyChanged;
            rotaryWheelDemo.SpinEnded += (e, a) =>
            {
                new Result(rotaryWheelDemo.SelectedItemValue).ShowAsync();
            };
        }

        private void RotaryWheelDemo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var rotaryWheel = (RotaryWheel)sender;
            switch (e.PropertyName)
            {
                case "SelectedItemValue":
                    {
                        Debug.WriteLine(rotaryWheel.SelectedItemValue);
                        break;
                    }
            }

        }
        private void spinButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedIndex < 0)
            {
                new Result("Please select result")
                {
                    Title = "ERROR"
                }.ShowAsync();
            }
            else
                rotaryWheelDemo.Spin(comboBox.SelectedIndex);
        }
        private void TextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            textBoxabc.Text = textBoxabc.Text.Replace("\r\r", "\r");
            rotaryWheelDemo.Slices = textBoxabc.Text.Trim().Split('\r');
        }

        private void ButtonRandom_Click(object sender, RoutedEventArgs e)
        {
            rotaryWheelDemo.Spin2();
        }
    }
}

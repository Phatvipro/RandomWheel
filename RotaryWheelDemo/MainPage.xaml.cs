using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using RotaryWheelUserControl;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace RotaryWheelDemo
{
    public sealed partial class MainPage : Page
    {
        private List<string> slicesList;

        public MainPage()
        {
            this.InitializeComponent();

            slicesList = new List<string>();
            rotaryWheelDemo.Slices = slicesList.ToArray();

            rotaryWheelDemo.PropertyChanged += RotaryWheelDemo_PropertyChanged;
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

        private void UpdateSlicesButton_Click(object sender, RoutedEventArgs e)
        {
            AddTextToSlices();
        }

        private void Input_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                AddTextToSlices();
                e.Handled = true;
            }
        }

        private void AddTextToSlices()
        {
            if (!string.IsNullOrWhiteSpace(input.Text))
            {
                string[] enteredText = input.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                slicesList.AddRange(enteredText);
                rotaryWheelDemo.Slices = slicesList.ToArray();
                input.Text = string.Empty; // Clear the input TextBox
            }
        }

    }
}

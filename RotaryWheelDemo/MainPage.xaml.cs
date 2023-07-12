﻿using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RotaryWheelUserControl;

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
            
            rotaryWheelDemo.Spin(comboBox.SelectedIndex);           
        }
        private void TextBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            rotaryWheelDemo.Slices = textBoxabc.Text.Trim().Split('\r');
        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}

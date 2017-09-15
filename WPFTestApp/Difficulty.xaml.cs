/*
 * Created by SharpDevelop.
 * User: Work
 * Date: 09/13/2017
 * Time: 13:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace WPFTestApp
{
	/// <summary>
	/// Interaction logic for Difficulty.xaml
	/// </summary>
	public partial class Difficulty : Window
	{
		public Difficulty(Archer[] a1)
		{
			InitializeComponent();
            Archer[] BackUp = a1;
		}

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LampSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int value = Convert.ToInt32(Math.Round(LampSlider.Value));
            LampSlider.Value = value;
            LampBox.Text = value.ToString();
        }

        private void LampBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void LampBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int value;
            if (LampBox.Text == "")
            {
                value = 0;
                LampBox.Text = "0";
            }
            else
            {
                value = int.Parse(LampBox.Text);

                if (value > 100)
                {
                    value = 100;
                    LampBox.Text = "100";
                }
                else if (value < 0)
                {
                    value = 0;
                    LampBox.Text = "0";
                }
            }

            LampSlider.Value = value;
        }
    }
    
}
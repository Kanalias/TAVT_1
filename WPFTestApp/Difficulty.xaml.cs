﻿/*
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
        private Archer[] DiffArchers;

		public Difficulty(Archer[] a1)
		{
			InitializeComponent();
            DiffArchers = a1;
            LoadSettings(DiffArchers);
        }

        private void LoadSettings(Archer[] a1)
        {
            ComboP1.Text = a1[0].Mastery;
            ComboP2.Text = a1[1].Mastery;
            ComboP3.Text = a1[2].Mastery;
            ComboP4.Text = a1[3].Mastery;
            ComboP5.Text = a1[4].Mastery;
            ComboP6.Text = a1[5].Mastery;
            ComboP7.Text = a1[6].Mastery;
            ComboP8.Text = a1[7].Mastery;
            LampSlider.Value = GameData.chance;
            P1.Source = a1[0].Flag;
            P2.Source = a1[1].Flag;
            P3.Source = a1[2].Flag;
            P4.Source = a1[3].Flag;
            P5.Source = a1[4].Flag;
            P6.Source = a1[5].Flag;
            P7.Source = a1[6].Flag;
            P8.Source = a1[7].Flag;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DiffArchers[0].Mastery = ComboP1.Text;
            DiffArchers[1].Mastery = ComboP2.Text;
            DiffArchers[2].Mastery = ComboP3.Text;
            DiffArchers[3].Mastery = ComboP4.Text;
            DiffArchers[4].Mastery = ComboP5.Text;
            DiffArchers[5].Mastery = ComboP6.Text;
            DiffArchers[6].Mastery = ComboP7.Text;
            DiffArchers[7].Mastery = ComboP8.Text;
            GameData.chance = Convert.ToInt32(LampBox.Text);
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
            if (LampBox.Text == "" | LampBox.Text == " 0" | LampBox.Text == " ")
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
/*
 * Created by SharpDevelop.
 * User: Work
 * Date: 13.09.2017
 * Time: 11:00
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
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private Archer[] Archers =  new Archer[8];
		private string[] Mast = new string[8];
		private string[] Contry = new string[8];

        private Label[] Counters = new Label[8];
		
		public Window1()
		{
			InitializeComponent();
			InitArchers();
            //InitCounters();
            SpeedText.Text = SpeedSlider.Value.ToString();
		}
		
		private void InitArchers()
		{
			for(int i = 0; i<8; i++)
			{
				Archers[i] = new Archer();
                MyStack.Children.Add(Archers[i].Counter);
			}
		}

        private void InitCounters()
        {
            for (int i=0; i<8; i++)
            {
                Counters[i] = new Label();
                Counters[i].Content = "AZAZA";
                MyStack.Children.Add(Counters[i]);
            }
        }
	
		private void ExitButtonClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
		
		private void ColorsButtonClick(object sender, RoutedEventArgs e)
		{
			Window Color = new Colors();
			Color.Show();
		}
		
		private void DifficultyButtonCLick(object sender, RoutedEventArgs e)
		{
			Window Difficulty = new Difficulty();
			Difficulty.Show();
		}
		
		
		void StartButtonClick(object sender, RoutedEventArgs e)
		{
			
		}
		void PauseButonCLick(object sender, RoutedEventArgs e)
		{
	
		}
		void window1_Loaded(object sender, RoutedEventArgs e)
		{
			
		}
		void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			int value = Convert.ToInt32(Math.Round(SpeedSlider.Value));
			SpeedSlider.Value = value;
			SpeedText.Text = value.ToString();
		}
		
		void SpeedText_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!char.IsDigit(e.Text,e.Text.Length-1))
			{
				e.Handled = true;
			}
		}
		void SpeedText_TextChanged(object sender, TextChangedEventArgs e)
		{
			
			int value;
			if (SpeedText.Text == "")
			{
				value = 0;
				SpeedText.Text = "0";
			}
			else 
			{
				value = int.Parse(SpeedText.Text);
				
				if (value >100)
				{
					value = 100;
					SpeedText.Text = "100";
				}
				else if (value <0)
				{
					value = 0;
					SpeedText.Text = "0";
				}
			}
	
			SpeedSlider.Value = value;
		}
	}


	
	
}
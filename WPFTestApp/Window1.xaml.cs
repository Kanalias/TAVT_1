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
using System.Windows.Shapes;
using System.Threading;

namespace WPFTestApp
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private Archer[] Archers =  new Archer[8];
        private bool pause;
        //public static int chance;


		
		public Window1()
		{
			InitializeComponent();
            GameData.InitColors();
            GameData.chance = 0;
            InitArchers();
            SpeedText.Text = SpeedSlider.Value.ToString();
		}
		
		private void InitArchers()
		{
			for(int i = 0; i<8; i++)
			{
				Archers[i] = new Archer(i);
                MyStack.Children.Add(Archers[i].Counter);
			}
		}

        private void StartShooting()
        {
            
        }
	
        private void StopShooting()
        {

        }

        private void PauseShooting()
        {

        }

		private void ExitButtonClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
		
		private void ColorsButtonClick(object sender, RoutedEventArgs e)
		{
			Window Color = new Colors(Archers);
			Color.Show();
		}
		
		private void DifficultyButtonCLick(object sender, RoutedEventArgs e)
		{
			Window Difficulty = new Difficulty(Archers);
			Difficulty.ShowDialog();
            
		}
		
		
		void StartButtonClick(object sender, RoutedEventArgs e)
		{
            if (StartButton.Content.ToString() == "Start")
            {
                for (int i=0;i<=7;i++)
                {
                    Archers[i].Count = 0;
                    Archers[i].Counter.Text = "0";
                }
                StartButton.Content = "Stop";
                StartShooting();
            }
            else
            {
                StartButton.Content = "Start";
                StopShooting();
                for (int i = 0; i <= 7; i++)
                {
                    Archers[i].Count = 0;
                    Archers[i].Counter.Text = "0";
                }

            }

        }

        /*private void Shoot()    //Метод Shoot прогоняет 10 выстрелов
        {
            for (int i = 1; i<=1; i++)
            {
                for (int j = 0;j<=3;j++)
                {
                    int range = 0;
                    int grad = 0;
                    int xc = 165;
                    int yc = 165;
                    Random rnd = new Random();
                    range = rnd.Next(0, 165);
                    grad = rnd.Next(0, 360);
                    Point.Width = 4;
                    Point.Height = 4;
                    Point.Margin = new Thickness(xc + Math.Cos(grad)*range -2 ,yc - Math.Sin(grad)*range - 2,xc - Math.Cos(grad)*range - 2,yc + Math.Sin(grad)*range - 2);
                    Archers[j].Count += Math.Abs(range/15 - 10);
                    Archers[j].Counter.Text = Archers[j].Count.ToString();
                }
                MessageBox.Show("End of competition");
            }
        }*/

		void PauseButonCLick(object sender, RoutedEventArgs e)
		{
	        if (PauseButton.Content.ToString() == "Pause")
            {
                PauseButton.Content = "Continue";
                PauseShooting();
            }
            else
            {
                PauseButton.Content = "Pause";
            }
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
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
using System.Windows.Threading;

namespace WPFTestApp
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		private Archer[] Archers =  new Archer[8];
        private bool pause;
        private DispatcherTimer timer;
        private int currentArcher;
        private Boolean GameIsOver;
        private const double deg = 0.0174533;
        private const int delay = 10;
        //public static int chance;


		
		public Window1()
		{
			InitializeComponent();
            GameData.InitColors();
            GameData.chance = 0;
            InitArchers();
            SpeedText.Text = SpeedSlider.Value.ToString();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(delay + SpeedSlider.Value * 10);
            timer.IsEnabled = false;
            timer.Tick += Timer_Tick;
        }
		
		private void InitArchers()
		{
			for(int i = 0; i<8; i++)
			{
				Archers[i] = new Archer(i);
                MyStack.Children.Add(Archers[i].VisualCounter);
                StackCountry.Children.Add(Archers[i].VisualCountry);
			}
		}

        private void StartShooting()
        {
            currentArcher = 0;
            pause = false;
            timer.Start();
            Settings.IsEnabled = false;
            timer.IsEnabled = true;
            GameIsOver = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentArcher == 0 && Archers[currentArcher].shoots == GameData.Shoots)
            {
                int max = Archers[0].Count;
                int indmax = 0;
                for (int i = 0; i<=7;i++)
                {
                    if(Archers[i].Count>max)
                    {
                        max = Archers[i].Count;
                        indmax = i;
                    }
                }
                Window Results = new Results(Archers);
                Results.ShowDialog();
                //MessageBox.Show("End of competition. Winner is " + Archers[indmax].Country + " with " + Archers[indmax].Count.ToString() +" points");
                StopShooting();
            }
            else if (pause == false)
                {
                    if (Archers[currentArcher].shoots != GameData.Shoots)
                    {
                        Shoot(currentArcher);
                        Archers[currentArcher].shoots++;
                        if (currentArcher == 7)
                        {
                            currentArcher = 0;
                        }
                        else
                        {
                            currentArcher++;
                        }
                    }
                }
            //throw new NotImplementedException();
        }

        private void StopShooting()
        {
            timer.IsEnabled = false;
            for (int i = 0; i<=7; i++)
            {
                Archers[i].PointsList.Clear();
            }
            currentArcher = 0;
            Settings.IsEnabled = true;
            GameIsOver = true;
            Point.Width = 0;
            Point.Height = 0;
        }

        private void PauseShooting()
        {
            if (!GameIsOver)
            {
                pause = !pause;
                timer.IsEnabled = !timer.IsEnabled;
            }
        }

		private void ExitButtonClick(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
		
		private void ColorsButtonClick(object sender, RoutedEventArgs e)
		{
			Window Color = new Colors(Archers);
			Color.ShowDialog();
            for (int i = 0; i <= 7; i++)
            {
                Archers[i].VisualCountry.Content = Archers[i].Country;
            }
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
                for (int i = 0; i <= 7; i++)
                {
                    Archers[i].Count = 0;
                    //Archers[i].Counter.Text = "0";
                    Archers[i].VisualCounter.Content = "0";
                    Archers[i].shoots = 0;
                }
                StartButton.Content = "Stop";
                StartShooting();
            }
            else
            {
                StartButton.Content = "Start";
                for (int i = 0; i <= 7; i++)
                {
                    Archers[i].Count = 0;
                    Archers[i].VisualCounter.Content = "0";
                    Archers[i].shoots = 0;
                }
                StopShooting();
            }

        }

        private void Shoot(int archer)    //Метод Shoot прогоняет 10 выстрелов
        {
                    int range = 0;
                    int grad = 0;
                    int xc = 165;
                    int yc = 165;
            int pts = 0;
                    Random rnd = new Random();
            Point.Height = 4;
            Point.Width = 4;
            switch (Archers[archer].Mastery)
            {
                case "Novice":
                    range = rnd.Next(0, 165);
                    break;
                case "Master":
                    range = rnd.Next(0, 135);
                    break;
                case "Champion":
                    range = rnd.Next(0, 105);
                    break;
            }
            grad = rnd.Next(0, 360);
            bool lamp = rnd.Next(0, 100000000) <= GameData.chance * 1000000;
            if (lamp)
            {
                int lampgrad = rnd.Next(0, 360);
                int lamprange = rnd.Next(0, 30);
                LampLabel.Content = "Lamp Activated";
                int xLeft = (int)Math.Round(xc + Math.Cos(grad*deg) * range + Math.Cos(lampgrad*deg) * lamprange);
                int xRight = (int)Math.Round(xc - Math.Cos(grad*deg) * range - Math.Cos(lampgrad*deg) * lamprange);
                int yUp = (int)Math.Round(yc - Math.Sin(grad*deg) * range - Math.Sin(lampgrad*deg) * lamprange);
                int yLow = (int)Math.Round(yc + Math.Sin(grad*deg) * range + Math.Sin(lampgrad*deg) * lamprange);
                Point.Margin = new Thickness(xLeft-2, yUp-2, xRight-2, yLow-2);
                int newrange = (int)Math.Round(Math.Sqrt(Math.Pow(xLeft-xc, 2) + Math.Pow(yUp-yc, 2)));
                pts = Math.Abs(newrange / 15 - 10);
                Archers[archer].Count += pts;
            }
            else
            {
                Point.Margin = new Thickness(xc + Math.Cos(grad*deg) * range - 2, yc - Math.Sin(grad*deg) * range - 2, xc - Math.Cos(grad*deg) * range - 2, yc + Math.Sin(grad*deg) * range - 2);
                pts = Math.Abs(range / 15 - 10);
                Archers[archer].Count += pts;
            }
            Archers[archer].VisualCounter.Content = Archers[archer].Count.ToString();
            Archers[archer].PointsList.Add(pts);
        }

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
                PauseShooting();
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
            timer.Interval = TimeSpan.FromMilliseconds(delay + Convert.ToInt32(SpeedSlider.Value)*10);
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
			if (SpeedText.Text == "" | SpeedText.Text == " 0" | SpeedText.Text == " ")
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

        private void RulesBtn_Click(object sender, RoutedEventArgs e)
        {
            Window rules = new Rules();
            rules.ShowDialog();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            Window About = new About();
            About.ShowDialog();
        }
    }


	
	
}
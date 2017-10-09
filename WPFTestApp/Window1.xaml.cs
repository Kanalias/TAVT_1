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
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Media;

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
        private int delay = 1001;
        private settings settings = new settings();
        private int speed;
        private DispatcherTimer ErrorTimer = new DispatcherTimer();
        //public static int chance;


		
		public Window1()
		{
			InitializeComponent();
            GameData.InitColors();
            GameData.chance = 0;
            InitArchers();
            SpeedText.Text = SpeedSlider.Value.ToString();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(delay - SpeedSlider.Value * 10);
            timer.Start();
            timer.IsEnabled = false;
            timer.Tick += Timer_Tick;
            ErrorTimer.Interval = TimeSpan.FromSeconds(1);
            ErrorTimer.Tick += ErrorTimer_Tick;
            GameIsOver = true;
        }

        private void ErrorTimer_Tick(object sender, EventArgs e)
        {
            ErrorLabel.Content = "";
            ErrorTimer.Stop();
            //throw new NotImplementedException();
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
            speed = Convert.ToInt32(SpeedSlider.Value);
            //pause = false;
            //timer.Start();
            Settings.IsEnabled = false;
            FileOpt.IsEnabled = false;
            Help.IsEnabled = false;
            timer.IsEnabled = true;
            //if (PauseButton.Content.ToString() == "Continue")
            //{
            //    PauseShooting();
            //    //PauseButton.Content = "Pause";
            //}
            GameIsOver = false;
        }

        private void StopShooting()
        {
            //timer.IsEnabled = false;
            for (int i = 0; i <= 7; i++)
            {
                Archers[i].PointsList.Clear();
            }
            currentArcher = 0;
            Settings.IsEnabled = true;
            FileOpt.IsEnabled = true;
            Help.IsEnabled = true;
            Point.Width = 0;
            Point.Height = 0;
            PartFlag.Source = null;
            PartName.Content = "";
            PartCount.Content = "";
            PartMastery.Content = "";
            PartPts.Content = "";
            LampRange.Content = "";
            SpeedSlider.Value = speed;
            GameIsOver = true;
            timer.IsEnabled = false;
            if (PauseButton.Content.ToString() == "Continue")
            {
                PauseShooting();
                //PauseButton.Content = "Pause";
            }
        }

        private void PauseShooting()
        {
            if (PauseButton.Content.ToString() == "Pause")
            {
                PauseButton.Content = "Continue";
                pause = true;
                Help.IsEnabled = true;
                timer.IsEnabled = false;
            }
            else
            {
                PauseButton.Content = "Pause";
                pause = false;
                Help.IsEnabled = false;
                if (!GameIsOver) timer.IsEnabled = true;
            }
            //if (!GameIsOver)
            //{
            //    pause = !pause;
            //    timer.IsEnabled = !timer.IsEnabled;
            //}
        }

        void PauseButonCLick(object sender, RoutedEventArgs e)
        {
            PauseShooting();
            //if (PauseButton.Content.ToString() == "Pause")
            //{
            //    PauseButton.Content = "Continue";
            //    PauseShooting();
            //}
            //else
            //{
            //    PauseButton.Content = "Pause";
            //    PauseShooting();
            //}
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            LampRange.Content = "";
            ArrowLine.Visibility = Visibility.Hidden;
            ArrowLowCap.Visibility = Visibility.Hidden;
            ArrowUpCap.Visibility = Visibility.Hidden;
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
                //StopShooting();
                GameIsOver = true;
                timer.IsEnabled = false;
            }
            else if (!pause)
            {
                //timer.IsEnabled = false;
                PartFlag.Source = Archers[currentArcher].Flag;
                PartName.Content = Archers[currentArcher].Country;
                PartCount.Content = "Счет: " + Archers[currentArcher].Count;
                PartMastery.Content = Archers[currentArcher].Mastery;
                //LampLabel.Content = "";
                //LampLabel.IsEnabled = false;
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
                //Thread.Sleep(timer.Interval);
                //timer.IsEnabled = true;
            }
            //throw new NotImplementedException();
            
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
            ChanceLabel.Content = "Current chance of wind is: " + GameData.chance.ToString() + "%";

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
                    range = rnd.Next(0, 166);
                    break;
                case "Master":
                    range = rnd.Next(0, 136);
                    break;
                case "Champion":
                    range = rnd.Next(0, 106);
                    break;
            }
            grad = rnd.Next(0, 361);
            bool lamp = rnd.Next(0, 100000000) <= GameData.chance * 1000000;
            if (lamp)
            {
                int lampgrad = rnd.Next(0, 361);
                int lamprange = rnd.Next(0, 31);
                //LampLabel.Content = "Появился ветер";
                //LampLabel.IsEnabled = true;
                DrawLampLine(lamprange, lampgrad);
                LampRange.Content = (lamprange/15).ToString();
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
            PartPts.Content = "Попал в: " + pts.ToString();
        }

        private void DrawLampLine(int range, int grad)
        {
            ArrowLine.Visibility = Visibility.Visible;
            ArrowUpCap.Visibility = Visibility.Visible;
            ArrowLowCap.Visibility = Visibility.Visible;
            ArrowLine.X2 = range * Math.Cos(grad * deg) + 30;
            ArrowLine.Y2 = range * Math.Sin(grad * deg) + 30;
            ArrowLowCap.X1 = ArrowLine.X2;
            ArrowLowCap.Y1 = ArrowLine.Y2;
            ArrowUpCap.X1 = ArrowLine.X2;
            ArrowUpCap.Y1 = ArrowLine.Y2;
            ArrowLowCap.X2 = (range-4) * Math.Cos((grad - 15) * deg) + 30;
            ArrowLowCap.Y2 = (range-4) * Math.Sin((grad - 15) * deg) + 30;
            ArrowUpCap.X2 = (range-4) * Math.Cos((grad + 15) * deg) + 30;
            ArrowUpCap.Y2 = (range-4) * Math.Sin((grad + 15) * deg) + 30;
        }

		void SpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			int value = Convert.ToInt32(Math.Round(SpeedSlider.Value));
			SpeedSlider.Value = value;
			SpeedText.Text = value.ToString();
            timer.Interval = TimeSpan.FromMilliseconds(delay - Convert.ToInt32(SpeedSlider.Value)*10);
		}
		
		void SpeedText_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
            if (!char.IsDigit(e.Text, e.Text.Length - 1) | e.Text.ToString()[0] == ' ') 
			{
                SystemSounds.Beep.Play();
                ErrorLabel.Content = "Wrong button";
                ErrorTimer.Start();
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
                SystemSounds.Beep.Play();
            }
			else 
			{
				value = int.Parse(SpeedText.Text);
				
				if (value >100)
				{
					value = 100;
					SpeedText.Text = "100";
                    ErrorLabel.Content = "Wrong number";
                    ErrorTimer.Start();
                    //SystemSounds.Beep.Play();
                }
				//else if (value <0)
				//{
				//	value = 0;
				//	SpeedText.Text = "0";
    //                SystemSounds.Beep.Play();
    //            }
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

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Json file (*.json)|*.json"};
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (saveFileDialog.ShowDialog() == true)
            {
                for (int i = 0; i < 8; i++)
                {
                    settings.save[i].Country = Archers[i].Country;
                    settings.save[i].Flag_id = Archers[i].Flag_id;
                    settings.save[i].Mastery = Archers[i].Mastery;
                }
                settings.saveChance = GameData.chance;
                File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(settings));
            }

        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Json file (*.json)|*.json" };
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialog.ShowDialog() == true)
            {
                settings = JsonConvert.DeserializeObject<settings>(File.ReadAllText(openFileDialog.FileName));
                for (int i=0; i<8; i++)
                {
                    Archers[i].Country = settings.save[i].Country;
                    Archers[i].Flag_id = settings.save[i].Flag_id;
                    Archers[i].Mastery = settings.save[i].Mastery;
                    Archers[i].VisualCountry.Content = settings.save[i].Country;
                    int id = Archers[i].Flag_id;
                    Archers[i].Flag = GameData.Flags[id].FlagPath;
                }
                GameData.chance = settings.saveChance;
                ChanceLabel.Content = "Current chance of wind is: " + GameData.chance.ToString() + "%";
            }
        }

        private void SpeedText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                SystemSounds.Beep.Play();
                ErrorLabel.Content = "Wrong button";
                ErrorTimer.Start();
                e.Handled = true;
            }
        }
    }	
}
/*
 * Created by SharpDevelop.
 * User: Work
 * Date: 09/13/2017
 * Time: 13:11
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
using System.Media;
using System.Windows.Threading;

namespace WPFTestApp
{
	/// <summary>
	/// Interaction logic for Colors.xaml
	/// </summary>
    /// 

	public partial class Colors : Window
	{
        private Archer[] DiffArchers; // Приходят за информацией
        private Image[] FLagLinks = new Image[8]; //Связывает окна флагов
        //private int[] RandomArray = new int[16]; // Держит в себе массив доступных
        private List<int> CountriesList = new List<int>();
        //private int count = 0; //Число доступных флагов
        private int[] EndArr = new int[8]; //Индексы флагов в геймдате
        private int[] EnterArray = new int[8]; //Массив входных id флагов для отмены
        private List<string> ComboText = new List<string>();
        private ComboBox[] ComboLinks = new ComboBox[8];
        private DispatcherTimer ErrorTimer = new DispatcherTimer();

        public Colors(Archer[] a1)
        {
            InitializeComponent();
            DiffArchers = a1;
            LoadSettings();
            ErrorTimer.Interval = TimeSpan.FromSeconds(1);
            ErrorTimer.Tick += ErrorTimer_Tick;
        }

        private void ErrorTimer_Tick(object sender, EventArgs e)
        {
            ErrorTimer.Stop();
            ErrorLabel.Content = "";
            //throw new NotImplementedException();
        }

        private void LoadSettings()
        {
            int i = 0;
            for (i = 0; i<=15; i++)
            {
                ComboText.Add(GameData.Flags[i].FlagName);
                GameData.Flags[i].IsFree = true;
            }
            P1.Source = DiffArchers[0].Flag;
            P2.Source = DiffArchers[1].Flag;
            P3.Source = DiffArchers[2].Flag;
            P4.Source = DiffArchers[3].Flag;
            P5.Source = DiffArchers[4].Flag;
            P6.Source = DiffArchers[5].Flag;
            P7.Source = DiffArchers[6].Flag;
            P8.Source = DiffArchers[7].Flag;
            FLagLinks[0] = P1;
            FLagLinks[1] = P2;
            FLagLinks[3] = P4;
            FLagLinks[4] = P5;
            FLagLinks[2] = P3;
            FLagLinks[5] = P6;
            FLagLinks[6] = P7;
            FLagLinks[7] = P8;
            ComboLinks[0] = ComboP1;
            ComboLinks[1] = ComboP2;
            ComboLinks[2] = ComboP3;
            ComboLinks[3] = ComboP4;
            ComboLinks[4] = ComboP5;
            ComboLinks[5] = ComboP6;
            ComboLinks[6] = ComboP7;
            ComboLinks[7] = ComboP8;
            
            for (i =0; i<8;i++)
            {
                int current = DiffArchers[i].Flag_id;
                EnterArray[i] = current;
                EndArr[i] = current;
                ComboLinks[i].ItemsSource = ComboText;
                ComboLinks[i].SelectedIndex = current;
                GameData.Flags[current].IsFree = false;
            }
        }


        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i<=15; i++)
            {
                GameData.Flags[i].IsFree = true;
            }
            for (int i = 0; i<=7; i++)
            {
                DiffArchers[i].Flag = GameData.Flags[EnterArray[i]].FlagPath;
                DiffArchers[i].Country = GameData.Flags[EnterArray[i]].FlagName;
                DiffArchers[i].Flag_id = EnterArray[i];
                GameData.Flags[EnterArray[i]].IsFree = false;
            }
            this.Close();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i=0;i<=7;i++)
            {
                DiffArchers[i].Flag = GameData.Flags[EndArr[i]].FlagPath;
                DiffArchers[i].Country = GameData.Flags[EndArr[i]].FlagName;
                GameData.Flags[EndArr[i]].IsFree = true;
                DiffArchers[i].Flag_id = EndArr[i];
            }
            this.Close();
        }

        //private void generateArr()
        //{
        //    count = 0;
        //    CountriesList.Clear();
        //    for (int i = 0;i<=8; i++)
        //    {
        //        if (GameData.Flags[i].IsFree)
        //        {
        //            //RandomArray[count] = i;
        //            //count++;
        //            CountriesList.Add(i);
        //        }
        //    }
        //}

        private void RandomBtn_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            CountriesList.Clear();
            for (i = 0; i<=15; i++)
            {
                GameData.Flags[i].IsFree = true;
                CountriesList.Add(i);
            }
            Random rnd = new Random();
            for (i = 0; i<=7; i++)
            {
                //generateArr();
                //int current = rnd.Next(0, count);
                //FLagLinks[i].Source = GameData.Flags[RandomArray[current]].FlagPath;
                //ComboLinks[i].SelectedIndex = RandomArray[current];
                //GameData.Flags[RandomArray[current]].IsFree = false;
                //EndArr[i] = RandomArray[current];
                int current = rnd.Next(0, CountriesList.Count);
                ComboLinks[i].SelectedIndex = CountriesList[current];
                EndArr[i] = CountriesList[current];
                CountriesList.RemoveAt(current);
            }
        }

        //private void SomeContextMenuOpening(object sender, EventArgs e)
        //{
        //    generateArr();
        //    ComboBox Combo = sender as ComboBox;
        //    Combo.Items.Clear();
        //    for (int i = 0; i<count; i++)
        //    {
        //        Combo.Items.Insert(i,GameData.Flags[RandomArray[i]].FlagName);
        //    }
        //    Combo.Items.Refresh();
        //}

        private void ChangeCountry(object sender, SelectionChangedEventArgs e)
        {
            ComboBox Combo = sender as ComboBox;
            int Item = Convert.ToInt32(Combo.Tag);
            //if (Combo.SelectedIndex == -1)
            //{
            //    e.Handled = true;
            //}
            //else
            //{
                //int selected = RandomArray[Combo.SelectedIndex];
                //GameData.Flags[EndArr[Item]].IsFree = true;
                //FLagLinks[Item].Source = GameData.Flags[selected].FlagPath;
                //EndArr[Item] = selected;
                //GameData.Flags[selected].IsFree = false;

                int selected = Combo.SelectedIndex;
                if (GameData.Flags[selected].IsFree)
                {
                    GameData.Flags[EndArr[Item]].IsFree = true;
                    FLagLinks[Item].Source = GameData.Flags[selected].FlagPath;
                    EndArr[Item] = selected;
                    GameData.Flags[selected].IsFree = false;
                }
                else
                {
                //MessageBox.Show("Эта страна уже используется");
                ErrorLabel.Content = "This country is already in use";
                ErrorTimer.Start();
                Combo.SelectedIndex = EndArr[Item];
                SystemSounds.Beep.Play();
                }
            //}
        }

        private void DefaultBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i<=15;i++)
            {
                GameData.Flags[i].IsFree = true;
            }
            for (int i = 0; i<8; i++)
            {
                FLagLinks[i].Source = GameData.Flags[i].FlagPath;
                ComboLinks[i].SelectedIndex = i;
                GameData.Flags[i].IsFree = false;
                EndArr[i] = i;
            }
        }
    }
}
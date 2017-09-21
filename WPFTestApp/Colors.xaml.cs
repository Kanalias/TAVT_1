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

namespace WPFTestApp
{
	/// <summary>
	/// Interaction logic for Colors.xaml
	/// </summary>
	public partial class Colors : Window
	{
        private Archer[] DiffArchers; // Приходят за информацией
        private Image[] FLagLinks = new Image[8]; //Связывает окна флагов
        private int[] RandomArray = new int[16]; // Держит в себе массив доступных
        private int count = 0; //Число доступных флагов
        private int[] EndArr = new int[8]; //Индексы флагов в геймдате
        private int[] EnterArray = new int[8]; //Массив входных id флагов для отмены

        public Colors(Archer[] a1)
        {
            InitializeComponent();
            DiffArchers = a1;
            LoadSettings();
        }

        private void LoadSettings()
        {
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
            FLagLinks[2] = P3;
            FLagLinks[3] = P4;
            FLagLinks[4] = P5;
            FLagLinks[5] = P6;
            FLagLinks[6] = P7;
            FLagLinks[7] = P8;
            ComboP1.Text = DiffArchers[0].Country;
            ComboP2.Text = DiffArchers[1].Country;
            ComboP3.Text = DiffArchers[2].Country;
            ComboP4.Text = DiffArchers[3].Country;
            ComboP5.Text = DiffArchers[4].Country;
            ComboP6.Text = DiffArchers[5].Country;
            ComboP7.Text = DiffArchers[6].Country;
            ComboP8.Text = DiffArchers[7].Country;
            for (int i=0;i<=7;i++)
            {
                EnterArray[i] = DiffArchers[i].Flag_id;
            }
            EndArr = EnterArray;
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
                GameData.Flags[EndArr[i]].IsFree = false;
                DiffArchers[i].Flag_id = EndArr[i];
            }
            this.Close();
        }

        private void generateArr()
        {
            count = 0;
            for (int i = 0;i<=15; i++)
            {
                if (GameData.Flags[i].IsFree)
                {
                    RandomArray[count] = i;
                    count++;
                }
            }
        }

        private void RandomBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i<=15; i++)
            {
                GameData.Flags[i].IsFree = true;
            }
            Random rnd = new Random();
            for (int i = 0; i<=7; i++)
            {
                generateArr();
                int current = rnd.Next(0, count);
                FLagLinks[i].Source = GameData.Flags[RandomArray[current]].FlagPath;
                GameData.Flags[RandomArray[current]].IsFree = false;
                EndArr[i] = RandomArray[current];
            }
        }

        private void SomeContextMenuOpening(object sender, EventArgs e)
        {
            generateArr();
            ComboBox Combo = sender as ComboBox;
            Combo.Items.Clear();
            for (int i = 0; i<count; i++)
            {
                Combo.Items.Insert(i,GameData.Flags[RandomArray[i]].FlagName);
            }
            Combo.Items.Refresh();
        }

        private void ChangeCountry(object sender, SelectionChangedEventArgs e)
        {
            ComboBox Combo = sender as ComboBox;
            int Item = Convert.ToInt32(Combo.Tag);
            if (Combo.SelectedIndex == -1)
            {
                e.Handled = true;
            }
            else
            {
                int selected = RandomArray[Combo.SelectedIndex];
                GameData.Flags[EndArr[Item]].IsFree = true;
                FLagLinks[Item].Source = GameData.Flags[selected].FlagPath;
                EndArr[Item] = selected;
                GameData.Flags[selected].IsFree = false;
            }
        }
    }
}
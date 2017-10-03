using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFTestApp
{
    /// <summary>
    /// Логика взаимодействия для Results.xaml
    /// </summary>
    public partial class Results : Window
    {
        private struct Player
        {
            public int count;
            public int place;
        }

        private string winner;

        Player[] player = new Player[8];

        public Results(Archer[] archers)
        {
            InitializeComponent();
            FindWinners(archers);
            DisplayResults(archers);
        }

        private void FindWinners(Archer[] archers)
        {
            int i;
            for (i = 0 ; i <= 7 ; i++ )
            {
                player[i].count = archers[i].Count;
            }
            for (i = 1; i<=8; i++)
            {
                int index = Findmax();
                player[index].place = i;
            }
            i = 0;
            while (player[i].place != 1)
            {
                i++;
            }
            winner = archers[i].Country;
        }

        private int Findmax()
        {
            int max = player[0].count;
            int maxind = 0;
            for (int i = 1; i<=7;i++)
            {
                if (player[i].count > max)
                {
                    max = player[i].count;
                    maxind = i;
                }
            }
            player[maxind].count = 0;
            return maxind;
        }


        private void DisplayResults(Archer[] archer)
        {
            //Player player = new Player();
            //player.Country = new Label { Content = archer[0].Country };
            //player.Points = new Label { Content = archer[0].Count };
            //player.Flag = new Image { Source = archer[0].Flag };
            //player.PointsList = new ListBox();
            //player.PointsList.Items.Add(archer[0].PointsList);
            //player.Place = new Label { Content = "In work" };
            //First.Items.Add(player);
            int i = 0;
            //First
            Part1Country.Content = archer[i].Country;
            Part1Pts.Content = archer[i].Count;
            Part1Img.Source = archer[i].Flag;
            Part1ListPts.ItemsSource = archer[i].PointsList;
            Part1Place.Content = player[i].place;
            i++;
            //Second
            Part2Country.Content = archer[i].Country;
            Part2Pts.Content = archer[i].Count;
            Part2Img.Source = archer[i].Flag;
            Part2ListPts.ItemsSource = archer[i].PointsList;
            Part2Place.Content = player[i].place;
            i++;
            //Third
            Part3Country.Content = archer[i].Country;
            Part3Pts.Content = archer[i].Count;
            Part3Img.Source = archer[i].Flag;
            Part3ListPts.ItemsSource = archer[i].PointsList;
            Part3Place.Content = player[i].place;
            i++;
            //Forth
            Part4Country.Content = archer[i].Country;
            Part4Pts.Content = archer[i].Count;
            Part4Img.Source = archer[i].Flag;
            Part4ListPts.ItemsSource = archer[i].PointsList;
            Part4Place.Content = player[i].place;
            i++;
            //Fifth
            Part5Country.Content = archer[i].Country;
            Part5Pts.Content = archer[i].Count;
            Part5Img.Source = archer[i].Flag;
            Part5ListPts.ItemsSource = archer[i].PointsList;
            Part5Place.Content = player[i].place;
            i++;
            //Sixth
            Part6Country.Content = archer[i].Country;
            Part6Pts.Content = archer[i].Count;
            Part6Img.Source = archer[i].Flag;
            Part6ListPts.ItemsSource = archer[i].PointsList;
            Part6Place.Content = player[i].place;
            i++;
            //Seventh
            Part7Country.Content = archer[i].Country;
            Part7Pts.Content = archer[i].Count;
            Part7Img.Source = archer[i].Flag;
            Part7ListPts.ItemsSource = archer[i].PointsList;
            Part7Place.Content = player[i].place;
            i++;
            //Eighth
            Part8Country.Content = archer[i].Country;
            Part8Pts.Content = archer[i].Count;
            Part8Img.Source = archer[i].Flag;
            Part8ListPts.ItemsSource = archer[i].PointsList;
            Part8Place.Content = player[i].place;

            //Winner field
            Winner.Content = "Winner is: " + winner;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

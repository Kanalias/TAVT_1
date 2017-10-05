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
            public bool Shoot;
            public string reason;
        }

        private string winner;
        private List<int> winners = new List<int>();

        Player[] player = new Player[8];

        public Results(Archer[] archers)
        {
            InitializeComponent();
            for (int i = 0; i<8;i++)
            {
                player[i].count = archers[i].Count;
            }
            FindWinners(archers);
            DisplayResults(archers);
        }

        private void FindWinners(Archer[] archers)
        {
            int currentPlace = 1;
            for (int i = 0; i<8; i++)
            {
                player[i].place = 0;
            }
            while (currentPlace <= 8)
            {
                winners.Clear();
                Findmax();
                if (winners.Count == 1)
                {
                    player[winners[0]].place = currentPlace++;
                    player[winners[0]].reason = "Score";
                }
                else
                {
                    for (int i = 0; i<8;i++)
                    {
                        player[i].Shoot = false;
                    }
                    int currentscore = 10; //Устанавливаем значение для просмотра по счету в 10
                    if (winners.Count == 2) //Случай если у нас всего 2 игрока с одним набором очков
                    {
                        int first = winners[0];
                        int second = winners[1];
                        /*int p1 = archers[first].PointsList.Max();
                        int p2 = archers[second].PointsList.Max();
                        if (p1 > p2) //Если максимум первого больше второго
                        {
                            player[first].place = currentPlace++;
                            player[second].place = currentPlace++;
                            player[first].reason = "MaxShoot";
                            player[second].reason = "MaxShoot";
                        }
                        else if (p1 < p2) //наоброт
                        {
                            player[second].place = currentPlace++;
                            player[first].place = currentPlace++;
                            player[first].reason = "MaxShoot";
                            player[second].reason = "MaxShoot";
                        }
                        else*/
                            //{
                            while (currentscore > 0) //Пойдем от самого верха спускать уровень и смотреть.
                            {
                                player[first].Shoot = archers[first].PointsList.IndexOf(currentscore) != -1;
                                player[second].Shoot = archers[second].PointsList.IndexOf(currentscore) != -1;
                                if (player[first].Shoot ^ player[second].Shoot)
                                {
                                    if (player[first].Shoot)
                                    {
                                        player[first].place = currentPlace++;
                                        currentscore = 0;
                                        player[first].reason = "Max";
                                        player[second].place = currentPlace++;
                                        player[second].reason = "Min";
                                    }
                                    else
                                    {
                                        player[second].place = currentPlace++;
                                        currentscore = 0;
                                        player[second].reason = "Max";
                                        player[first].place = currentPlace++;
                                        player[first].reason = "Min";
                                    }
                                }
                                else currentscore--;
                            }
                            if (player[first].place == 0) //Если мы даже так не нашли разницы, то даем им одинаковые места.
                            {
                                player[first].place = currentPlace;
                                player[first].reason = "Identive";
                                player[second].place = currentPlace;
                                player[first].reason = "Identive";
                                currentPlace += 2;
                            }

                        //}

                    }
                    else if (winners.Count >= 3)
                    {
                        MessageBox.Show("Wait");
                        currentPlace = 9;
                    }
                }
            }

        }

        private void Findmax()
        {
            int max = player[0].count;
            winners.Add(0);
            for (int i = 1; i<=7;i++)
            {
                if (player[i].count > max)
                {
                    max = player[i].count;
                    winners.Clear();
                    winners.Add(i);
                }
                else if (player[i].count == max)
                {
                    winners.Add(i);
                }
            }
            for (int i = 0; i< winners.Count;i++)
            {
                player[winners[i]].count = 0;
            }
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
            Part1Reason.Content = player[i].reason;
            i++;
            //Second
            Part2Country.Content = archer[i].Country;
            Part2Pts.Content = archer[i].Count;
            Part2Img.Source = archer[i].Flag;
            Part2ListPts.ItemsSource = archer[i].PointsList;
            Part2Place.Content = player[i].place;
            Part2Reason.Content = player[i].reason;
            i++;
            //Third
            Part3Country.Content = archer[i].Country;
            Part3Pts.Content = archer[i].Count;
            Part3Img.Source = archer[i].Flag;
            Part3ListPts.ItemsSource = archer[i].PointsList;
            Part3Place.Content = player[i].place;
            Part3Reason.Content = player[i].reason;
            i++;
            //Forth
            Part4Country.Content = archer[i].Country;
            Part4Pts.Content = archer[i].Count;
            Part4Img.Source = archer[i].Flag;
            Part4ListPts.ItemsSource = archer[i].PointsList;
            Part4Place.Content = player[i].place;
            Part4Reason.Content = player[i].reason;
            i++;
            //Fifth
            Part5Country.Content = archer[i].Country;
            Part5Pts.Content = archer[i].Count;
            Part5Img.Source = archer[i].Flag;
            Part5ListPts.ItemsSource = archer[i].PointsList;
            Part5Place.Content = player[i].place;
            Part5Reason.Content = player[i].reason;
            i++;
            //Sixth
            Part6Country.Content = archer[i].Country;
            Part6Pts.Content = archer[i].Count;
            Part6Img.Source = archer[i].Flag;
            Part6ListPts.ItemsSource = archer[i].PointsList;
            Part6Place.Content = player[i].place;
            Part6Reason.Content = player[i].reason;
            i++;
            //Seventh
            Part7Country.Content = archer[i].Country;
            Part7Pts.Content = archer[i].Count;
            Part7Img.Source = archer[i].Flag;
            Part7ListPts.ItemsSource = archer[i].PointsList;
            Part7Place.Content = player[i].place;
            Part7Reason.Content = player[i].reason;
            i++;
            //Eighth
            Part8Country.Content = archer[i].Country;
            Part8Pts.Content = archer[i].Count;
            Part8Img.Source = archer[i].Flag;
            Part8ListPts.ItemsSource = archer[i].PointsList;
            Part8Place.Content = player[i].place;
            Part8Reason.Content = player[i].reason;

            //Winner field
            i = 0;
            while (winner == null)
            {

                if (player[i].place == 1) winner = archer[i].Country;
                else i++;
            }
            Winner.Content = "Winner is: " + winner;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

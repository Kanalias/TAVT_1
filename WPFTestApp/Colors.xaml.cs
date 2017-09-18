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
        private Archer[] DiffArchers;
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
        }
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RandomBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
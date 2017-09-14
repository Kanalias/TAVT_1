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
		public Colors()
		{
			InitializeComponent();
		}
		
		private void ColorsExitButton(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
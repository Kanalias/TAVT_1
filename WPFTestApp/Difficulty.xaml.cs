﻿/*
 * Created by SharpDevelop.
 * User: Work
 * Date: 09/13/2017
 * Time: 13:26
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
	/// Interaction logic for Difficulty.xaml
	/// </summary>
	public partial class Difficulty : Window
	{
		public Difficulty()
		{
			InitializeComponent();
		}
		void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
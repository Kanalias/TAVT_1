﻿/*
 * Created by SharpDevelop.
 * User: Work
 * Date: 09/13/2017
 * Time: 18:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFTestApp
{
	/// <summary>
	/// Description of Archer.
	/// </summary>
	public class Archer
	{
		public string Country;
		public int Count;
		public string Mastery;
		public int shoots;
        //public TextBlock Counter;
        public Label VisualCounter;
        public ImageSource Flag;
        public Label VisualCountry;
		
		public Archer(int id)
		{
			Count = 0;
			Mastery = "Novice";
			Country = GameData.Flags[id].FlagName;
            Flag = GameData.Flags[id].FlagPath;
			shoots = 0;
            VisualCounter = new Label();
            VisualCounter.Content = Count.ToString();
            //Counter = new TextBlock();
            //Counter.Text = "0";
            //Counter.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            //Counter.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            //Counter.Height = 30;
            //Counter.Margin = new System.Windows.Thickness(5, 0, 30, 14.5);
            VisualCountry = new Label();
            VisualCountry.Content = Country;
		}
		
	}
}

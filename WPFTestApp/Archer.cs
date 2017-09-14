/*
 * Created by SharpDevelop.
 * User: Work
 * Date: 09/13/2017
 * Time: 18:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Controls;

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
        public TextBlock Counter;
		
		public Archer()
		{
			Count = 0;
			Mastery = "";
			Country = "";
			shoots = 0;
            Counter = new TextBlock();
            Counter.Text = "0";
            Counter.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Counter.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            //Counter.Height = 30;
            Counter.Margin = new System.Windows.Thickness(5, 0, 30, 14.5);
		}
		
	}
}

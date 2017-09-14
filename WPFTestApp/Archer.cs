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
		private string Country;
		public int Count;
		private string Mastery;
		public int shoots;
        public Label Counter;
		
		public Archer()
		{
			Count = 0;
			Mastery = "";
			Country = "";
			shoots = 0;
            Counter = new Label();
            Counter.Content = "0";
		}
		
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.IO;

namespace WPFTestApp
{
    static class GameData
    {
        public static int chance;
        public struct Flag
        {
            public ImageSource FlagPath;
            public String FlagName;
            public bool IsFree;
        }
        //public static ImageSource[] Flags = new ImageSource[16];
        public static Flag[] Flags = new Flag[16]; 

        public static void InitColors()
        {

            StreamReader sr = new StreamReader(@"Images/ReadMe.txt");
            for (int i = 0;i<=15;i++)
            {
                Flags[i].FlagPath = new BitmapImage(new Uri(@"Images/" + (i+1).ToString() + ".jpg",UriKind.Relative));
                Flags[i].FlagName = sr.ReadLine();
                Flags[i].IsFree = true;
            }

            for (int i = 0; i<=7; i++)
            {
                Flags[i].IsFree = false;
            }
        }
    }
}

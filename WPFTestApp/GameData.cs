using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Documents;

namespace WPFTestApp
{
    static class GameData
    {
        public static int chance;
        public static ImageSource[] Flags = new ImageSource[16];

        public static void InitColors()
        {
            for (int i = 0;i<=15;i++)
            {
                Flags[i] = new BitmapImage(new Uri(@"Images/" + (i+1).ToString() + ".jpg",UriKind.Relative));
            }
        }
    }
}

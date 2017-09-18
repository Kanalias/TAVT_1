using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                BitmapImage bm = new BitmapImage();
                bm.BeginInit();
                bm.UriSource = new Uri(@"res\" + (i+1).ToString() + ".jpg");
                bm.EndInit();
                Flags[i] = bm;
            }
        }
    }
}

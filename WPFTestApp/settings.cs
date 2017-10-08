using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WPFTestApp
{
    public class settings
    {
        public struct saveArchers
        {
            public string Country;
            public string Mastery;
            //public TextBlock Counter;
            //public Label VisualCounter;
            //public ImageSource Flag;
            //public Label VisualCountry;
            public int Flag_id;
        }
        public int saveChance;
        public saveArchers[] save;

        public settings()
        {
            saveChance = GameData.chance;
            save = new saveArchers[8];
        }
    }
}


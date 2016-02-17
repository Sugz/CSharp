using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Renamer
{

    public class ItemDG
    {
        public int Number { get; set; }

        public string Text { get; set; }

        public string DotExt { get; set; }

        public bool Checked { get; set; }

        public List<ItemDG> Files { get; set; }


        public ItemDG(int number, string text)
        {
            Number = number;
            Text = text;
        }

    }


    public class HistoryItem
    {
        public string Text { get; set; }
        public bool IsChecked { get; set; }

        public HistoryItem(string text, bool isChecked)
        {
            Text = text;
            IsChecked = isChecked;
        }

    }

}
     


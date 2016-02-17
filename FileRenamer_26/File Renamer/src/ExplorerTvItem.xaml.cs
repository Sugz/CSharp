using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace File_Renamer
{
	/// <summary>
	/// Interaction logic for ExplorerTvItem.xaml
	/// </summary>
	public partial class ExplorerTvItem : TreeViewItem
	{
        private Canvas folder  = new Canvas();
        private Canvas openFolder = new Canvas();

		
		public enum NodeType
		{
			Computer,
			Hdd,
			Folder
		}

		public NodeType ItemType { get; set; }


        public List<ItemDG> TVItemFiles { get; set; }

		
		public ExplorerTvItem()
		{
			this.InitializeComponent();
		}
		
		
		public override void OnApplyTemplate()
		{
			Canvas computer = Template.FindName("Computer", this) as Canvas;
			Canvas hdd = Template.FindName("Hdd", this) as Canvas;
            folder = Template.FindName("Folder", this) as Canvas;
            openFolder = Template.FindName("OpenFolder", this) as Canvas;

			switch (this.ItemType)
			{
				case (NodeType.Computer):
					computer.Visibility = Visibility.Visible;
					hdd.Visibility = folder.Visibility = openFolder.Visibility = Visibility.Collapsed;
					break;

				case (NodeType.Hdd):
					hdd.Visibility = Visibility.Visible;
                    computer.Visibility = folder.Visibility = openFolder.Visibility = Visibility.Collapsed;
					break;

				case (NodeType.Folder):
					folder.Visibility = Visibility.Visible;
                    computer.Visibility = hdd.Visibility = openFolder.Visibility = Visibility.Collapsed;
					break;

			}

		}

        private void TV_Expanded(object sender, RoutedEventArgs e)
        {
            if (((ExplorerTvItem)sender).ItemType == NodeType.Folder)
            {
                folder.Visibility = Visibility.Collapsed;
                openFolder.Visibility = Visibility.Visible;
            }
                

        }

        private void TV_Collapsed(object sender, RoutedEventArgs e)
        {
            if (((ExplorerTvItem)sender).ItemType == NodeType.Folder)
            {
                folder.Visibility = Visibility.Visible;
                openFolder.Visibility = Visibility.Collapsed;
            }
                
        }
		
	}
}
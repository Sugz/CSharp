using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for HistoryItem.xaml
    /// </summary>
    public partial class HistoryItems : UserControl
    {

        #region Dependency Properties

        // Define the text property
        public static DependencyProperty HistoryTextProperty = DependencyProperty.Register(
                "HistoryText",
                typeof(String),
                typeof(HistoryItems));


        // Define the IsCheck property
        public static DependencyProperty IsCheckedProperty = DependencyProperty.Register(
            "IsChecked",
            typeof(Boolean),
            typeof(HistoryItems));


        #endregion



        #region Members

        // Define the text property
        [Description("Define the Text."), Category("Common"), Bindable(true)]
        public string HistoryText
        {
            get { return (String)GetValue(HistoryTextProperty); }
            set { SetValue(HistoryTextProperty, value); }
        }


        // Define the IsChecked property
        [Description("Define the IsChecked Property."), Category("Common"), Bindable(true)]
        public Boolean IsChecked
        {
            get { return (Boolean)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }


        // Defined the HighLightedBlue
        //Brush


        #endregion



        #region Published Events

        public event EventHandler TextMouseUp;


        #endregion



        #region Initialization

        public HistoryItems()
        {
            InitializeComponent();
        }


        #endregion



        #region Private methods

        private void PART_Check_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (IsChecked)
            {
                PART_Check.Fill = Application.Current.FindResource("InvisibleWhite") as SolidColorBrush;
				IsChecked = false;
            }
            else
            {
                PART_Check.Fill = Application.Current.FindResource("HighLightedBlue") as SolidColorBrush;
				IsChecked = true;
            }
        }

		
        private void UserControl_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	PART_Text.Foreground = new SolidColorBrush(Color.FromRgb(230, 230, 230));
        }

        private void UserControl_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
        	PART_Text.Foreground = Application.Current.FindResource("Brush_170_170_170") as SolidColorBrush;
        }


        private void PART_Text_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (TextMouseUp != null)
                TextMouseUp(this, e);
        }


        #endregion

        

    }
}

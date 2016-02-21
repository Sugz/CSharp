using System;
using System.Collections.Generic;
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
using Autodesk.Max;

namespace dialogUI
{

    public partial class dialog : UserControl
    {

        System.Windows.Window m_winParent;

        public dialog(System.Windows.Window creator)
        {
            m_winParent = creator;
            InitializeComponent();
        }

        //button events
        private void topArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.DragMove();
        }

        private void formClose_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Close();
        }

        private void formMax_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window.WindowState == WindowState.Normal)
            {
                window.WindowState = WindowState.Maximized;
                return;
            }
            window.WindowState = WindowState.Normal;
        }

        private void formMin_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (window.WindowState == WindowState.Normal)
            {
                window.WindowState = WindowState.Minimized;
                return;
            }
            if (window.WindowState == WindowState.Maximized)
            {
                window.WindowState = WindowState.Minimized;
                return;
            }
            window.WindowState = WindowState.Normal;
        }
    }


}

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

namespace SugarControls.Themes.Sugar
{
    /// <summary>
    /// Interaction logic for SugarWindowStyle.xaml
    /// </summary>
    public partial class SugarWindowStyle : ResourceDictionary
    {
        /// <summary>
        /// Handles the Title Bar mouse left button event. This event handler is used to drag the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PART_TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.DragMove();
        }


        /// <summary>
        /// Handles the Close button event. This event handler is used to close the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            Window window = (Window)((FrameworkElement)sender).TemplatedParent;
            window.Close();
        }
    }
}

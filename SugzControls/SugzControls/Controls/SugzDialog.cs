using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Input;

namespace SugzControls
{
    public class SugzDialog : UserControl
    {

        #region Fields


        // Define the resize rectangle
        private Rectangle leftResize;
        private Rectangle rightResize;


        #endregion

        public SugzDialog()
        {
            Loaded += SugzDialog_Loaded;
        }

        private void SugzDialog_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ResourceDictionary resource = new ResourceDictionary();
            resource.Source = new Uri("/SugzControls;component/Styles/SugzDialogStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)resource["SugzWindowStyle"];
        }


        public override void OnApplyTemplate()
        {
            leftResize = Template.FindName("LeftResize", this) as Rectangle;
            rightResize = Template.FindName("RightResize", this) as Rectangle;


            leftResize.MouseDown += LeftResize_MouseDown;
            rightResize.MouseDown += RightResize_MouseDown;
        }


        private void RightResize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Width += 50;
        }


        private void LeftResize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Width -= 50;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using ManagedServices;

namespace SugzControls
{
    public class SugzWindow : Window
    {
        public SugzWindow()
        {
            Loaded += SugzWindow_Loaded;
            ShowInTaskbar = false;
            WindowInteropHelper windowHandle = new WindowInteropHelper(this);
            windowHandle.Owner = AppSDK.GetMaxHWND();
            AppSDK.ConfigureWindowForMax(this);
            Show();
        }

        private void SugzWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resource = new ResourceDictionary();
            resource.Source = new Uri("/SugzControls;component/Styles/SugzWindowStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)resource["SugzWindowStyle"];
        }
    }
}

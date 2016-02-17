using SugarControls.Interfaces;
using SugarControls.Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SugarControls
{
    public class SugarWindow : Window, ISugarControl
    {

        #region Members

        [Description("Set the Look and Feel of the control"), Category("Appearance")]
        public Theme Theme { get; set; }

        [Description("Set the Icon To be display"), Category("Appearance")]
        public new Icon Icon { get; set; }


        #endregion


        #region Initialization

        public SugarWindow()
        {
            // Set style parts that can't be change after the window is called
            //this.AllowsTransparency = true;
            //this.WindowStyle = WindowStyle.None;

            // Add the Loaded event handler
            this.Loaded += SugarWindow_Loaded;
        }

        void SugarWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the resource containing the Window Style and assign it to the window
            ResourceDictionary _resources = new ResourceDictionary();
            switch (this.Theme)
            {
                case Theme.Owner:
                case Theme.Sugar:
                    _resources.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarWindowStyle.xaml", UriKind.RelativeOrAbsolute);
                    this.Style = (Style)_resources["SugarWindowStyle"];
                    break;
                case Theme.VS:
                    _resources.Source = new Uri("/SugarControls;component/Themes/VS/VSWindowStyle.xaml", UriKind.RelativeOrAbsolute);
                    this.Style = (Style)_resources["VSWindowStyle"];
                    break;
                default:
                    break;
            }


        }

        #endregion

    }
}

using SugarControls.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SugarControls
{
    public class SugarWindow : Window
    {
        #region Members


        [Description("Set the Look and Feel of the control"), Category("Appearance")]
        public Look Look
        {
            get { return (Look)GetValue(DependencyProperties.LookProperty); }
            set { SetValue(DependencyProperties.LookProperty, value); }
        }
        //public Look Look { get; set; }


        #endregion


        #region Initialization

        public SugarWindow()
        {
            // Add the Loaded event handler
            this.Loaded += SugarWindow_Loaded;
        }

        void SugarWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the resource containing the Window Style and assign it to the window
            ResourceDictionary _resources = new ResourceDictionary();

            switch (Look)
            {
                case Look.Sugar:
                    _resources.Source = new Uri("/SugarControls;component/Styles/SugarWindowStyle.xaml", UriKind.RelativeOrAbsolute);
                    this.Style = _resources["SugarWindowStyle"] as Style;
                    //Debug.WriteLine("sugar");
                    break;
                case Look.VS:
                    _resources.Source = new Uri("/SugarControls;component/Styles/VSWindowStyle.xaml", UriKind.RelativeOrAbsolute);
                    this.Style = _resources["VSWindowStyle"] as Style;
                    //Debug.WriteLine("vs");
                    break;
                default:
                    break;
            }

            
        }

        #endregion






        
    }
}

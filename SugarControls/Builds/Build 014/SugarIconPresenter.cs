using SugarControls.Interfaces;
using SugarControls.Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SugarControls
{
    public class SugarIconPresenter : ContentControl, ISugarControl
    {
        #region Members

        /// <summary>
        /// Define the Look (see SugarControls.Sources.Enums Look) to set one of the custom control style
        /// </summary>
        [Description("Set the Look and Feel of the control"), Category("Appearance")]
        public Theme Theme { get; set; }

        /// <summary>
        /// Define wich Icon (see SugarControls.Sources.Enums Icon) to use
        /// </summary>
        [Description("Set the Icon To be display"), Category("Appearance")]
        public Icon Icon { get; set; }


        #endregion


        #region Initialization

        public SugarIconPresenter()
        {
            this.Name = "contentControl";
            this.Loaded += SugarIconPresenter_Loaded;
        }

        void SugarIconPresenter_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the resource containing the Window Style and assign it to the window
            ResourceDictionary _resources = new ResourceDictionary();
            Path _path = new Path();

            switch (this.Theme)
            {
                case Theme.Sugar:
                    _resources.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarIcons.xaml", UriKind.RelativeOrAbsolute);
                    break;
                case Theme.VS:
                    _resources.Source = new Uri("/SugarControls;component/Themes/VS/VSIcons.xaml", UriKind.RelativeOrAbsolute);
                    break;
                case Theme.Owner:
                default:
                    break;
            }
            


            switch (this.Icon)
            {
                case Icon.SugarMain:
                    _resources.Source = new Uri("/SugarControls;component/Styles/Icons.xaml", UriKind.RelativeOrAbsolute);
                    _path.Style = (Style)_resources["SugarMainIcon"];
                    break;
                case Icon.Close:
                    _path.Style = (Style)_resources["CloseIcon"];
                    break;
                case Icon.Maximize:
                    _path.Style = (Style)_resources["MaximizeIcon"];
                    break;
                case Icon.Restore:
                    _path.Style = (Style)_resources["RestoreIcon"];
                    break;
                case Icon.Minimize:
                    _path.Style = (Style)_resources["MinimizeIcon"];
                    break;
                case Icon.None:
                default:
                    this.Visibility = Visibility.Collapsed;
                    break;
            }

            // assign the path as content
            this.Content = _path;
        }


        #endregion

    }
}

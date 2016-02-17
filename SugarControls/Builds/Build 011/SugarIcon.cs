using Autodesk.Max.Plugins;
using SugarControls.Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SugarControls
{
    public class SugarIcon : ContentControl
    {
        #region Members

        /// <summary>
        /// Define the Look (see SugarControls.Sources.Enums Look) to set one of the custom control style
        /// </summary>
        public static DependencyProperty ThemeProperty = DependencyProperty.Register(
            "Theme",
            typeof(Theme),
            typeof(SugarIcon));

        [Description("Set the Look and Feel of the control"), Category("Appearance")]
        public Theme Theme
        {
            get { return (Theme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }



        /// <summary>
        /// Define wich Icon (see SugarControls.Sources.Enums Icon) to use
        /// </summary>
        public static DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon",
            typeof(Icon),
            typeof(SugarIcon));

        [Description("Set the Icon To be display"), Category("Appearance")]
        public Icon Icon
        {
            get { return (Icon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }


        #endregion


        #region Initialization


        public SugarIcon()
        {
            //// check if the theme is suppose to be the one from the window
            //if (this.Theme.Equals(Theme.Owner))
            //{
            //    var _parent = VisualTreeHelper.GetParent(this);
            //    while (!(_parent is SugarWindow))
            //    {
            //        _parent = VisualTreeHelper.GetParent(_parent);
            //    }

            //    this.Theme = (_parent as SugarWindow).Theme;

            //}

            this.Loaded += SugarIcon_Loaded;
        }

        void SugarIcon_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // define a path that will use a style
            Path _path = new Path();

            // Get the resource dictionary containing the Theme
            ResourceDictionary _resources = new ResourceDictionary();
            switch (this.Theme)
            {
                case Theme.Sugar:
                    _resources.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarIcons.xaml", UriKind.RelativeOrAbsolute);
                    break;
                case Theme.VS:
                    _resources.Source = new Uri("/SugarControls;component/Themes/VS/VSIcons.xaml", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    break;
            }

            // Get the selected icon in the store resource dictionary
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
                    break;
            }

            this.Content = _path;

        }


        #endregion
    }
}

using SugarControls.Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SugarControls
{
    public class SugarIconPresenter : ContentControl
    {
        #region Fields

        /// <summary>
        /// Define the Look (see SugarControls.Sources.Enums Look) to set one of the custom control style
        /// </summary>
        private Theme _theme = Theme.Owner;
        [Description("Set the Look and Feel of the control"), Category("Appearance")]
        public Theme Theme
        {
            get { return _theme; }
            set { _theme = value; }
        }

        /// <summary>
        /// Define wich Icon (see SugarControls.Sources.Enums Icon) to use
        /// </summary>
        [Description("Set the Icon To be display"), Category("Appearance")]
        public Icon Icon { get; set; }


        #endregion

        #region Members

        // The resource dictionaire that contain desired style
        ResourceDictionary resources = new ResourceDictionary();

        // The path that will take the style and be the content 
        Path path = new Path();


        #endregion


        #region Construction

        public SugarIconPresenter()
        {
            this.Name = "contentControl";
            this.Loaded += SugarIconPresenter_Loaded;
        }


        private void SugarIconPresenter_Loaded(object sender, RoutedEventArgs e)
        {
            // check if the theme is supposed to be the owner
            if (this.Theme == Theme.Owner)
            {
                this.Theme = CommonMethods.GetTheme(this);
            }

            // Get the resource containing the Window Style and assign it to the window
            //ResourceDictionary _resources = new ResourceDictionary();
            //Path _path = new Path();


            
            //switch (this.Theme)
            //{
            //    case Theme.Sugar:
            //        resources.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarIcons.xaml", UriKind.RelativeOrAbsolute);
            //        break;
            //    case Theme.VS:
            //        resources.Source = new Uri("/SugarControls;component/Themes/VS/VSIcons.xaml", UriKind.RelativeOrAbsolute);
            //        break;
            //    case Theme.Owner:
            //    default:
            //        break;
            //}
            


            switch (this.Icon)
            {
                case Icon.SugarMain:
                    //resources.Source = new Uri("/SugarControls;component/Styles/Icons.xaml", UriKind.RelativeOrAbsolute);
                    //path.Style = (Style)resources["SugarMainIcon"];
                    SetStandardResource("SugarMainIcon");
                    break;
                case Icon.Close:
                    //path.Style = (Style)resources["CloseIcon"];
                    SetThemeResource("CloseIcon");
                    break;
                case Icon.Maximize:
                    //path.Style = (Style)resources["MaximizeIcon"];
                    SetThemeResource("MaximizeIcon");
                    break;
                case Icon.Restore:
                    //path.Style = (Style)resources["RestoreIcon"];
                    SetThemeResource("RestoreIcon");
                    break;
                case Icon.Minimize:
                    //path.Style = (Style)resources["MinimizeIcon"];
                    SetThemeResource("MinimizeIcon");
                    break;
                case Icon.None:
                default:
                    this.Visibility = Visibility.Collapsed;
                    break;
            }

            this.Content = path;
            
        }


        private void SetStandardResource(String ResourceKey)
        {
            resources.Source = new Uri("/SugarControls;component/Styles/Icons.xaml", UriKind.RelativeOrAbsolute);
            path.Style = (Style)resources[ResourceKey];
        }


        private void SetThemeResource(String ResourceKey)
        {
            switch (this.Theme)
            {
                case Theme.Sugar:
                    resources.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarIcons.xaml", UriKind.RelativeOrAbsolute);
                    break;
                case Theme.VS:
                    resources.Source = new Uri("/SugarControls;component/Themes/VS/VSIcons.xaml", UriKind.RelativeOrAbsolute);
                    break;
                default:
                    break;
            }

            // assign the path with its style as content
            path.Style = (Style)resources[ResourceKey];
            
        }


        #endregion

    }
}

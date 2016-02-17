using SugarControls.Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SugarControls
{
    public class SugarButton : Button
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



        #region Construction

        public SugarButton()
        {
            this.Loaded += SugarButton_Loaded;
        }

        private void SugarButton_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // check if the theme is supposed to be the owner
            if (this.Theme == Theme.Owner)
            {
                this.Theme = CommonMethods.GetTheme(this);
            }

            // The resource dictionaire that contain desired style
            ResourceDictionary resource = new ResourceDictionary();


            // Apply the theme
            switch (this.Theme)
            {
                case Theme.Sugar:
                    resource.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarImageButtonStyle.xaml", UriKind.RelativeOrAbsolute);
                    this.Style = (Style)resource["SugarImageButtonStyle"];
                    break;
                case Theme.VS:
                    resource.Source = new Uri("/SugarControls;component/Themes/VS/VSImageButtonStyle.xaml", UriKind.RelativeOrAbsolute);
                    this.Style = (Style)resource["VSImageButtonStyle"];
                    break;
                default:
                    break;
            }


        }


        #endregion




    }




}

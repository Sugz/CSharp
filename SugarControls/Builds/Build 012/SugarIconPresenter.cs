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
    public class SugarIconPresenter : ContentControl
    {
        #region Members



        /// <summary>
        /// Define the Look (see EnumLook) to set one of the custom control style
        /// </summary>
        private DependencyProperty ThemeProperty = DependencyProperty.Register(
            "Theme",
            typeof(Theme),
            typeof(SugarIconPresenter));

        [Description("Set the Look and Feel of the control"), Category("Appearance")]
        public Theme Theme
        {
            get { return (Theme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }




        /// <summary>
        /// Define wich Icon (see SugarControls.Sources.Enums Icon) to use
        /// </summary>
        private DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon",
            typeof(Icon),
            typeof(SugarIconPresenter));
        [Description("Set the Icon To be display"), Category("Appearance")]
        public Icon Icon
        {
            get { return (Icon)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }


        #endregion


        #region Initialization

        public SugarIconPresenter()
        {
            this.Loaded += SugarIconPresenter_Loaded;
        }

        void SugarIconPresenter_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the resource containing the Window Style and assign it to the window
            ResourceDictionary _resources = new ResourceDictionary();
            _resources.Source = new Uri("/SugarControls;component/Styles/IconPresenter.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)_resources["IconPresenter"];
        }


        #endregion

    }
}

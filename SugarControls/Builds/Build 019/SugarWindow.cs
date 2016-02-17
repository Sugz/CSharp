using SugarControls.Sources;
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
        

        #region Fields

        /// <summary>
        /// Define the Look (see SugarControls.Sources.Enums Look) to set one of the custom control style
        /// </summary>
        private Theme _theme = Theme.Sugar;
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
        public Icon WindowIcon { get; set; }


        #endregion




        #region Constructors

        public SugarWindow()
        {
            this.Initialized += SugarWindow_Initialized;
        }


        #endregion



        private void SugarWindow_Initialized(object sender, EventArgs e)
        {
            if (this.Theme != Theme.None)
            {
                this.AllowsTransparency = true;
                this.WindowStyle = WindowStyle.None;
            }

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









      
    }
}

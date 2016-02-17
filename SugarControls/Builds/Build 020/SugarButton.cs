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

namespace SugarControls
{
    public class SugarButton : Button
    {

        #region Fields


        //private Brush overBrush;



        #endregion




        #region Properties

        public bool IsHeader { get; set; }
        public Mode Mode { get; set; }
        //public Brush OverBrush { get; set; }

        #endregion


        #region Constructors

        public SugarButton()
        {
            // define herited brushs
            //overBrush = SugarWindow.GetOverBrush(this);

            // check for the theme
            this.Loaded += SugarButton_Loaded;
            
        }

        // Apply the desired theme
        void SugarButton_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resource = new ResourceDictionary();

            Theme theme = SugarWindow.GetTheme(this);
            switch (theme)
            {
                case Theme.Sugar:
                    if (IsHeader)
                    {
                        resource.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarImageButtonStyle.xaml",
                            UriKind.RelativeOrAbsolute);
                        this.Style = (Style)resource["SugarHeaderButtonStyle"];
                    }
                    else
                    {
                        resource.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarImageButtonStyle.xaml",
                            UriKind.RelativeOrAbsolute);
                        this.Style = (Style)resource["SugarImageButtonStyle"];
                    }
                    
                    break;
                case Theme.VS:
                    resource.Source = new Uri("/SugarControls;component/Themes/VS/VSImageButtonStyle.xaml",
                        UriKind.RelativeOrAbsolute);
                    this.Style = (Style)resource["VSImageButtonStyle"];
                    break;
                case Theme.None:
                default:
                    break;
            }
        }


        #endregion


    }




}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SugzControls
{
    public class SugzButton : Button
    {

        #region Properties


        /// <summary>
        /// Get or set the CornerRadius property
        /// </summary>
        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }


        /// <summary>
        /// Get or set the OverBrush property
        /// </summary>
        public Brush OverBrush
        {
            get { return (Brush)GetValue(OverBrushProperty); }
            set { SetValue(OverBrushProperty, value); }
        }

        /// <summary>
        /// Get or set the PressedBrush property
        /// </summary>
        public Brush PressedBrush
        {
            get { return (Brush)GetValue(PressedBrushProperty); }
            set { SetValue(PressedBrushProperty, value); }
        }


        #endregion



        #region DependencyProperties

        /// <summary>
        /// Set the CornerRadius dependency property
        /// </summary>
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(int), typeof(SugzButton));


        /// <summary>
        /// Set the OverBrush dependency property
        /// </summary>
        public static DependencyProperty OverBrushProperty =
            DependencyProperty.RegisterAttached("OverBrush", typeof(Brush), typeof(SugzButton));


        /// <summary>
        /// Set the PressedBrush dependency property
        /// </summary>
        public static DependencyProperty PressedBrushProperty =
            DependencyProperty.RegisterAttached("PressedBrush", typeof(Brush), typeof(SugzButton));


        #endregion



        #region Constructors


        public SugzButton()
        {
            this.Loaded += SugzButton_Loaded;
        }


        #endregion



        #region Private Methods


        // Apply the desired theme
        private void SugzButton_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resource = new ResourceDictionary();
            resource.Source = new Uri("/SugzControls;component/Styles/SugzButtonStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)resource["SugzButtonStyle"];
        }


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        #region Fields


        Border mouseBorder = new Border();


        #endregion



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
            Loaded += SugzButton_Loaded;
            MouseEnter += SugzButton_MouseEnter;
            MouseLeave += SugzButton_MouseLeave;
            PreviewMouseDown += SugzButton_PreviewMouseDown;
            PreviewMouseUp += SugzButton_PreviewMouseUp;
        }

        
        #endregion



        #region Private Methods


        // Apply the style
        private void SugzButton_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resource = new ResourceDictionary();
            resource.Source = new Uri("/SugzControls;component/Styles/SugzButtonStyle.xaml", UriKind.RelativeOrAbsolute);
            this.Style = (Style)resource["SugzButtonStyle"];
        }

        // Get the mouse border
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            mouseBorder = (Border)Template.FindName("PART_MOUSE", this);
        }



        // Set the mouse border background equal to the overbrush
        private void SugzButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mouseBorder.Background = OverBrush;
        }

        // Set the mouse border background to be transparent
        private void SugzButton_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mouseBorder.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }

        // Set the mouse border background equal to the pressedbrush
        private void SugzButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mouseBorder.Background = PressedBrush;
        }

        // Set the mouse border background equal either to be tranbsparent or the overbrush
        private void SugzButton_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(IsMouseOver)
                mouseBorder.Background = OverBrush;
            else
                mouseBorder.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        }


        #endregion
    }
}



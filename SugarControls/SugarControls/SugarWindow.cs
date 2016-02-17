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
using System.Windows.Media;

namespace SugarControls
{
    public class SugarWindow : Window
    {

        #region Fields

        


        #endregion




        #region Properties

        /// <summary>
        /// Get or set the Theme property
        /// </summary>
        [Category("Appearance"), Description("Set the attached Theme Property")]
        public Theme Theme
        {
            get { return (Theme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }

        /// <summary>
        /// Get or set the OverBrush property
        /// </summary>
        //[Category("Brush"), Description("Set the attached Over Brush Property")]
        public Brush OverBrush
        {
            get { return (Brush)GetValue(OverBrushProperty); }
            set { SetValue(OverBrushProperty, value); }
        }

        /// <summary>
        /// Get or set the PressedBrush property
        /// </summary>
        //[Category("Brush"), Description("Set the attached Pressed Brush Property")]
        public Brush PressedBrush
        {
            get { return (Brush)GetValue(PressedBrushProperty); }
            set { SetValue(PressedBrushProperty, value); }
        }

        /// <summary>
        /// Get or set the HighLightBrush property
        /// </summary>
        //[Category("Brush"), Description("Set the attached HighLight Brush Property")]
        public Brush HighLightBrush
        {
            get { return (Brush)GetValue(HighLightBrushProperty); }
            set { SetValue(HighLightBrushProperty, value); }
        }




        /// <summary>
        /// Add the Theme as attached property to allow children controls to inherit from previous control instead of the default value
        /// </summary>
        public static DependencyProperty ThemeProperty = DependencyProperty.RegisterAttached(
            "Theme", typeof(Theme), typeof(SugarWindow),
            new FrameworkPropertyMetadata(Theme.Sugar, FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Add the OverBrush as attached property to allow children controls to inherit from previous control instead of the default value
        /// </summary>
        public static DependencyProperty OverBrushProperty = DependencyProperty.RegisterAttached(
            "OverBrush", typeof(Brush), typeof(SugarWindow),
            new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromArgb(0,0,0,0)),FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Add the PressedBrush as attached property to allow children controls to inherit from previous control instead of the default value
        /// </summary>
        public static DependencyProperty PressedBrushProperty = DependencyProperty.RegisterAttached(
            "PressedBrush", typeof(Brush), typeof(SugarWindow),
            new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)), FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Add the HighLightBrush as attached property to allow children controls to inherit from previous control instead of the default value
        /// </summary>
        public static DependencyProperty HighLightBrushProperty = DependencyProperty.RegisterAttached(
            "HighLightBrush", typeof(Brush), typeof(SugarWindow),
            new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 0, 0, 0)), FrameworkPropertyMetadataOptions.Inherits));




            

        
        

        #endregion
        



        #region Contructors


        public SugarWindow()
        {
            this.Initialized += SugarWindow_Initialized;
        }



        #endregion




        #region Events



        private void SugarWindow_Initialized(object sender, EventArgs e)
        {
            // Set the window transparent if it have a theme
            if (this.Theme != Theme.None)
            {
                this.AllowsTransparency = true;
                this.WindowStyle = WindowStyle.None;

                // Dictionary that contain the style of the window
                ResourceDictionary resource = new ResourceDictionary();

                // Apply style regarding the Theme
                switch (this.Theme)
                {
                    case Theme.Sugar:
                        resource.Source = new Uri("/SugarControls;component/Themes/Sugar/SugarWindowStyle.xaml", UriKind.RelativeOrAbsolute);
                        this.Style = (Style)resource["SugarWindowStyle"];
                        break;
                    case Theme.VS:
                        resource.Source = new Uri("/SugarControls;component/Themes/VS/VSWindowStyle.xaml", UriKind.RelativeOrAbsolute);
                        this.Style = (Style)resource["VSWindowStyle"];
                        break;
                    default:
                        break;
                }

            }

        }

        // Define the window parts that need event handler
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            switch (this.Theme)
            {
                case Theme.Sugar:
                case Theme.VS:
                    partsEventHandler(true, true, true, true, true);
                    break;
            }

        }


        // Get the window Parts and add event handler to handle the window
        private void partsEventHandler(bool icon, bool title, bool close, bool maximize, bool minimize)
        {
            if (title)
            {
                Border titleBarBorder = new Border();
                titleBarBorder = (Border)Template.FindName("PART_TITLEBAR", this);
                titleBarBorder.MouseLeftButtonDown += titleBarBorder_MouseLeftButtonDown;
            }
            if (close)
            {
                Button closeButton = new Button();
                closeButton = (Button)Template.FindName("PART_CLOSE", this);
                closeButton.Click += closeButton_Click;
            }
            if (maximize)
            {
                Button maximizeButton = new Button();
                maximizeButton = (Button)Template.FindName("PART_MAXIMIZE", this);
                maximizeButton.Click += maximizeButton_Click;
            }
            if (minimize)
            {
                Button minimizeButton = new Button();
                minimizeButton = (Button)Template.FindName("PART_MINIMIZE", this);
                minimizeButton.Click += minimizeButton_Click;
            }
            
        }



        private void titleBarBorder_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void maximizeButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    this.WindowState = WindowState.Normal;
                    break;
                case WindowState.Normal:
                    this.WindowState = WindowState.Maximized;
                    break;
            }
        }

        private void minimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        #endregion




        #region Methods

        /// <summary>
        /// Method to get attached property Theme on controls
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AttachedPropertyBrowsableForChildrenAttribute(IncludeDescendants = true), Category("Appearance"), Description("Set the attached Theme Property")]
        public static Theme GetTheme(DependencyObject obj)
        {
            return (Theme)obj.GetValue(ThemeProperty);
        }

        /// <summary>
        /// Method to set attached property Theme on controls
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetTheme(DependencyObject obj, Theme value)
        {
            obj.SetValue(ThemeProperty, value);
        }



        /// <summary>
        /// Method to get attached property OverBrush on controls
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AttachedPropertyBrowsableForChildrenAttribute(IncludeDescendants = true), Category("Brush"), Description("Set the attached Over Brush Property")]
        public static Brush GetOverBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(OverBrushProperty);
        }

        /// <summary>
        /// Method to set attached property OverBrush on controls
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetOverBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(OverBrushProperty, value);
        }

        /// <summary>
        /// Method to get attached property PressedBrush on controls
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AttachedPropertyBrowsableForChildrenAttribute(IncludeDescendants = true), Category("Brush"), Description("Set the attached Pressed Brush Property")]
        public static Brush GetPressedBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(PressedBrushProperty);
        }

        /// <summary>
        /// Method to set attached property Pressed on controls
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetPressedBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(PressedBrushProperty, value);
        }

        /// <summary>
        /// Method to get attached property HighLightBrush on controls
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [AttachedPropertyBrowsableForChildrenAttribute(IncludeDescendants = true), Category("Brush"), Description("Set the attached HighLight Brush Property")]
        public static Brush GetHighLightBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(HighLightBrushProperty);
        }

        /// <summary>
        /// Method to set attached property HighLightBrush on controls
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetHighLightBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(HighLightBrushProperty, value);
        }



        #endregion


    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SugarControls.Sources
{
    public static class CommonMethods
    {
        public static Theme GetTheme(DependencyObject sender)
        {
            var parent = VisualTreeHelper.GetParent(sender);
            while (!(parent is SugarWindow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }


            Theme theme = ((SugarWindow)parent).Theme;
            return theme;

        }
        
    }
}

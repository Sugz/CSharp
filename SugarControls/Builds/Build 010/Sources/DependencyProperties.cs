using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SugarControls.Sources
{
    internal class DependencyProperties
    {
        /// <summary>
        /// Define the Look (see EnumLook) to set one of the custom control style
        /// </summary>
        public static readonly DependencyProperty ThemeProperty = DependencyProperty.Register(
            "Look",
            typeof(Theme),
            typeof(ContentControl));



        




    }








}

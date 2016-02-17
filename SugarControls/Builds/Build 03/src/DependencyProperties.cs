using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SugarControls.src
{
    class DependencyProperties
    {
        /// <summary>
        /// Define the Look (see EnumLook) to set one of the custom control style
        /// </summary>
        public static DependencyProperty LookProperty = DependencyProperty.Register(
            "Look",
            typeof(Look),
            typeof(ContentControl));
    }
}

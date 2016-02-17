using SugarControls.Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SugarControls
{
    class SugarButton : Button
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
    }
}

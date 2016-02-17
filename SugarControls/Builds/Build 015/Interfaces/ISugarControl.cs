using SugarControls.Sources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarControls.Interfaces
{
    internal interface ISugarControl
    {

        //[Description("Define to which class belong the control")]
        //SugarClass Class { get; private set; }

        /// <summary>
        /// Define the Look (see SugarControls.Sources.Enums Look) to set one of the custom control style
        /// </summary>
        [Description("Set the Look and Feel of the control"), Category("Appearance")]
        Theme Theme { get; set; }

        /// <summary>
        /// Define wich Icon (see SugarControls.Sources.Enums Icon) to use
        /// </summary>
        [Description("Set the Icon To be display"), Category("Appearance")]
        Icon Icon { get; set; }
    }
}

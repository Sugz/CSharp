#region namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//debug
using System.Diagnostics;

//3dsmaxAPI
using ManagedServices;
using UiViewModels.Actions;
using Autodesk.Max;
#endregion


namespace dialogUI
{
    public abstract class CUIbase : CuiActionCommandAdapter
    {

        public override string ActionText
        {
            get { return InternalActionText; }
        }

        public override string InternalActionText
        {
            get { return this.CustomActionText; }
        }

        public override string Category
        {
            get { return this.InternalCategory; }
        }

        public override string InternalCategory
        {
            get { return "rfxTest"; }
        }

        public override void Execute(object parameter)
        {
            try
            {
                this.CustomExecute(parameter);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception occurred: " + exc.Message);
            }
        }

        public abstract string CustomActionText { get; }
        public abstract void CustomExecute(object parameter);

    }
}

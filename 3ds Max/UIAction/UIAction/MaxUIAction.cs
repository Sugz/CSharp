using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Max;
using UiViewModels.Actions;
using MaxCustomControls;

namespace MaxUIAction
{
    public class UIAction : CuiActionCommandAdapter
    {
        public static MaxForm form;

        public override string ActionText
        {
            get { return "Max UI action"; }
        }

        public override string Category
        {
            get { return "Max C# demo"; }
        }

        public override void Execute(object parameter)
        {
            if (form == null)
                form = new MaxForm();
            form.ShowInFrame();
        }

        public override string InternalActionText
        {
            get { return ActionText; }
        }

        public override string InternalCategory
        {
            get { return Category; }
        }
    }
}

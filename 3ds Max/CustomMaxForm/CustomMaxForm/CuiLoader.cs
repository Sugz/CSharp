using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UiViewModels.Actions;

namespace CustomMaxForm
{
    public class CuiLoader : CuiResizableDockableContent
    {
        public override UserControl Content { get { return new UserControl1(); } }

        public override string WindowTitle { get { return "It's working Bitch !"; } }

        public override string ActionText { get { return "SugzForm"; } }

        public override string Category { get { return "SugzTools"; } }
    }
}

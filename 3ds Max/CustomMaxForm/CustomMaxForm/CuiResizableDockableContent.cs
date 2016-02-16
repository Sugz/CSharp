using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UiViewModels.Actions;


namespace CustomMaxForm
{
    public abstract class CuiResizableDockableContent : CuiActionCommandAdapter
    {
        public static SugzForm form;
        //public SugzForm form;

        public abstract UserControl Content { get; }

        public abstract string WindowTitle { get; }

        public abstract override string ActionText { get; }

        public abstract override string Category { get; }

        public override void Execute(object parameter)
        {
            form = form ?? new SugzForm(Content);
            form.Text = WindowTitle;
            form.ShowInFrame();
        }

        public override string InternalActionText { get { return ActionText; } }

        public override string InternalCategory { get { return Category; } }

    }
}

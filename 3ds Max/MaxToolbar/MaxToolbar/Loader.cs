using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using UiViewModels.Actions;

namespace MaxToolbar
{
    public class Loader : CuiDockableContentAdapter
    {
        #region Fields

        // Create an instance of the view to be able to modify it in this class
        private MaxToolbar MaxToolbarView = new MaxToolbar();


        #endregion


        #region Properties

        public override string ActionText { get { return "MaxToolbar"; } }
        public override string Category { get { return "SugzTools"; } }
        public override string WindowTitle { get { return "MaxToolbar"; } }
        public override Type ContentType { get { return typeof(MaxToolbar); } }
        public override DockStates.Dock DockingModes { get { return DockStates.Dock.Left | DockStates.Dock.Right | DockStates.Dock.Floating; } }
        public override bool IsMainContent { get { return true; } }

        #endregion


        #region Methods

        public override object CreateDockableContent() { return MaxToolbarView; }

        // Modify the view based on the dockMode
        public override void SetContentDockMode(object dockableContent, DockStates.Dock dockMode)
        {
            base.SetContentDockMode(dockableContent, dockMode);
            MaxToolbarView.SetResizeBorders(dockMode);
        }

        #endregion
    }
}


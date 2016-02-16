// Decompiled with JetBrains decompiler
// Type: MaxCustomControls.MaxForm
// Assembly: MaxCustomControls, Version=18.0.873.0, Culture=neutral, PublicKeyToken=null
// MVID: 33102D32-52BB-4945-A414-E24D8092C543
// Assembly location: C:\Program Files\Autodesk\3ds Max 2016\MaxCustomControls.dll

using ManagedServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace MaxUIAction
{
    /// <summary>
    /// This class is an augmented Form designed for use with the Max platform.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Clients planning on implementing managed dialogs in the application should
    ///             make use of and derive from MaxForm instead of from Form directly.  This class
    ///             is aware of certain application-specific behaviour, such as Custom User Interface (CUI)
    ///             changes, and supplies a mechanism for doing modeless dialogs that doesn't interfere
    ///             with the application's hotkey system.  In fact, the standard Form
    ///             may not even receive any keyboard input when launched on top of the native
    ///             application.
    /// 
    /// </remarks>
    public class MaxForm : Form, CuiUpdatable, ISerializable
    {
        /// <summary>
        /// Required designer variable.
        /// 
        /// </summary>
        private IContainer components;

        /// <summary>
        /// This returns the CUI frame object wrapping the form, or null if there is no frame
        /// 
        /// </summary>
        public WinFormsCUIFrame Frame { get; private set; }

        /// <summary>
        /// Default Constructor.
        /// 
        /// </summary>
        public MaxForm()
        {
            this.InitializeComponent();
            this.Activated += new EventHandler(this.HandleActivate);
            this.Deactivate += new EventHandler(this.HandleDeactivate);
            this.FormClosed += new FormClosedEventHandler(this.FormClosedHandler);
            if (!UIOptions.IsDesignerMode)
                this.InitializeMainIcon();
            if (UIOptions.IsDesignerMode)
                return;
            this.Shown += new EventHandler(this.BindToMaxCui);
            this.FormClosed += new FormClosedEventHandler(this.UnbindFromMaxCui);
        }

        /// <summary>
        /// Sets the main form icon based on the application icon.
        /// 
        /// </summary>
        private void InitializeMainIcon()
        {
            this.Icon = AppSDK.GetMainApplicationIcon();
        }

        /// <summary>
        /// Traverses the sub-controls of this MaxForm and automatically unbinds
        ///             any that implement the CuiUpdatable interface from the application
        ///             CUI system.
        /// 
        /// </summary>
        /// <param name="sender">The object that generated the event this method handles.</param><param name="e">The args for this event.</param>
        private void UnbindFromMaxCui(object sender, FormClosedEventArgs e)
        {
            CuiUpdater.GetInstance().UnregisterForm((Form)this);
            this.GetMaxHookInterfaces().ForEach(new Action<CuiUpdatable>(MaxCuiBinder.GetInstance().UnregisterForNotification));
        }

        /// <summary>
        /// Traverses the sub-controls of this MaxForm and automatically binds
        ///             any that implement the CuiUpdatable interface to the application
        ///             CUI system.
        /// 
        /// </summary>
        /// <param name="sender">The object that generated the event this method handles.</param><param name="e">The args for this event.</param>
        private void BindToMaxCui(object sender, EventArgs e)
        {
            CuiUpdater.GetInstance().RegisterForm((Form)this);
            this.GetMaxHookInterfaces().ForEach(new Action<CuiUpdatable>(MaxCuiBinder.GetInstance().RegisterForNotification));
        }

        /// <summary>
        /// Traverses sub-controls and accumulates all controls that implement the
        ///             CuiUpdatable interface.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// A list of CuiUpdatable objects.
        /// </returns>
        private List<CuiUpdatable> GetMaxHookInterfaces()
        {
            return Enumerable.ToList<CuiUpdatable>(Enumerable.OfType<CuiUpdatable>((IEnumerable)this.GetAllControls((Control)this)));
        }

        /// <summary>
        /// Returns all controls on the form and their descendants, including the form itself.
        /// 
        /// </summary>
        /// <param name="ctrl"/>
        /// <returns/>
        public IEnumerable<Control> GetAllControls(Control ctrl)
        {
            yield return ctrl;
            foreach (Control ctrl1 in (ArrangedElementCollection)ctrl.Controls)
            {
                foreach (Control control in this.GetAllControls(ctrl1))
                    yield return control;
            }
        }

        /// <summary>
        /// Updates the form's colors according to the current CUI settings.
        /// 
        /// </summary>
        /// 
        /// <remarks>
        /// Implementation of CuiUpdatable interface.
        /// 
        /// </remarks>
        public virtual void UpdateColors()
        {
            this.BackColor = CuiUpdater.GetInstance().GetControlColor();
            this.ForeColor = CuiUpdater.GetInstance().GetTextColor();
        }

        /// <summary>
        /// Displays this form modelessly sets the main application's window as
        ///             the parent.
        /// 
        /// </summary>
        public virtual void ShowModeless()
        {
            this.Show((IWin32Window)NativeWindow.FromHandle(AppSDK.GetMaxHWND()));
        }

        /// <summary>
        /// Displays this form as a modal dialog and
        ///             sets the main application's window as the parent.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// The result of this modal interaction.  The
        ///             return value is the same as Form.ShowDialog(IWin32Window)
        /// 
        /// </returns>
        public virtual DialogResult ShowModal()
        {
            return this.ShowDialog((IWin32Window)NativeWindow.FromHandle(AppSDK.GetMaxHWND()));
        }

        /// <summary>
        /// Displays this form as a modal dialog and
        ///             sets the passed in Form as the parent.
        /// 
        /// </summary>
        /// <param name="aForm">A form to be used as a parent of this modal Form</param>
        /// <returns>
        /// The result of this modal interaction.  The
        ///             return value is the same as Form.ShowDialog(Form)
        /// 
        /// </returns>
        public virtual DialogResult ShowModal(Form aForm)
        {
            return this.ShowDialog((IWin32Window)aForm);
        }

        /// <summary>
        /// Save the states of MaxForm such as form size.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// A CustomizationState object containing MaxForm's states.
        /// 
        /// </returns>
        public virtual ICustomizationState SaveState()
        {
            FormCustomizationState state = this.CreateState();
            if (state == null)
                return (ICustomizationState)null;
            state.GetFormStates((Control)this);
            return (ICustomizationState)state;
        }

        /// <summary>
        /// Load the form states such as size from the "stateToLoad" object.
        /// 
        /// </summary>
        /// <param name="stateToLoad">The object which contains the states of the form.
        ///             </param>
        /// <returns>
        /// Return true if load successfully, false otherwise
        /// </returns>
        public virtual bool LoadState(ICustomizationState stateToLoad)
        {
            FormCustomizationState customizationState = stateToLoad as FormCustomizationState;
            if (customizationState == null)
                return false;
            customizationState.SetFormStates((Control)this);
            return true;
        }

        /// <summary>
        /// A factory method for creating the state object that represents this form.
        ///             Clients deriving from this class should override this method and return
        ///             their own derived State object.
        /// 
        /// </summary>
        /// 
        /// <returns>
        /// An empty State object that is used to persist and serialize
        ///             the state of this object.
        /// </returns>
        protected virtual FormCustomizationState CreateState()
        {
            return new FormCustomizationState();
        }

        /// <summary>
        /// Enables application accelerators when the
        ///             form is deactivated.
        /// 
        /// </summary>
        /// <param name="sender">The object that generated the event this method handles.</param><param name="e">The args for this event. EventArgs.Empty by default.</param>
        private void HandleDeactivate(object sender, EventArgs e)
        {
            AppSDK.EnableAccelerators();
        }

        /// <summary>
        /// Disables application accelerators when the
        ///             form is activated. Note that this is not called when Frame is active.
        /// 
        /// </summary>
        /// <param name="sender">The object that generated the event this method handles.</param><param name="e">The args for this event. EventArgs.Empty by default.</param>
        private void HandleActivate(object sender, EventArgs e)
        {
            AppSDK.DisableAccelerators();
        }

        /// <summary>
        /// Handles the Closed event.
        /// 
        /// </summary>
        /// <param name="sender">The object that generated the event this method handles.</param><param name="e">The args for this event. EventArgs.Empty by default.</param>
        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            this.FormClosed -= new FormClosedEventHandler(this.FormClosedHandler);
            Win32API.BringWindowToTop(AppSDK.GetMaxHWND());
        }

        /// <summary>
        /// Adds a CUI frame to the MAXForm that allows it to be docked to the left or to the right.
        ///             This changes a lot of the standard behavior of Windows forms so use with caution.
        ///             For example activate events are no longer triggered which in turn means that accelerators are no longer
        ///             disabled when the form is activated.
        /// 
        /// </summary>
        public void ShowInFrame()
        {
            if (this.Frame != null || !SystemInformation.UserInteractive)
                return;
            this.Frame = new WinFormsCUIFrame((Form)this);
        }

        /// <summary>
        /// Removes a CUI Frame around the MAXForm. The form styles will be restored and it will be parented to the 3ds Max main
        ///             window, regardless of what it was parented to before.
        /// 
        /// </summary>
        public void RemoveFrame()
        {
            if (this.Frame == null)
                return;
            this.Frame.RemoveFrame();
            this.Frame = (WinFormsCUIFrame)null;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// 
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        ///             the contents of this method with the code editor.
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.BackColor = Color.FromArgb(197, 197, 197);
            this.ClientSize = new Size(292, 273);
            this.DoubleBuffered = true;
            this.Name = "MaxForm";
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
        }
    }
}

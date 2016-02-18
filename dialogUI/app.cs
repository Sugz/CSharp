#region namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using System.Windows.Interop;
using System.Windows.Media;
using System.ComponentModel;

//debug
using System.Diagnostics;
//3dsmaxAPI
using ManagedServices;
using UiViewModels.Actions;
using Autodesk.Max;
#endregion

namespace dialogUI
{
    public class app : CUIbase
    {

        private bool firstTime = true;
        private System.Windows.Window dial = null;

        public override string CustomActionText 
        {
            get{ return "base UI"; }
        }

        public override void CustomExecute(object parameter)
        {    
            try
            {
                if(dial == null)
                {
                    SetupDialog();
                    dial.Visibility = Visibility.Visible;
                }

                else
                {
                    dial.Visibility = Visibility.Hidden;
                    dial = null;
                }

                return;
            }
            catch (System.Exception ex)
            {

                Debug.Print("Another instance is already running" + ex.Message);
            }
        }

        private void SetupDialog()
        {
            // Create a new managed window to contain the WPF control
            this.dial = new System.Windows.Window();
            dial.SizeToContent = System.Windows.SizeToContent.WidthAndHeight;
            dial.ResizeMode = ResizeMode.CanResizeWithGrip;
            dial.Title = "test UI";
            dial.WindowStyle = WindowStyle.None;
            dial.AllowsTransparency = true;
            dial.MinWidth = 200.0;
            dial.MinHeight = 400;
            dial.Height = 900;
            dial.Width = 600;

            dial.ShowInTaskbar = false;

            dialog templateUI = new dialog(dial);

            // Assign the window's content to be the WPF control
            dial.Content = templateUI;
            dial.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

            // Create an interop helper
            System.Windows.Interop.WindowInteropHelper windowHandle = new System.Windows.Interop.WindowInteropHelper(dial);

            // Assign the 3ds Max HWnd handle to the interop helper
            windowHandle.Owner = ManagedServices.AppSDK.GetMaxHWND();

            // Setup 3ds Max to handle the WPF dialog correctly
            ManagedServices.AppSDK.ConfigureWindowForMax(dial);

            dial.Show(); 
        }
    }

}
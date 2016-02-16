using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Controls;
using MaxCustomControls;

namespace CustomMaxForm
{
    public partial class SugzForm : MaxForm
    {

        // Fields
        #region Fields


        private ElementHost host = new ElementHost();
        private System.Windows.Controls.UserControl _control;


        #endregion // End Fields


        // Constructor
        #region Constructor


        public SugzForm(System.Windows.Controls.UserControl control)
        {
            InitializeComponent();

            _control = control;

            Controls.Add(host);
            host.Child = _control;
            ResizeWindow();

            this.Resize += SugzForm_Resize;
        }


        #endregion // End Constructor


        // Methods
        #region Methods


        private void ResizeWindow()
        {
            host.Width = Width;
            host.Height = Height;
            _control.Width = Width;
            _control.Height = Height;
        }

        private void SugzForm_Resize(object sender, EventArgs e)
        {
            ResizeWindow();
        }


        #endregion // End Methods
    }
}
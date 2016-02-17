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
    public class SugarButton : Button
    {
        #region Members




        #endregion


        #region Initialization

        public SugarButton()
        {
            // Add the Loaded event handler
            this.Loaded += SugarButton_Loaded;
        }

        private void SugarButton_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Content = new SugarIcon();
            
        }


        #endregion
    }
}

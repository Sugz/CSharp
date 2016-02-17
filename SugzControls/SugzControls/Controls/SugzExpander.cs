using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SugzControls
{
    public class SugzExpander : Expander
    {


        #region Properties


        /// <summary>
        /// Get or set the IsExpand property
        /// </summary>
        //public bool IsExpand
        //{
        //    get { return (bool)GetValue(IsExpandProperty); }
        //    set { SetValue(IsExpandProperty, value); }
        //}


        //public int HeaderHeight
        //{
        //    get { return (int)GetValue(HeaderHeightProperty); }
        //    set { SetValue(HeaderHeightProperty, value); }
        //}


        #endregion


        #region DependencyProperties

        ///// <summary>
        ///// IsExpand dependency property
        ///// </summary>
        //public static readonly DependencyProperty IsExpandProperty =
        //    DependencyProperty.Register("IsExpand", typeof(bool), typeof(Expander));


        ///// <summary>
        ///// HeaderHeight dependency property
        ///// </summary>
        //public static readonly DependencyProperty HeaderHeightProperty =
        //    DependencyProperty.Register("HeaderHeight", typeof(int), typeof(Expander));


        #endregion




        #region Constructor


        public SugzExpander()
        {

        }


        #endregion
    }
}

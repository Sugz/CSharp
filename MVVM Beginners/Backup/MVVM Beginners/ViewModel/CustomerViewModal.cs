using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVM_Beginners.Model;
using System.Windows.Input;

namespace MVVM_Beginners.ViewModel
{
    public class CustomerViewModal 
    {
        #region " ViewTitle Property "
        /// <summary>
        /// 
        /// </summary>
        public string ViewTitle { get; set; }
        #endregion

        #region " Customer Property "
        /// <summary>
        /// 
        /// </summary>
        public Customer Customers { get; set; }
        #endregion

        #region " Default Constructor "
        /// <summary>
        /// 
        /// </summary>
        public CustomerViewModal()
        {
            Customers = new Customer() { ContactNumber = "123456789", DateOfBirth = Convert.ToDateTime("08/08/1981"), EmailID = "myname@hotmail.com", FirstName = "Brett", LastName = "Lee", UserID = "000-ABCD-001" };
            ViewTitle = "Customer Form";
        }
        #endregion
    }
}

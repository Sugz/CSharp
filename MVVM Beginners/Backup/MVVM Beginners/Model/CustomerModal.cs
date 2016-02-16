using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM_Beginners.Model
{
    public class Customer : System.ComponentModel.INotifyPropertyChanged
    {

        private string strFirstName;
        private string strLastName;

        #region " UserID Property "
        /// <summary>
        /// 
        /// </summary>
        public string UserID { get; set; }
        #endregion

        #region " FirstName Property "
        /// <summary>
        /// 
        /// </summary>
        public string FirstName
        {
            get { return strFirstName; }
            set
            {
                strFirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }
        #endregion

        #region " LastName Property "
        /// <summary>
        /// 
        /// </summary>
        public string LastName
        {
            get { return strLastName; }
            set
            {
                strLastName = value;
                RaisePropertyChanged("LastName");
            }
        }
        #endregion        

        #region " EmailID Property "
        /// <summary>
        /// 
        /// </summary>
        public string EmailID { get; set; }
        #endregion

        #region " ContactNo Property "
        /// <summary>
        /// 
        /// </summary>
        public string ContactNumber { get; set; }
        #endregion

        #region " DateOfBirth Property "
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        #endregion

        #region INotifyPropertyChanged Members

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;       

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

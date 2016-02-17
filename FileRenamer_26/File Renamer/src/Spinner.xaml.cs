using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace File_Renamer
{

    /// <summary>
    /// Interaction logic for Spinner.xaml
    /// </summary>
    public partial class Spinner : UserControl
    {

        #region Members

        // define the ValueChanged event
        public event EventHandler ValueChanged;
        

        // define  a string to store current textbox value
        private string text = String.Empty;


        // define the value of the spinner
        private int numValue = 0;

        public int NumValue
        {
            get { return numValue; }
            set
            {
                numValue = value;
                NumTxt.Text = value.ToString();
                ValueChanged(this, new EventArgs()); 
            }
        }

        // timer for Increaseing/Decreasing value with certain time interval
        private DispatcherTimer timer;
        

        #endregion


        #region Initialization
        public Spinner()
        {
            this.InitializeComponent();

            // Set timer properties
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(333.3);
        }

        #endregion


        #region Events

        #region TextBox

        private void NumTxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            // if the text can be parse as integer, apply it to the textbox
            if (int.TryParse(NumTxt.Text, out numValue)) { NumTxt.Text = numValue.ToString(); }
            else if (String.IsNullOrEmpty(NumTxt.Text)) { NumTxt.Text = ""; }
            // keep the textbox old value
            else { NumTxt.Text = text; }


            // if the textbox value is 0, set the hint
            if (NumTxt.Text == "0") { NumTxt.SetHint(); }


        }


        // store the actual textbox value
        private void NumTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            text = NumTxt.Text;
        }


        private void NumTxt_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0) IncreaseValue();
            else if (e.Delta < 0) DecreaseValue();
        }

        #endregion

        #region Buttons

        private void Up_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IncreaseValue();
            this.timer.Tick += Increase_Timer_Tick;
            timer.Start();
        }

        private void Up_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.timer.Tick -= Increase_Timer_Tick;
            timer.Stop();
        }

        private void Down_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DecreaseValue();
            this.timer.Tick += Decrease_Timer_Tick;
            timer.Start();
        }

        private void Down_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.timer.Tick -= Decrease_Timer_Tick;
            timer.Stop();
        }

        private void Increase_Timer_Tick(object sender, EventArgs e)
        {
            IncreaseValue();
        }

        private void Decrease_Timer_Tick(object sender, EventArgs e)
        {
            DecreaseValue();
        }

        private void Buttons_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            NumValue = 0;
        }

        #endregion

        #endregion


        #region Methods

        private void IncreaseValue()
        {
            if (NumValue == 0) { NumTxt.SetEdit(); }
            NumValue++;
        }

        private void DecreaseValue()
        {
            if (NumValue - 1 > 0) { NumValue--; }
            else if (NumValue - 1 == 0) 
            {
                NumTxt.SetHint();
                ValueChanged(this, new EventArgs()); 
            }
        }


        #endregion


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.ComponentModel;

namespace File_Renamer
{
    /// <summary>
    /// Interaction logic for TextBoxKeyFiltered.xaml
    /// </summary>
    public partial class TextBoxHint : TextBox
    {


        #region Members

        public Canvas _expanderCanvas;
        Canvas _clearCanvas;
        Canvas _warningCanvas = new Canvas();


        public bool EditMode { get; set; }

        public bool FolderNumber { get; set; }

        public bool FileNumber { get; set; }



        // Define the history
        public List<string> History = new List<string>();

        private bool _activeHistory = true;
        public bool ActiveHistory
        {
            get { return _activeHistory; }
            set 
            { 
                _activeHistory = value;
                if (value)
                {
                    this.KeyDown += TextBox_KeyDown;
                }
                else
                {
                    this.KeyDown -= TextBox_KeyDown;
                }
            }
        }


        // Define the warning visibility
        private Visibility _warningVisibility = Visibility.Collapsed;
        public Visibility WarningVisibility
        {
            get { return _warningVisibility; }
            set { _warningVisibility = value; }
        }


        /// <summary>
        /// Set the Hint of the TextBox.
        /// </summary>
        [Description("Set the Hint of the TextBox."), Category("Hint")]
        public string Hint { get; set; }


        /// <summary>
        /// Set the comportement of the Hint.
        /// </summary>
        [Description("Load at start."), Category("Hint")]
        public bool OnLoad { get; set; }

        /// <summary>
        /// Set the comportement of the Hint.
        /// </summary>
        [Description("Activate when mouse leaves the textbox."), Category("Hint")]
        public bool OnMouseLeave { get; set; }

        /// <summary>
        /// Set the comportement of the Hint.
        /// </summary>
        [Description("Activate when user deletes the text."), Category("Hint")]
        public bool OnTextChanged { get; set; }

        /// <summary>
        /// Set the comportement of the Hint.
        /// </summary>
        [Description("Delete when user enters text."), Category("Hint")]
        public bool OnTextInput { get; set; }


        /// <summary>
        /// Set the comportement of the Hint.
        /// </summary>
        [Description("Delete when user click on the textbox."), Category("Hint")]
        public bool OnClick { get; set; }

        /// <summary>
        /// Set the comportement of the Hint.
        /// </summary>
        [Description("Delete when textbox lost focus."), Category("Hint")]
        public bool OnLostFocus { get; set; }


        private Color _color = Color.FromArgb(100, 200, 200, 200);
        /// <summary>
        /// Set the color of the Hint.
        /// </summary>

        [Description("Set the color of the Hint."), Category("Hint")]
        public SolidColorBrush HintColor { get; set; }



        // Define the History Limit
        private int _limit = 10;
        [Description("Define the History Limit."), Category("History")]
        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }



        #endregion



        #region Published Events


        public event EventHandler HistoryIconMouseUp;
        public event EventHandler WarningIconMouseUp;


        #endregion



        #region Initialization

        public TextBoxHint()
        {
            this.InitializeComponent();
            FolderNumber = FileNumber = false;
        }


        public override void OnApplyTemplate()
        {
            _expanderCanvas = this.GetTemplateChild("ExpanderCanvas") as Canvas;
            _clearCanvas = this.GetTemplateChild("ClearCanvas") as Canvas;
            _warningCanvas = this.GetTemplateChild("WarningCanvas") as Canvas;
            base.OnApplyTemplate();
        }


        #endregion



        #region Hint State

        public bool IsEmpty()
        {
            if (String.IsNullOrEmpty(this.Text)) { return true; }
            else { return false; }

        }

        public void SetHint()
        {
            this.Foreground = HintColor;
            this.Text = this.Hint;
            this.EditMode = false;
        }

        public void SetEdit()
        {
            this.Foreground = new SolidColorBrush(Color.FromRgb(200,200,200));
            this.Text = String.Empty;
            this.EditMode = true;
        }

        #endregion



        #region Methods

        // Add Current Text to History
        private void AddToHistory()
        {
            //show the history icon
            if (History.Count == 0)
            {
                _expanderCanvas.Visibility = Visibility.Visible;
            }

            // Delete File and Folder Number
            string _text = Text;
            if (this.FolderNumber)
            {
                _text = Text.Replace("<FolderNumber>", "");
            }
            if (this.FileNumber)
            {
                _text = Text.Replace("<FileNumber>", "");
            }
            // Update the history list
            if (!History.Contains(_text))
            {
                History.Insert(0, _text);
                if (History.Count > _limit)
                {
                    History.Remove(History[_limit]);
                }
                    
            }
            

            
        }

        // Show the Expander Icon
        public void ShowExpander(bool state)
        {
            if (state)
            {
                _expanderCanvas.Visibility = Visibility.Visible;
            }
            else
            {
                _expanderCanvas.Visibility = Visibility.Collapsed;
            }
        }


        // Show the Warning Icon
        public void ShowWarning(bool state)
        {
            if (state)
            {
                _warningCanvas.Visibility = Visibility.Visible;
            }
            else
            {
                _warningCanvas.Visibility = Visibility.Collapsed;
            }
        }


        // Set the Caret Index at the end
        public void SetCaret()
        {
            this.CaretIndex = this.Text.Length;
        }

        

        #endregion



        #region Private Events

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (OnLoad) { SetHint(); }

            if (this._activeHistory)
            {
                this.KeyDown += TextBox_KeyDown;
            }
        }

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (OnClick && !EditMode) { SetEdit(); }
        }



        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            //_expanderCanvas.Opacity = _clearCanvas.Opacity = 1.0;
        }

        private void TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (OnMouseLeave && IsEmpty()) { SetHint(); }

            //_expanderCanvas.Opacity = _clearCanvas.Opacity = 0.25;
        }





        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (OnTextInput && !EditMode) { SetEdit(); }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OnTextChanged && IsEmpty() && EditMode) 
            { 
                SetHint();
                ShowWarning(false);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (OnLostFocus && IsEmpty()) { SetHint(); }
        }


        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddToHistory();
            }
        }




        private void ExpanderCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (HistoryIconMouseUp != null)
                HistoryIconMouseUp(this, e);
        }

        private void ClearCanvas_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Text = String.Empty;
        }

        private void WarningCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (WarningIconMouseUp != null)
                WarningIconMouseUp(this, e);
        }


        #endregion

        

        

        
         
        

        

       



    }
}

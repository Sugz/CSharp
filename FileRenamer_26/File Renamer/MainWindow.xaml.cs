using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.DirectoryServices;

namespace File_Renamer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// implementer pref utilisateur
    /// 
    /// 
    /// implementer reseau local
    /// 
    /// 
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables

        // Define the window class
        private WindowResizer ob;

        // Define the resize borders
        private Grid resize;

        // Define the explorer and datagrid grids width
        private double WindowWidth;
        private double ExplorerWidth;
        private double DatagridWidth;

        // Define a dummy node to add to every new node in the treeview
        private object dummyNode = null;

        // Define a null string to store the treeview selected item tag
        private string folderPath = null;

        // Define the last focused textbox
        private TextBoxHint LastTextBox;

        // Define if the historic is common
        private bool historicCommonMode = false;

        // Define the common historic
        private List<string> historicCommon = new List<string>();

        // Define the historic limit
        private int _historicLimit = 15;

        // Define a timer
        private DispatcherTimer timer = new DispatcherTimer();

        // Define the file list on normal mode
        private List<ItemDG> FilesList = new List<ItemDG>();

        // Define the folder DG list on advanced mode
        private List<ItemDG> FoldersList = new List<ItemDG>();

        // Define the complete file path
        private string FilePath = null;

        // Define the spinners value
        private int TrimStart;
        private int TrimEnd;

        // Define increment padding
        private int IncrementValue;


        
        #endregion



        #region Main Window

        #region Initialization

        public MainWindow()
        {
            InitializeComponent();

            // set the windows class
            ob = new WindowResizer(this);

            // add the spinners valuechanged event
            TrimStartSpn.ValueChanged += new EventHandler(Spinner_ValueChanged);
            TrimEndSpn.ValueChanged += new EventHandler(Spinner_ValueChanged);

            // add the paste event on textbox
            DataObject.AddPastingHandler(RenameTxt, PasteHandler);
            DataObject.AddPastingHandler(ReplaceTxt, PasteHandler);
            DataObject.AddPastingHandler(WithTxt, PasteHandler);
            DataObject.AddPastingHandler(PrefixTxt, PasteHandler);
            DataObject.AddPastingHandler(SuffixTxt, PasteHandler);
        }

        public override void OnApplyTemplate()
        {
            resize = Template.FindName("ResizeBorders", this) as Grid;
        }


        #endregion


        #region Title Bar

        #region Function

        private void MaximiseWindow()
        {
            switch (WindowState)
            {
                case (WindowState.Maximized):
                    {
                        ResizeMode = ResizeMode.CanResize;
                        WindowState = WindowState.Normal;
                        PART_MAXIMISE.Visibility = Visibility.Visible;
                        PART_RESTORE.Visibility = Visibility.Collapsed;
                        resize.Visibility = Visibility.Visible;
                        break;
                    }
                case (WindowState.Normal):
                    {
                        ResizeMode = ResizeMode.NoResize;
                        WindowState = WindowState.Maximized;
                        PART_MAXIMISE.Visibility = Visibility.Collapsed;
                        PART_RESTORE.Visibility = Visibility.Visible;
                        resize.Visibility = Visibility.Collapsed;
                        break;
                    }
            }
        }

        #endregion

        private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PART_TITLE_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MaximiseWindow();
        }

        private void PART_TITLE_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void PART_TITLE_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && WindowState == WindowState.Maximized)
            {
                ResizeMode = ResizeMode.CanResize;
                WindowState = WindowState.Normal;
                PART_MAXIMISE.Visibility = Visibility.Visible;
                PART_RESTORE.Visibility = Visibility.Collapsed;
                resize.Visibility = Visibility.Visible;

                System.Windows.Point position = e.GetPosition(this);
                this.Left = position.X - this.Width / 2;
                this.Top = position.Y - 15;

                DragMove();
            }
        }

        private void PART_MAXIMIZE_RESTORE_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MaximiseWindow();
        }

        private void PART_MINIMISE_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        #endregion


        #region Window Resize

        private void Resize(object sender, MouseButtonEventArgs e)
        {
            ob.resizeWindow(sender);
        }

        private void DisplayResizeCursor(object sender, MouseEventArgs e)
        {
            ob.displayResizeCursor(sender);
        }

        private void ResetCursor(object sender, MouseEventArgs e)
        {
            ob.resetCursor();
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            ob.dragWindow();
        }

        #endregion


        #endregion



        #region Menu


        #region Mode


        // Swicth To Normal Mode
        private void NormalMode_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (NormalMode.IsChecked)
            {
                // set the gridsplitter size
                DataGridsGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Pixel);
                FolderGrid.Visibility = DataGridsGridSplitter.Visibility = FolderNumberBtn.Visibility = RenameSelBtn.Visibility = AddFolderBtn.Visibility = AddSubFoldersBtn.Visibility = Visibility.Collapsed;

                // define the Main Window animation
                DoubleAnimation mainWindow = new DoubleAnimation();
                mainWindow.From = WindowWidth;
                mainWindow.To = WindowWidth - 350;


                // define the DatagridsGrid animation
                AnimatableGrid datagridsGrid = new AnimatableGrid();
                datagridsGrid.From = new GridLength(DatagridWidth, GridUnitType.Star);
                datagridsGrid.To = new GridLength(DatagridWidth - 350, GridUnitType.Star);


                // define the FolderGrid animation
                AnimatableGrid folderGrid = new AnimatableGrid();
                folderGrid.From = new GridLength(1, GridUnitType.Star);
                folderGrid.To = new GridLength(0, GridUnitType.Star);


                // define the duration of animations
                mainWindow.Duration = datagridsGrid.Duration = new TimeSpan(0, 0, 0, 0, 100);


                // execute animations and set the fill behavior (to get the gridsplitter to work correctly)
                this.BeginAnimation(FrameworkElement.WidthProperty, mainWindow);

                datagridsGrid.FillBehavior = FillBehavior.Stop;
                CenterMainGrid.ColumnDefinitions[2].Width = new GridLength(DatagridWidth - 350, GridUnitType.Star);
                CenterMainGrid.ColumnDefinitions[2].BeginAnimation(ColumnDefinition.WidthProperty, datagridsGrid);

                folderGrid.FillBehavior = FillBehavior.Stop;
                DataGridsGrid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
                DataGridsGrid.ColumnDefinitions[0].BeginAnimation(ColumnDefinition.WidthProperty, folderGrid);

            }
            else { NormalMode.IsChecked = true; }

        }

        // Switch to Advanced Mode
        private void AdvancedMode_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AdvancedMode.IsChecked)
            {
                // set visiblities and size
                FolderGrid.Visibility = DataGridsGridSplitter.Visibility = FolderNumberBtn.Visibility = RenameSelBtn.Visibility = AddFolderBtn.Visibility = AddSubFoldersBtn.Visibility = Visibility.Visible;
                DataGridsGrid.ColumnDefinitions[1].Width = new GridLength(10, GridUnitType.Pixel);


                // define the Main Window animation
                DoubleAnimation mainWindow = new DoubleAnimation();
                mainWindow.From = WindowWidth;
                mainWindow.To = WindowWidth + 350;
                

                // define the DatagridsGrid animation
                AnimatableGrid datagridsGrid = new AnimatableGrid();
                datagridsGrid.From = new GridLength(DatagridWidth, GridUnitType.Star);
                datagridsGrid.To = new GridLength(DatagridWidth + 350, GridUnitType.Star);


                // define the FolderGrid animation
                AnimatableGrid folderGrid = new AnimatableGrid();
                folderGrid.From = new GridLength(0, GridUnitType.Star);
                folderGrid.To = new GridLength(1, GridUnitType.Star);


                // define the duration of animations
                mainWindow.Duration = datagridsGrid.Duration = folderGrid.Duration = new TimeSpan(0, 0, 0, 0, 300);


                // execute animations and set the fill behavior (to get the gridsplitter to work correctly)
                this.BeginAnimation(FrameworkElement.WidthProperty, mainWindow);


                datagridsGrid.FillBehavior = FillBehavior.Stop;
                CenterMainGrid.ColumnDefinitions[2].Width = new GridLength(DatagridWidth + 350, GridUnitType.Star);
                CenterMainGrid.ColumnDefinitions[2].BeginAnimation(ColumnDefinition.WidthProperty, datagridsGrid);


                folderGrid.FillBehavior = FillBehavior.Stop;
                DataGridsGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                DataGridsGrid.ColumnDefinitions[0].BeginAnimation(ColumnDefinition.WidthProperty, folderGrid);


            }
            else { AdvancedMode.IsChecked = true; }

        }

        // Get the Explorer grid and Datagrid grid width
        private void GetColumnWidth(object sender, MouseButtonEventArgs e)
        {
            WindowWidth = this.ActualWidth;
            ExplorerWidth = CenterMainGrid.ColumnDefinitions[0].ActualWidth;
            DatagridWidth = CenterMainGrid.ColumnDefinitions[2].ActualWidth;
        }


        #endregion


        #region Increment


        //// Set the increment padding menu
        //private void SetIncrement(MenuItem item)
        //{
        //    DefaultPadding.IsChecked = NoPadding.IsChecked = TenPadding.IsChecked = HundredPadding.IsChecked = ThousandPadding.IsChecked = TenThousandPadding.IsChecked = HundredThousandPadding.IsChecked = MillionPadding.IsChecked = false;
        //    item.IsChecked = true;

        //    if (item == TenPadding) { IncrementValue = 2; }
        //    else if (item == HundredPadding) { IncrementValue = 3; }
        //    else if (item == ThousandPadding) { IncrementValue = 4; }
        //    else if (item == TenThousandPadding) { IncrementValue = 5; }
        //    else if (item == HundredThousandPadding) { IncrementValue = 6; }
        //    else if (item == MillionPadding) { IncrementValue = 7; }
        //    else { IncrementValue = 0; }
        //}

        // Set the increment padding menu
        private void IncrementPadding_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = e.OriginalSource as MenuItem;
            DefaultPadding.IsChecked = NoPadding.IsChecked = TenPadding.IsChecked = HundredPadding.IsChecked = ThousandPadding.IsChecked = TenThousandPadding.IsChecked = HundredThousandPadding.IsChecked = MillionPadding.IsChecked = false;
            item.IsChecked = true;

            if (TenPadding.IsChecked) { IncrementValue = 2; }
            else if (HundredPadding.IsChecked) { IncrementValue = 3; }
            else if (ThousandPadding.IsChecked) { IncrementValue = 4; }
            else if (TenThousandPadding.IsChecked) { IncrementValue = 5; }
            else if (HundredThousandPadding.IsChecked) { IncrementValue = 6; }
            else if (MillionPadding.IsChecked) { IncrementValue = 7; }
            else { IncrementValue = 0; }
        }

        #endregion


        #region Historic

        // Set the visibility of the expander icon
        private void ExpanderVisibility(bool state)
        {
            RenameTxt.ShowExpander(state);
            ReplaceTxt.ShowExpander(state);
            WithTxt.ShowExpander(state);
            PrefixTxt.ShowExpander(state);
            SuffixTxt.ShowExpander(state);
        }

        // Set the textbox historic to individual or common
        private void TextBoxHistoric_Click(object sender, RoutedEventArgs e)
        {
            // get the clicked submenu and show the expander when needed
            if ((e.OriginalSource as MenuItem) == CommonHistoric)
            {
                SetCommonHistoricMode(true);
                RenameTxt.ActiveHistory = ReplaceTxt.ActiveHistory = WithTxt.ActiveHistory = PrefixTxt.ActiveHistory = SuffixTxt.ActiveHistory = false;

                if (historicCommon.Count > 0)
                {
                    ExpanderVisibility(true);
                }
                else
                {
                    ExpanderVisibility(false);
                }
            }
            else
            {
                SetCommonHistoricMode(false);
                RenameTxt.ActiveHistory = ReplaceTxt.ActiveHistory = WithTxt.ActiveHistory = PrefixTxt.ActiveHistory = SuffixTxt.ActiveHistory = true;

                if (RenameTxt.History.Count > 0) { RenameTxt.ShowExpander(true); }
                else { RenameTxt.ShowExpander(false); }
                if (ReplaceTxt.History.Count > 0) { ReplaceTxt.ShowExpander(true); }
                else { ReplaceTxt.ShowExpander(false); }
                if (WithTxt.History.Count > 0) { WithTxt.ShowExpander(true); }
                else { WithTxt.ShowExpander(false); }
                if (PrefixTxt.History.Count > 0) { PrefixTxt.ShowExpander(true); }
                else { PrefixTxt.ShowExpander(false); }
                if (SuffixTxt.History.Count > 0) { SuffixTxt.ShowExpander(true); }
                else { SuffixTxt.ShowExpander(false); }
            }

        }

        // Set the historic mode
        private void SetCommonHistoricMode(bool state)
        {
            CommonHistoric.IsChecked = state;
            IndividualHistoric.IsChecked = !state;
            historicCommonMode = state;
        }


        #endregion


        #endregion



        #region TextBox

        // Set the rename buttons enabled state
        private void RenameBtnsEnabled()
        {
            if (RenameBtn.IsChecked == true)
            {
                if (!RenameTxt.IsEmpty() && RenameTxt.EditMode) { RenameSelBtn.IsEnabled = RenameAllBtn.IsEnabled = true; }
                else { RenameSelBtn.IsEnabled = RenameAllBtn.IsEnabled = false; }
            }
            else
            {

                if (!ReplaceTxt.IsEmpty() && ReplaceTxt.EditMode) { RenameSelBtn.IsEnabled = RenameAllBtn.IsEnabled = true; }
                else if (!ReplaceTxt.IsEmpty() && ReplaceTxt.EditMode && !WithTxt.IsEmpty() && WithTxt.EditMode) { RenameSelBtn.IsEnabled = RenameAllBtn.IsEnabled = true; }
                else if (!PrefixTxt.IsEmpty() && PrefixTxt.EditMode) { RenameSelBtn.IsEnabled = RenameAllBtn.IsEnabled = true; }
                else if (!SuffixTxt.IsEmpty() && SuffixTxt.EditMode) { RenameSelBtn.IsEnabled = RenameAllBtn.IsEnabled = true; }
                else if (TrimStartSpn.NumValue > 0 || TrimEndSpn.NumValue > 0) { RenameSelBtn.IsEnabled = RenameAllBtn.IsEnabled = true; }
                else { RenameSelBtn.IsEnabled = RenameAllBtn.IsEnabled = false; }
            }

        }

        // Choose the renaming mode
        private void RenameChoose(object sender, RoutedEventArgs e)
        {
            RenameBtnsEnabled();
            FileNumberBtn.IsEnabled = false;
            FileNumberBtn.IsChecked = false;
        }


        // Check if a string contain unauthorized filename characters
        private bool IsAuthorized(string strToTest)
        {
            return strToTest.IndexOfAny("\\/:*?\"<>|".ToCharArray()) == -1;
        }


        // Check if a string exist in all checked files
        public bool ContainsString(string strToTest)
        {
            for (int i = 0; i < FilesList.Count; i++)
            {
                if (FilesList[i].Checked && !((FilesList[i].Text).Contains(strToTest)))
                {
                    return false;
                }
            }
            return true;

        }


        // Show the expander icon if the history isn't empty
        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (historicCommonMode && historicCommon.Count > 0)
            {
                ExpanderVisibility(true);

            }
        }

        // Add to common history
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (historicCommonMode && e.Key == Key.Return)
            {
                // set the expander visibility
                if (historicCommon.Count == 0)
                {
                    ExpanderVisibility(true);
                }

                // Delete File and Folder Number
                TextBoxHint _sender = sender as TextBoxHint;
                string _text = _sender.Text;
                if (_sender.FolderNumber)
                {
                    _text = _sender.Text.Replace("<FolderNumber>", "");
                }
                if (_sender.FileNumber)
                {
                    _text = _sender.Text.Replace("<FileNumber>", "");
                }

                // Update the history list
                if (!historicCommon.Contains(_text))
                {
                    historicCommon.Insert(0, _text);
                    if (historicCommon.Count > _historicLimit)
                    {
                        historicCommon.Remove(historicCommon[_historicLimit]);
                    }

                }
            }
        }


        // check if the new character is authorized
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Prohibit non-alphabetic
            if (!IsAuthorized(e.Text))
            {
                e.Handled = true;
                Message.IsActive(0);
            }
                
            
        }


        // handle the paste event to check if it doesn't contain unauthorized characters
        private void PasteHandler(object sender, DataObjectPastingEventArgs e)
        {
            TextBox tb = sender as TextBox;
            bool textOK = false;

            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                // Allow pasting only alphabetic
                string pasteText = e.DataObject.GetData(typeof(string)) as string;
                if (IsAuthorized(pasteText))
                    textOK = true;
            }

            if (!textOK) 
            { 
                e.CancelCommand();
                Message.IsActive(0);
            }
                
        }


        // Set the rename buttons enabled state and check if the rename text exit in checked files
        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RenameBtnsEnabled();

            // if sender is replacetxt, check if its text exist in selected files
            if (((TextBoxHint)sender).Name.Equals("ReplaceTxt"))
            {
                ReplaceTxtShowWarning();
            }
        }

        // Check if the replace textbox text exist in checked files
        private void ReplaceTxtShowWarning()
        {
            if (!ReplaceTxt.IsEmpty() && ReplaceTxt.EditMode && FilesDG.Items.Count > 0 && !ContainsString(ReplaceTxt.Text))
            {
                ReplaceTxt.ShowWarning(true);
            }
            else
            {
                ReplaceTxt.ShowWarning(false);
            }
        }


        // Set the rename buttons enabled state
        private void Textbox_LostFocus(object sender, RoutedEventArgs e)
        {
            RenameBtnsEnabled();
        }


        // Set the rename buttons enabled state and set the actuel textbox
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            FileNumberBtn.IsEnabled = true;
            LastTextBox = (TextBoxHint)sender;
            if (LastTextBox.FileNumber)
            {
                FileNumberBtn.IsChecked = true;
            }
            else
            {
                FileNumberBtn.IsChecked = false;
            }
        }


        // Set the rename buttons enabled state and store the spinner new value
        private void Spinner_ValueChanged(object sender, EventArgs e)
        {
            RenameBtnsEnabled();
            if ((Spinner)sender == TrimStartSpn) 
            { 
                TrimStart = ((Spinner)sender).NumValue; 
            }
            else 
            { 
                TrimEnd = ((Spinner)sender).NumValue; 
            }
        }


        // add folder number to selected textbox
        private void FolderNumberBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LastTextBox.FolderNumber)
            {
                LastTextBox.Text = (LastTextBox.Text).Replace("<FolderNumber>", "");
                LastTextBox.FolderNumber = false;
                LastTextBox.SetCaret();
                LastTextBox.Focus();
            }
            else
            {
                if (!LastTextBox.EditMode) { LastTextBox.SetEdit(); }
                LastTextBox.Text = (LastTextBox.Text).Insert(LastTextBox.CaretIndex, "<FolderNumber>");
                LastTextBox.FolderNumber = true;
                LastTextBox.SetCaret();
                LastTextBox.Focus();
            }
        }


        // add file number to selected textbox
        private void FileNumberBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LastTextBox.FileNumber)
            {
                LastTextBox.Text = (LastTextBox.Text).Replace("<FileNumber>", "");
                LastTextBox.FileNumber = false;
                LastTextBox.SetCaret();
                LastTextBox.Focus();
            }
            else
            {
                if (!LastTextBox.EditMode) { LastTextBox.SetEdit(); }
                LastTextBox.Text = (LastTextBox.Text).Insert(LastTextBox.CaretIndex, "<FileNumber>");
                LastTextBox.FileNumber = true;
                LastTextBox.SetCaret();
                LastTextBox.Focus();
            }
        }


        // Show and define the history popup
        private void Textbox_HistoryIconMouseUp(object sender, EventArgs e)
        {
            List<string> _history = new List<string>();
            if (historicCommonMode)
            {
                _history = historicCommon;
            }
            else
            {
                _history = ((TextBoxHint)sender).History;
            }

            //List<string> _history = ((TextBoxHint)sender).History;


            
            if (_history.Count > 0)
            {
                List<HistoryItem> _historyItems = new List<HistoryItem>();
                foreach (string text in _history)
                {
                    HistoryItem _historyItem = new HistoryItem(text, false);
                    _historyItems.Add(_historyItem);
                }

                HistoryDG.ItemsSource = _historyItems;
                HistoryPopup.IsOpen = true;
            }
        }


        // Set the Textbox text as the selected one in the history
        private void HistoryLabel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LastTextBox.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            LastTextBox.EditMode = true;

            // Replace only custom text in textbox and keep folder and file number
            string _text = LastTextBox.Text;
            int _folderNumberIndex = new int();
            int _fileNumberIndex = new int();
            if (LastTextBox.FolderNumber)
            {
                _folderNumberIndex = _text.IndexOf("<FolderNumber>");
                _text = _text.Replace("<FolderNumber>", "");
                if (_folderNumberIndex == _text.Length)
                {
                    _folderNumberIndex = -1;
                }
            }
            if (LastTextBox.FileNumber)
            {
                _fileNumberIndex = _text.IndexOf("<FileNumber>");
                _text = _text.Replace("<FileNumber>", "");
                if (_fileNumberIndex == _text.Length)
                {
                    _fileNumberIndex = -1;
                }
            }

            LastTextBox.Text = ((Label)sender).Content.ToString();

            if (LastTextBox.FolderNumber)
            {
                if (LastTextBox.Text.Length < _folderNumberIndex || _folderNumberIndex == -1)
                {
                    LastTextBox.Text = (LastTextBox.Text).Insert(LastTextBox.Text.Length, "<FolderNumber>");
                }
                else
                {
                    LastTextBox.Text = (LastTextBox.Text).Insert(_fileNumberIndex, "<FolderNumber>");
                }
            }
            if (LastTextBox.FileNumber)
            {
                if (LastTextBox.Text.Length < _fileNumberIndex || _fileNumberIndex == -1)
                {
                    LastTextBox.Text = (LastTextBox.Text).Insert(LastTextBox.Text.Length, "<FileNumber>");
                }
                else
                {
                    LastTextBox.Text = (LastTextBox.Text).Insert(_fileNumberIndex, "<FileNumber>");
                }
                
            }

            LastTextBox.SetCaret();
            LastTextBox.Focus();
            HistoryPopup.IsOpen = false;
        }


        // Don't affect the textbox
        private void HistoryCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (!LastTextBox.EditMode)
            {
                LastTextBox.SetEdit();
                LastTextBox.Focus();
            }
        }


        // Show warning message
        private void ReplaceTxt_WarningIconMouseUp(object sender, EventArgs e)
        {
            Message.IsActive(2);
        }

        #endregion



        #region TreeView

        // Build the base treeview 
        private void ExplorerTv_Loaded(object sender, RoutedEventArgs e)
        {
            //create root node "Computer"
            ExplorerTvItem computer = new ExplorerTvItem();
            computer.TV.Header = "Computer";
            computer.ItemType = ExplorerTvItem.NodeType.Computer;
            computer.IsExpanded = true;
            ((TreeView)sender).Items.Add(computer);

            //add HDDs to computer treenode
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    ExplorerTvItem hdd = new ExplorerTvItem();
                    hdd.Header = drive.Name;
                    hdd.Tag = drive.Name;
                    hdd.ItemType = ExplorerTvItem.NodeType.Hdd;

                    hdd.Items.Add(dummyNode);
                    hdd.Expanded += new RoutedEventHandler(Folder_Expanded);

                    computer.Items.Add(hdd);

                }

            }

        }


        /*private void ExplorerTv_Loaded(object sender, RoutedEventArgs e)
        {
            //add local network computers as root nodes
            DirectoryEntry root = new DirectoryEntry("WinNT:");
            foreach (DirectoryEntry computers in root.Children)
            {
                foreach (DirectoryEntry computer in computers.Children)
                {
                    if (computer.Name != "CLEMENT" && computer.Name != "Schema")
                    {
                        ExplorerTvItem networkComputer = new ExplorerTvItem();
                        networkComputer.TV.Header = computer.Name;
                        networkComputer.ItemType = ExplorerTvItem.NodeType.Computer;
                        networkComputer.IsExpanded = true;
                        ((TreeView)sender).Items.Add(networkComputer);

                        //string _tempstring = @"\\WORKGROUP\" + computer.Name + "\\share";
                        //Debug.WriteLine(@"\\WORKGROUP\" + computer.Name + "\share");
                        //var folders = Directory.GetDirectories(@"\\WORKGROUP\" + computer.Name + "\\share");
                        //foreach (var dir in folders)
                        //{
                        //    ExplorerTvItem folder = new ExplorerTvItem();
                        //    folder.Header = dir.ToString();
                        //    //folder.Tag = dir.FullName;
                        //    folder.ItemType = ExplorerTvItem.NodeType.Folder;
                        //    networkComputer.Items.Add(folder);
                        //}


                    }
                }
            }
        }*/

        // Dynamically fill the treview
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            ExplorerTvItem item = (ExplorerTvItem)sender;

            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    // create the unhidden subfolder list
                    var directory = new DirectoryInfo(item.Tag.ToString()).GetDirectories().Where(x => (x.Attributes & FileAttributes.Hidden) == 0);

                    // add the list the the expanded item
                    foreach (var dir in directory)
                    {
                        ExplorerTvItem folder = new ExplorerTvItem();
                        folder.Header = dir.ToString();
                        folder.Tag = dir.FullName;
                        folder.ItemType = ExplorerTvItem.NodeType.Folder;
                        item.Items.Add(folder);
                    }

                    // check if folders in the list contains visible subfolders to add them a dummynode
                    foreach (ExplorerTvItem folder in item.Items)
                    {
                        var subDir = new DirectoryInfo(folder.Tag.ToString()).GetDirectories().Where(x => (x.Attributes & FileAttributes.Hidden) == 0);

                        if ((subDir.ToList()).Count > 0)
                        {
                            folder.Items.Add(dummyNode);
                            folder.Expanded += new RoutedEventHandler(Folder_Expanded);
                        }
                    }

                }

                catch (Exception) { }

            }



        }

        // Get the treeview selected item full path
        private void ExplorerTv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                // define the new item
                ExplorerTvItem item = (ExplorerTvItem)e.NewValue;
                folderPath = item.Tag.ToString();

                if (NormalMode.IsChecked)
                {
                    // Reset the files list
                    FilesList.Clear();

                    // check if the selected item already contain a file list
                    if (item.TVItemFiles != null) { foreach (ItemDG items in item.TVItemFiles) { FilesList.Add(items); } }
                    else
                    {
                        // create the folder's file list
                        foreach (string s in Directory.GetFiles(folderPath))
                        {
                            string name = System.IO.Path.GetFileNameWithoutExtension(s);
                            string ext = (System.IO.Path.GetExtension(s)).TrimStart((".").ToCharArray());

                            FilesList.Add(new ItemDG(FilesList.Count + 1, name) { Checked = true, DotExt = ext });
                        }
                    }

                    // fill the Files DG
                    FillFilesDG(0);

                    // Check if the replace textbox text is still valide
                    ReplaceTxtShowWarning();
                }

                //enabled treeview buttons
                else { AddFolderBtn.IsEnabled = AddSubFoldersBtn.IsEnabled = true; }

            }
            catch (Exception) { }
        }

        #endregion



        #region Datagrids

        #region Functions

        // define the enabled state of datagrids buttons
        private void DGBtnsEnabled(DataGrid sender)
        {
            // define the buttons
            List<Button> buttons = new List<Button>();
            if (sender == FilesDG)
            {
                buttons.Add(UpFilesBtn);
                buttons.Add(TopFilesBtn);
                buttons.Add(DownFilesBtn);
                buttons.Add(BottomFilesBtn);
            }
            else
            {
                buttons.Add(UpFoldersBtn);
                buttons.Add(TopFoldersBtn);
                buttons.Add(DownFoldersBtn);
                buttons.Add(BottomFoldersBtn);
            }


            // define the current datagrid selected item index
            List<int> index = new List<int>();
            for (int i = 0; i < sender.SelectedItems.Count; i++)
            {
                index.Add(sender.Items.IndexOf(sender.SelectedItems[i]));
            }


            if (index.Contains(0) && index.Contains(sender.Items.Count - 1))
            {
                buttons[0].IsEnabled = buttons[2].IsEnabled = false;
                buttons[1].IsEnabled = buttons[3].IsEnabled = true;
            }
            else if (index.Contains(0))
            {
                buttons[0].IsEnabled = false;
                buttons[1].IsEnabled = buttons[2].IsEnabled = buttons[3].IsEnabled = true;
            }
            else if (index.Contains(sender.Items.Count - 1))
            {
                buttons[2].IsEnabled = false;
                buttons[0].IsEnabled = buttons[1].IsEnabled = buttons[3].IsEnabled = true;
            }
            else buttons[0].IsEnabled = buttons[1].IsEnabled = buttons[2].IsEnabled = buttons[3].IsEnabled = true;



        }


        // get the selected folder's files
        private List<ItemDG> GetFolderFiles(string folder)
        {
            // define a temps file list
            List<ItemDG> tempFilesList = new List<ItemDG>();


            // create the folder's file list
            foreach (string s in Directory.GetFiles(folder))
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(s);
                string ext = (System.IO.Path.GetExtension(s)).TrimStart((".").ToCharArray());

                tempFilesList.Add(new ItemDG(tempFilesList.Count + 1, name) { DotExt = ext });

            }

            return tempFilesList;
        }


        // actualise folder datagrid
        private void FillFolderDG()
        {
            // reset both DGs and fill the folder DG
            FoldersDG.ItemsSource = null;


            // fill the folderDG and select first new item
            FoldersDG.ItemsSource = FoldersList;

        }


        // actualise files datagrid
        private void FillFilesDG(int index)
        {
            // Reset the Files DG
            FilesDG.ItemsSource = null;

            // Fill the file DG on normal mode
            if (NormalMode.IsChecked) { FilesDG.ItemsSource = FilesList; }

            // Get the selected item in folderDG to fill the fileDG
            else { FilesDG.ItemsSource = FoldersList[FoldersDG.SelectedIndex].Files; }
            
            // Set the selected item index
            FilesDG.SelectedIndex = index;

            // Enable datagrid buttons
            DGBtnsEnabled(FilesDG);

        }


        // Move datagrid items
        private void MoveDatagridItem(DataGrid sender, string type, List<ItemDG> List)
        {
            // define a datagrid item to move
            ItemDG Item;

            //define the new selected item to be the first selected item
            int newIndex = new int(); 
            switch (type)
            {
                case "Up": newIndex = sender.Items.IndexOf(sender.SelectedItems[0]) - 1; break;
                case "Top": newIndex = 0; break;
                case "Down": newIndex = sender.Items.IndexOf(sender.SelectedItems[0]) + 1; break;
                case "Bottom": newIndex = sender.Items.Count - sender.SelectedItems.Count; break;
            }

            // Move selected items
            for (int i = 0; i < sender.SelectedItems.Count; i++)
            {
                int index = sender.Items.IndexOf(sender.SelectedItems[i]);
                Item = List[index];
                List.RemoveAt(index);

                switch (type)
                {
                    case "Up": List.Insert(index - 1, Item); break;
                    case "Top": List.Insert(i, Item); break;
                    case "Down": List.Insert(index + sender.SelectedItems.Count, Item); break;
                    case "Bottom": List.Insert(sender.Items.Count, Item); break;

                }

            }

            // rebuild list number
            for (int i = 0; i < List.Count; i++) { List[i].Number = i + 1; }

            // actualise datagrids
            if (NormalMode.IsChecked == true) { FillFilesDG(newIndex); }

        }


        // store current FilesList to selected TreeView Item
        private void TVItemStoreFiles()
        {
            ExplorerTvItem item = ExplorerTv.SelectedItem as ExplorerTvItem;
            if (NormalMode.IsChecked)
            {
                item.TVItemFiles = new List<ItemDG>();
                foreach (ItemDG items in FilesList) { item.TVItemFiles.Add(items); }
            }
        }
        

        #endregion


        // Assign to the selected treeview item the current FilesList
        private void FilesDG_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            TVItemStoreFiles();
            
        }

        // Force the FilesList to update on the checkbox state
        private void FilesDGCheckBox_Click(object sender, RoutedEventArgs e)
        {
            TVItemStoreFiles();
        }

        // Get the Number to check increment padding
        private void FilesDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            // define the new value
            TextBox t = e.EditingElement as TextBox;  // Assumes columns are all TextBoxes
            string newValue = t.Text;

            // define the column
            DataGridColumn dgc = e.Column;
            string header = dgc.Header.ToString();

            // Show the message if the new value is higher than the actuel increment
            if (dgc.Header.ToString() == "N°" && IncrementValue != 0 && newValue.Length > IncrementValue)
            {
                Message.IsActive(1);
            }

        }

        // Actualise datagrid buttons
        private void FilesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DGBtnsEnabled((DataGrid)sender);
        }

        #region Move Item


        // Move Up Datagrid Item
        private void UpItemDG(object sender, RoutedEventArgs e)
        {
            MoveDatagridItem(FilesDG, "Up", FilesList);
            TVItemStoreFiles();
        }

        // Move Top Datagrid Item
        private void TopItemDG(object sender, RoutedEventArgs e)
        {
            MoveDatagridItem(FilesDG, "Top", FilesList);
            TVItemStoreFiles();
        }

        // Move down Datagrid Item
        private void DownItemDG(object sender, RoutedEventArgs e)
        {
            MoveDatagridItem(FilesDG, "Down", FilesList);
            TVItemStoreFiles();
        }

        // Move bottom Datagrid Item
        private void BottomItemDG(object sender, RoutedEventArgs e)
        {
            MoveDatagridItem(FilesDG, "Bottom", FilesList);
            TVItemStoreFiles();
        }


        #endregion


        #endregion



        #region Datagrid Right Click Menu

        private void FilesDG_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            FilesDG.Focus();

            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while ((dep != null) && !(dep is DataGridCell))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            if (dep == null) return;

            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;
                //cell.Focus();

                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                DataGridRow row = dep as DataGridRow;
                FilesDG.SelectedItem = row.DataContext;
                FilePath = folderPath + "\\" + FilesList[FilesDG.SelectedIndex].Text + "." + FilesList[FilesDG.SelectedIndex].DotExt;

                PopupDG.IsOpen = true;
                PopupDG.Tag = GetName(FilesList[FilesDG.SelectedIndex].Text, FilesDG.SelectedIndex) + "." + FilesList[FilesDG.SelectedIndex].DotExt;
            }
        }


        private void Open_Click(object sender, RoutedEventArgs e)
        {
            PopupDG.IsOpen = false;
            //FilesDG.Focus();
            Process.Start(FilePath);
        }


        private void Show_Click(object sender, RoutedEventArgs e)
        {
            PopupDG.IsOpen = false;
            //FilesDG.Focus();
            string argument = "/select, \"" + FilePath + "\"";
            Process.Start("explorer.exe", argument);
        }

        #endregion



        #region Rename

        #region Methods

        #region Name

        private string Replace(string name, int i)
        {
            string replace = CheckTextBoxText(ReplaceTxt, i);
            string with = CheckTextBoxText(WithTxt, i);
            return name.Replace(replace, with);
        }

        
        // Get the text of specified textbox
        private string CheckTextBoxText(TextBoxHint txt, int i)
        {
            if (!txt.IsEmpty() && txt.EditMode)
            {
                if (txt.FileNumber) return (txt.Text).Replace("<FileNumber>", Increment(FilesList[i].Number.ToString()));
                else return txt.Text;
            }
            else return string.Empty;

        }


        private string GetName(string name, int i)
        {
            if (RenameBtn.IsChecked == true)
            {
                if (RenameTxt.FileNumber) return CheckTextBoxText(RenameTxt, i);
                else return (CheckTextBoxText(RenameTxt, i) + Increment(FilesList[i].Number.ToString()));
            }
            else
            {
                // set the name
                if (CheckTextBoxText(ReplaceTxt, i) != String.Empty)
                    name = Replace(name, i);

                // trim end
                if (TrimEnd > 0)
                {
                    int length = name.Length - TrimEnd;
                    name = name.Remove(length, TrimEnd);
                }

                // trim start
                if (TrimStart > 0) name = name.Remove(0, TrimStart);


                // add prefix and suffix 
                name = (CheckTextBoxText(PrefixTxt, i) + name + CheckTextBoxText(SuffixTxt, i));

                // check if increment is already set
                if (!WithTxt.FileNumber && !PrefixTxt.FileNumber && !SuffixTxt.FileNumber)
                    name += Increment(FilesList[i].Number.ToString());
                
                return name;

            }
        }

        #endregion


        #region Increment

        private string AddZero(string Incr, int Length)
        {
            while (Incr.Length < Length) { Incr = "0" + Incr; }
            return Incr;
        }


        private string Increment(string CurrentNB)
        {
            // Default Case
            if (DefaultPadding.IsChecked)
            {
                // find the biggest number in the files list number
                int Length = 0;
                foreach (ItemDG item in FilesList)
                {
                    if (item.Checked && item.Number.ToString().Length > Length) { Length = item.Number.ToString().Length; }
                }

                // Add zeros before current number if it doesn't reach length
                return AddZero(CurrentNB, Length); 
            }

            // User input case
            else if (NoPadding.IsChecked) { return CurrentNB; }

            // Fixed Cases
            else if (TenPadding.IsChecked) { return AddZero(CurrentNB, 2); }
            else if (HundredPadding.IsChecked) { return AddZero(CurrentNB, 3); }
            else if (ThousandPadding.IsChecked) { return AddZero(CurrentNB, 4); }
            else if (TenThousandPadding.IsChecked) { return AddZero(CurrentNB, 5); }
            else if (HundredThousandPadding.IsChecked) { return AddZero(CurrentNB, 6); }
            else { return AddZero(CurrentNB, 7); }
        }

        #endregion


        #endregion


        private void RenameAllBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < FilesList.Count; i++)
            {
                if (FilesList[i].Checked) {
                    //Console.WriteLine(FilesList[i].Text + "\n\t" + GetName(FilesList[i].Text) + Increment(FilesList[i].Number.ToString()));
                    Debug.WriteLine(FilesList[i].Text + "\n\t" + GetName(FilesList[i].Text, i));
                }
            }

        }

        

        #endregion

        

      

    }
}

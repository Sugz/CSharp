using System;
using System.Collections.Generic;
using System.Text;
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

namespace File_Renamer
{
	/// <summary>
	/// Interaction logic for MessageBox.xaml
	/// </summary>
	public partial class MessageUser : UserControl
	{
		// define the messages
		string messageFileName = "A filename cannot contain any of following characters : \n\t       \\  /  :  *  ?  \"  <  >  |";
		string messageIncrement = "The Number you set is higher than the actual  Increment Padding. \nYou can modify it in FileRenamer > Increment Padding";
		string messageWarning = "The text you entered in the Replace textbox doesn't exist in all the selected files.";


		// define the animation
		Storyboard anim;

	   
		public MessageUser()
		{
			this.InitializeComponent();
			anim = (Storyboard)this.FindResource("IsActive");
		}


		// execute the animation
		/// <summary>
		/// Lunch the message animation with selected text
		/// </summary>
		/// <param name="message">Selected Text</param>
		public void IsActive(int message)
		{
			//if (message.Equals(1))
			switch(message)
			{
				case 0:
					MessageTxt.Text = messageFileName;
					break;
				case 1:
					MessageTxt.Text = messageIncrement;
					break;
				case 2:
					MessageTxt.Text = messageWarning;
					break;
			}


			anim.Begin();
		}


	}
}
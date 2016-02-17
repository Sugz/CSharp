using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SugzControls
{
    public class SugzImage : ContentPresenter
    {

        #region Constructors


        public SugzImage(string source)
        {
            Width = double.NaN;
            Height = double.NaN;

            // Get the source extension
            string ext = Path.GetExtension(source);

            // Set xaml file as Content
            if (ext.Equals("xaml"))
            {
                Content = XamlReader.Load(new FileStream(source, FileMode.Open));
            }
            
            // Set image as Content
            else
            {
                Image image = new Image();
                ImageSource imgSource = new BitmapImage(new Uri(source));
                image.Source = imgSource;
                Content = image;
            }

        }


        #endregion


    }
}

using HowToCopyEventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly CopyEventHandlers _copyHelper = new CopyEventHandlers();

        public MainWindow()
        {
            InitializeComponent();

            textBox1.TextChanged += (s, e) => Console.WriteLine("Hi there from handler 1");
            textBox1.TextChanged += (s, e) => Console.WriteLine("Hi there from handler 2");
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            _copyHelper.GetHandlersFrom(textBox1).CopyTo(textBox2);
        }
    }
}

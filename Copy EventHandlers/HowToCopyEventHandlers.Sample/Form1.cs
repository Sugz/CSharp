
namespace HowToCopyEventHandlers.Sample {
    using System;
    using System.Windows.Forms;

    public partial class Form1 : Form {
        readonly CopyEventHandlers _copyHelper = new CopyEventHandlers();
        
        public Form1() {
            InitializeComponent();
            AttachHandlers();
        }        

        private void AttachHandlers() {
            textBox1.TextChanged += (s, e) => MessageBox.Show("Hi there from handler 1");
            textBox1.TextChanged += (s, e) => MessageBox.Show("Hi there from handler 2");
        }

        private void button1_Click(object sender, EventArgs e) {
            //Well... get the handlers from textBox1 and copy them to the textBox2 ;-)
            _copyHelper.GetHandlersFrom(textBox1).CopyTo(textBox2);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB6_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
        }

        BindingList<Number> Numery = new BindingList<Number>();

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 7; i++)
            {
                var rndNumber = rnd.Next(49);
                textBox1.Text = rndNumber.ToString();
                flowLayoutPanel2.Controls.Add(GenerateNumber(rndNumber));
                Application.DoEvents();

            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
            var path = dialog.FileName;
            var fileContent = File.ReadAllText(path);

            label1.Visible = true;
            button1.Enabled = true;

            foreach (var item in fileContent
                .Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                flowLayoutPanel1.Controls.Add(GenerateNumber(Convert.ToInt32(item)));
            }


        }

        private TextBox GenerateNumber(int number)
        {
            return new TextBox()
            {
                Text = number.ToString(),
                ReadOnly = true,
                Width = 25
            };
        }

    }
}

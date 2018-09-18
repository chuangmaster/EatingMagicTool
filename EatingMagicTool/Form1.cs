using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace EatingMagicTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Parse();
        }

        private void Parse()
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("You should input property name.");
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("You should input HTML contents.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                var keyPattern = textBox2.Text;
                Regex regex = new Regex(string.Format("{0}=\"\\d*\"", keyPattern), RegexOptions.IgnoreCase);
                var matches = regex.Matches(textBox1.Text);
                if (matches.Count > 0)
                {
                    foreach (Match m in matches)
                    {
                        sb.AppendLine(m.Value);
                    }
                }
                textBox3.Text = sb.ToString().Replace(string.Format("{0}=\"", keyPattern), string.Empty).Replace("\"", string.Empty);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Parsing result should not be null or empty.");
            }
            else
            {
                saveFileDialog1.Filter = "純文字檔|*.txt";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != string.Empty)
                {
                    using (StreamWriter sw = File.CreateText(saveFileDialog1.FileName))
                    {
                        sw.WriteLine(textBox3.Text);
                    }
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Sifrovani
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SifrujBase64()
        {
            byte[] inputMessage = Encoding.Unicode.GetBytes(textBox1.Text);
            textBox2.Text = Convert.ToBase64String(inputMessage);
        }

        public string DesifrujBase64(string inputString)
        {
            string outputMessage = "";
            if (outputMessage == null)
            {
                return outputMessage;
            }

            byte[] inputConverted = Convert.FromBase64String(inputString);
            outputMessage = Encoding.Unicode.GetString(inputConverted);

            return outputMessage;
        }
    }
}

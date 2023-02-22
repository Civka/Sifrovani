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

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != null)
            {
                SifrujBase64();
            }
            else
            {
                MessageBox.Show("Není co šifrovat");
            }

            textBox3.Text = DesifrujBase64(textBox2.Text);
        }

        public string SifrujSymetric(string inputMessage, string pass)
        {
            if (String.IsNullOrEmpty(inputMessage))
            {
                throw new ArgumentException("Zadej něco k zašifrování");
            }
            if (pass.Length != 8)
            {
                MessageBox.Show("Heslo musí být dlouhé přesně 8 znaků!!!!!!");
                return "";
            }

            byte[] bytes = ASCIIEncoding.Unicode.GetBytes(pass);

            SymmetricAlgorithm cryptoProvider = SymmetricAlgorithm.Create("TripleDes");
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter streamWriter = new StreamWriter(cryptoStream);

            streamWriter.Write(inputMessage);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            streamWriter.Flush();

            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public string DesifrujSymetric(string cryptedString, string pass)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                MessageBox.Show("Zadejte řetězec k dešifrování.");
                return "";
            }
            if (pass.Length != 8)
            {
                MessageBox.Show("Heslo musí být dlouhé přesně 8 znaků!!!!!!");
                return "";
            }

            byte[] bytes = ASCIIEncoding.Unicode.GetBytes(pass);

            TripleDESCryptoServiceProvider cryptoProvider = new TripleDESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader streamReader = new StreamReader(cryptoStream);

            return streamReader.ReadToEnd();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = SifrujSymetric(textBox4.Text, textBox7.Text);
            textBox6.Text = DesifrujSymetric(textBox5.Text, textBox7.Text);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Sifrovani
{
    internal class Data
    {
        private string filePath = "../../";
        private string fileName = "data.txt";
        private string dataFilePath;

        public Data() 
        {
            dataFilePath = filePath + fileName;
        }

        public List<Uzivatele> LoadData() 
        {
            List<Uzivatele> data = new List<Uzivatele>();

            if (File.Exists(dataFilePath))
            {
                using (StreamReader sr = new StreamReader(dataFilePath, Encoding.UTF8)) 
                {
                    string heading = sr.ReadLine();
                    string row;
                    while ((row = sr.ReadLine()) !=null)
                    {
                        string[] dataArray = row.Split(';');

                        Uzivatele dataObject = new Uzivatele(dataArray[0], dataArray[1]);
                        data.Add(dataObject);
                    }
                }
            }
            return data;
        }
    }
}

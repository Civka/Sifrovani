using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sifrovani
{
    public class Uzivatele
    {
        public string Username;
        public string Password;

        public Uzivatele(string Username, string Password) 
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolmerakendust
{
    public class User
    {
        public int Id;
        public string Knimi;
        public string email;
        public string sugu;
        public int vanus;

        public User() { }

        /*public User(string Knimi, string email, string sugu, int vanus)
        {
            this.Knimi = Knimi;
            this.email = email;
            this.sugu = sugu;
            this.vanus = vanus;
        }*/
    }
}
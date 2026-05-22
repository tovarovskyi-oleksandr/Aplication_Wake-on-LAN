using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retea_Calculator
{
    public class UserInfo
    {
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public string MAC { get; set; }
        public bool PermiteSMS { get; set; }  
        public bool PermiteApel { get; set; }

        public UserInfo() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSys
{
    [Serializable]
    public class AuthData
    {
        public AuthData(string Login, string Password, string Rol, string Group)
        {
            this.login = Login;
            this.password = Password;
            this.rol = Rol;
            this.group = Group;
        }
        public AuthData()
        {

        }

        public string login { set; get; }
        public string password { set; get; }
        public string rol { set; get; }
        public string group { set; get; }
    }
}

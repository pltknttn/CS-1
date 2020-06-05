using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Utils
{
    /*Автор: Полятыкина Татьяна*/

    public static partial class AppUtils
    {
        static string _login = "root";
        static string _password = "GeekBrains";

        public static bool IsAutorize(string login, string password)
        {
            return login == _login && password == _password;
        }
    }
}

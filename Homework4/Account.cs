using System;
using System.IO;

namespace Homework4
{
    public class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{Login} {Password}";
        }
    }

    public class Accounts
    {
        private Account[] _accounts;

        public Accounts()
        { 
        }

        public Accounts(Account[] accounts) 
        {
            _accounts = accounts;
        }

        public Accounts(string fileName)
        {
            string[] ss = File.ReadAllLines(fileName);
            if (ss.Length == 0) throw new Exception("Пустой файл");

            _accounts = new Account[ss.Length / 2];
            Account _account = new Account();

            for (int i = 0; i < ss.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    _account.Password = ss[i];
                    _accounts[i / 2] = _account;
                    _account = new Account();
                }
                else
                {
                    _account.Login = ss[i];
                }
            }
        } 

        public bool IsCheck(string login, string password)
        {
            if (_accounts == null || _accounts.Length == 0) return false;

            foreach(Account account in _accounts)
            {
                if (account.Login == login && account.Password == password)
                    return true;
            }

            return false;
        }
    }
}

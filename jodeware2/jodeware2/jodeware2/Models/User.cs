using System;
using System.Collections.Generic;
using System.Text;

namespace jodeware2.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        
        public User() { }
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool CheckInformation()
        {
            if (username.Length != 0 && password.Length != 0)
            {
                return true;
            }
            else
            { 
                return false;
            }
        }



    }
}

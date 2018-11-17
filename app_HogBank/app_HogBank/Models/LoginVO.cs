using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_HogBank.Models
{
    class LoginVO
    {
        private int id;
        private string username;
        private string password;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public LoginVO(int id, string uid, string pwd)
        {
            this.id = id;
            this.username = uid;
            this.password = pwd;
        }
    }
}

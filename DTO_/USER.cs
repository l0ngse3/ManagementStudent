using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class USER
    {
        private string MaSV, password;
        private int role;

        public USER()
        {
        }

        public USER(string username, string password, int role)
        {
            this.MaSV = username;
            this.password = password;
            this.role = role;
        }

        public string Username { get => MaSV; set => MaSV = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }
    }
}

using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_USER
    {
        DAO_USER dao = new DAO_USER();
        public string checkRole(USER user)
        {
            string cmd = "select role from Users where MaSV='"+user.Username+"' and password='"+user.Password+"'";
            string role = dao.checkRole(cmd);
            return role;
        }
    }
}

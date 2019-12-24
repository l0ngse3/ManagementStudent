using DAO_Info;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_Info
{
    public class BUS_Mg_User
    {
        DAO_Mg_User dao = new DAO_Mg_User();

        public BUS_Mg_User()
        {
        }

        // <summary>
        //  Các hàm liên quan đến việc quản lý user
        // </summary>
        // <returns></returns>
        public DataTable getUserStudent()
        {
            string sql = "select * from Users where role = 0 or role = 1";
            return dao.GetUser(sql);
        }

        public DataTable searchUserStudent(string s)
        {
            string sql = "select * from Users where MaSV like '%" + s + "%' and role = 0 or role = 1";
            return dao.GetUser(sql);    
        }

        public DataTable searchUserAdmin(string s)
        {
            string sql = "select * from Users where MaSV like '%" + s + "%' and role = 2";
            return dao.GetUser(sql);
        }

        public DataTable getUserAdmin()
        {
            string sql = "select * from Users where role = 2";
            return dao.GetUser(sql);
        }

        public bool addUser(USER user)
        {
            string sql = String.Format("insert into Users values('{0}', '{1}', {2})", user.Username, user.Password, user.Role);
            return dao.ExecuteNonQuery(sql);
        }

        public bool updateUser(USER user)
        {
            string sql = "update Users set role = " + user.Role + ", password = '" + user.Password + "' where MaSV = '" + user.Username + "'";
            return dao.ExecuteNonQuery(sql);
        }

        public bool deleteUser(USER user)
        {
            string sql = "delete from Users where MaSV='" + user.Username + "'";
            return dao.ExecuteNonQuery(sql);
        }

        //
    }
}

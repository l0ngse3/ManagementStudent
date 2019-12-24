using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_USER
    {
        public static OleDbConnection _conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\QuanLySinhVien.accdb");

        public string checkRole(string cmd)
        {
            OleDbCommand dbCommand = new OleDbCommand(cmd, _conn);
            if (_conn.State!= ConnectionState.Open)
            {
                _conn.Open();
            }

            
           
            OleDbDataReader reader = dbCommand.ExecuteReader();
            String role="";
            while(reader.Read())
            {
                role = reader.GetValue(0).ToString();
                break;
            }
            
            reader.Close();
            _conn.Close();
            return role;


        }
    }
}

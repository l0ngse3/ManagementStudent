using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO_Info
{
    public class DAO_Mg_User : DAO_Info_
    {
        public DataTable GetUser(string cmd)
        {
            if (_conn.State != ConnectionState.Open)
            {
                _conn.Open();
            }
            OleDbDataAdapter dbCommand = new OleDbDataAdapter(cmd, _conn);
            DataTable table = new DataTable();
            dbCommand.Fill(table);

            _conn.Close();
            return table;
        }

        
    }
}

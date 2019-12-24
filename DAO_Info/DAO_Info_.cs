using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace DAO_Info
{
    public class DAO_Info_ : DAO_USER
    {
        public ArrayList GetLop(string cmd)
        {
            if(_conn.State!=ConnectionState.Open)
            {
                _conn.Open();
            }
            OleDbCommand dbCommand = new OleDbCommand(cmd, _conn);
            OleDbDataReader reader = dbCommand.ExecuteReader();
            ArrayList arr = new ArrayList();
            while(reader.Read())
            {
                string tenLop = reader.GetValue(0).ToString();
                string maKhoa = reader.GetValue(1).ToString();
                string item = tenLop + "-" + maKhoa;
                arr.Add(item);
            }

            reader.Close();
            _conn.Close();
            return arr;
        }

        public DataTable GetKhoa(string cmd)
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

        public DataTable getSinhVien(String sql)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(sql, _conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            _conn.Close();
            //adapter.Dispose();
            return table;
        }

        public bool ExecuteNonQuery(String sql)
        {
            try
            {
                if (_conn.State != ConnectionState.Open)
                {
                    _conn.Open();
                }

                OleDbCommand cmd = new OleDbCommand(sql, _conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        public DataTable getMonHoc(string sql)
        {
            return GetKhoa(sql);
        }
    }
}

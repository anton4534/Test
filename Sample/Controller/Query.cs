using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Sample.Controller
{
    class Query
    {
        OleDbConnection     connection;
        OleDbCommand        command;
        OleDbDataAdapter    dataAdapter;
        DataTable           bufferTable;

        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable = new DataTable();
        }

        public DataTable UpdatePerson()
        {
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM Person", connection);
            bufferTable.Clear();
            dataAdapter.Fill(bufferTable);
            connection.Close();
            return bufferTable;
        }

        public void Add(string PIB, string MNV, int NMR)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO Person(PIB, MNV, NMR) VALUES(@PIB, @MNV, @NMR)", connection);
            command.Parameters.AddWithValue("PIB", PIB);
            command.Parameters.AddWithValue("MNV", MNV);
            command.Parameters.AddWithValue("NMR", NMR);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Delete(int ID)
        {
            connection.Open();
            command = new OleDbCommand($"DELETE FROM Person WHERE ID = {ID}", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}

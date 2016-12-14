using System.Data;
using System.Data.OleDb;

namespace Fault_Logger
{
    class dataBaseConnection2//second database connection class for certain functions requiring different sql queries to run without disruption
    {
        public OleDbCommand command;
        public OleDbCommand dataConnection(string sql)
        {
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(); //new connection 
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ..\..\..\techDatabase.accdb"; //connection string 
            conn.Open();
            OleDbCommand da = new OleDbCommand(sql, conn); //new oledb command

            conn.Close();//close database connection

            return command = da;//return command and expose it to parameter function
           
        }
        public DataSet parameters()
        {
            OleDbDataAdapter dAdapter = new OleDbDataAdapter();//new table adapter         
            dAdapter.SelectCommand = command;

            DataSet data = new DataSet();
            dAdapter.Fill(data);//fill data set with new data 
            return data;//return data to view
        }
    }
}
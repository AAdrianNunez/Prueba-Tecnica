using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Parking.DataAccess.Base
{
    public class DALSQLNative
    {
        SqlConnection _connection = null;
        SqlCommand _command;
        SqlTransaction _transaction = null;
        public string _connectionStrings;

        public DALSQLNative()
        {
            Setup();
        }

        public void Setup(string _string = null)
        {
            if (_string == null)
            {
                _connectionStrings = ConfigurationManager.ConnectionStrings["connectionStrings"].ConnectionString;
            }
            else
            {
                _connectionStrings = ConfigurationManager.ConnectionStrings[_string].ConnectionString;
            }
        }
   
        public SqlConnection Connect()
        {
            _connection = new SqlConnection(_connectionStrings);
            if (_connection.State.Equals(ConnectionState.Closed))
            {
                _connection.Open();
            }
            return _connection;
        }

        public void Disconnect()
        {
            if (_connection.State.Equals(ConnectionState.Open))
            {
                _connection.Close();
            }
        }

        public SqlCommand CreateCommand(string NameProcedure)
        {
            _command = new SqlCommand(NameProcedure, _connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (_transaction != null)
            {
                _command.Transaction = _transaction;
            }
            return _command;
        }
     
        public int ExecuteCommandNonQuery()
        {
            return _command.ExecuteNonQuery();
        }
    }
}
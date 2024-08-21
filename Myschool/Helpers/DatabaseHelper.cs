using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Myschool.Helpers
{
    public class DatabaseHelper : IDisposable
    {
        private readonly SqlConnection _connection;

        public DatabaseHelper()
        {
            var connectionString = GetConnectionString("SchoolDB");
            _connection = new SqlConnection(connectionString);
        }

        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public SqlConnection OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters = null)
        {
            // Ensure the connection is open
            OpenConnection();

            SqlCommand cmd = new SqlCommand(query, _connection);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            // Execute the command and return the reader
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        // Function for INSERT operation
        public int Insert(string query, SqlParameter[] parameters)
        {
            return ExecuteNonQuery(query, parameters);
        }

        // Function for UPDATE operation
        public int Update(string query, SqlParameter[] parameters)
        {
            return ExecuteNonQuery(query, parameters);
        }

        // Function for DELETE operation
        public int Delete(string query, SqlParameter[] parameters)
        {
            return ExecuteNonQuery(query, parameters);
        }

        // Function for CREATE operation
        public int Create(string query)
        {
            return ExecuteNonQuery(query);
        }

        // Reusable method to execute non-query commands (INSERT, UPDATE, DELETE, CREATE)
        private int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            // Ensure the connection is open
            OpenConnection();

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                // Execute the command and return the number of rows affected
                return cmd.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            CloseConnection();
            _connection.Dispose();
        }
    }
}

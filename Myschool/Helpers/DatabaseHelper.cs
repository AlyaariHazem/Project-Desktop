using System;
using System.Collections.Generic;
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
            try
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                return _connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error opening connection: " + ex.Message);
            }
        }



        public void CloseConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error closing connection: " + ex.Message);
            }
        }

      

        public void Insert(string tableName, Dictionary<string, object> values)
        {
            try
            {
                OpenConnection();
                string columns = string.Join(", ", values.Keys);
                string parameters = string.Join(", ", values.Keys.Select(k => "@" + k));

                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    foreach (var kvp in values)
                    {
                        cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting data: " + ex.Message);
            }
        }

        public void Update(string tableName, Dictionary<string, object> values, string whereClause)
        {
            try
            {
                OpenConnection();
                string setClause = string.Join(", ", values.Keys.Select(k => $"{k} = @{k}"));
                string query = $"UPDATE {tableName} SET {setClause} WHERE {whereClause}";

                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    foreach (var kvp in values)
                    {
                        cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating data: " + ex.Message);
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

<<<<<<< HEAD
        public DataTable Select(string selectQuery)
        {
            try
            {
                OpenConnection();
                using (SqlCommand cmd = new SqlCommand(selectQuery, _connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error selecting data: " + ex.Message);
            }
        } 

        
        public void Delete(string tableName, string whereClause)
        {
            try
            {
                OpenConnection();
                string query = $"DELETE FROM {tableName} WHERE {whereClause}";
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting data: " + ex.Message);
=======
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
>>>>>>> Hazem-MySchool
            }
        }

        public void Dispose()
        {
            CloseConnection();
            _connection.Dispose();
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> Hazem-MySchool

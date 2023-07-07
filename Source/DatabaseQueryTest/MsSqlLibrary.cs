using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseQueryTest
{
    public class MsSqlLibrary
    {
        private readonly string mDbConnectString;

        public MsSqlLibrary(string aDBIp, int aDBPort, string aDBName, string aDBUserID, string aDBUserPw, int aDBTimeout = 30)
        {
            //mDbConnectString = "Network Library=DBMSSOCN;";
            mDbConnectString += string.Format("Data Source={0},{1};", aDBIp, aDBPort);
            mDbConnectString += string.Format("Initial Catalog={0};", aDBName);
            mDbConnectString += string.Format("User ID={0};", aDBUserID);
            mDbConnectString += string.Format("Password={0};", aDBUserPw);
            mDbConnectString += string.Format("Connection Timeout={0};", aDBTimeout);
        }

        private SqlConnection GetConnection()
        {
            SqlConnection? connection;
            try {
                connection = new SqlConnection(mDbConnectString);
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            }

            return connection;
        }
        #region ExecuteNonQuery

        public int ExecuteNonQuery(string aSqlQuery)
        {
            int retValue = 0;
            SqlConnection? sqlConnection = null;
            SqlCommand? sqlCommand = null;

            try {
                using(sqlConnection = GetConnection()) {
                    sqlConnection.Open();

                    using(sqlCommand = new SqlCommand(aSqlQuery, sqlConnection)) {
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        retValue = sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                        sqlCommand = null;
                    }

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            } finally {
                sqlCommand?.Dispose();

                if(sqlConnection != null) {
                    if(sqlConnection.State != System.Data.ConnectionState.Closed) {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return retValue;
        }

        public int ExecuteNonQuery(string aSqlQuery, Dictionary<string, object> aDicCommandParam)
        {
            int retValue = 0;
            SqlConnection? sqlConnection = null;
            SqlCommand? sqlCommand = null;

            try {
                using(sqlConnection = GetConnection()) {
                    sqlConnection.Open();

                    using(sqlCommand = new SqlCommand(aSqlQuery, sqlConnection)) {
                        foreach(KeyValuePair<string, object> param in aDicCommandParam) {
                            sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                        }

                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        retValue = sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                        sqlCommand = null;
                    }

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            } finally {
                sqlCommand?.Dispose();

                if(sqlConnection != null) {
                    if(sqlConnection.State != System.Data.ConnectionState.Closed) {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return retValue;
        }

        public int ExecuteNonQuery(string aSqlQuery, SqlParameter[] aCommandParam)
        {
            int retValue = 0;
            SqlConnection? sqlConnection = null;
            SqlCommand? sqlCommand = null;

            try {
                using(sqlConnection = GetConnection()) {
                    sqlConnection.Open();

                    using(sqlCommand = new SqlCommand(aSqlQuery, sqlConnection)) {
                        foreach(SqlParameter param in aCommandParam) {
                            sqlCommand.Parameters.Add(param);
                        }

                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        retValue = sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                        sqlCommand = null;
                    }

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            } finally {
                sqlCommand?.Dispose();

                if(sqlConnection != null) {
                    if(sqlConnection.State != System.Data.ConnectionState.Closed) {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return retValue;
        }

        #endregion ExecuteNonQuery

        #region ExecuteNonQuerySP

        public int ExecuteNonQuerySP(string aSqlSp)
        {
            int retValue = 0;
            SqlConnection? sqlConnection = null;
            SqlCommand? sqlCommand = null;

            try {
                using(sqlConnection = GetConnection()) {
                    sqlConnection.Open();

                    using(sqlCommand = new SqlCommand(aSqlSp, sqlConnection)) {
                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        retValue = sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                        sqlCommand = null;
                    }

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            } finally {
                sqlCommand?.Dispose();

                if(sqlConnection != null) {
                    if(sqlConnection.State != System.Data.ConnectionState.Closed) {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return retValue;
        }

        public int ExecuteNonQuerySP(string aSqlSp, SqlParameter[] aCommandParam)
        {
            int retValue = 0;
            SqlConnection? sqlConnection = null;
            SqlCommand? sqlCommand = null;

            try {
                using(sqlConnection = GetConnection()) {
                    sqlConnection.Open();

                    using(sqlCommand = new SqlCommand(aSqlSp, sqlConnection)) {
                        foreach(SqlParameter param in aCommandParam) {
                            sqlCommand.Parameters.Add(param);
                        }

                        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                        retValue = sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                        sqlCommand = null;
                    }

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            } finally {
                sqlCommand?.Dispose();

                if(sqlConnection != null) {
                    if(sqlConnection.State != System.Data.ConnectionState.Closed) {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return retValue;
        }

        #endregion ExecuteNonQuerySP

        #region ExecuteNonQueryCommand

        public SqlCommand ExecuteNonQueryCommand(string aSqlQuery, SqlParameter[] aCommandParam)
        {
            SqlConnection? sqlConnection = null;
            SqlCommand? sqlCommand = null;

            try {
                using(sqlConnection = GetConnection()) {
                    sqlCommand = new SqlCommand(aSqlQuery, sqlConnection)
                    {
                        CommandType = System.Data.CommandType.Text
                    };

                    foreach(SqlParameter param in aCommandParam) {
                        sqlCommand.Parameters.Add(param);
                    }

                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            } finally {
                sqlCommand?.Dispose();

                if(sqlConnection != null) {
                    if(sqlConnection.State != System.Data.ConnectionState.Closed) {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return sqlCommand;
        }

        public SqlCommand ExecuteNonQueryCommandSP(string aSqlSp, SqlParameter[] aCommandParam)
        {
            SqlConnection? sqlConnection = null;
            SqlCommand? sqlCommand = null;

            try {
                using(sqlConnection = GetConnection()) {
                    sqlCommand = new SqlCommand(aSqlSp, sqlConnection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    foreach(SqlParameter param in aCommandParam) {
                        sqlCommand.Parameters.Add(param);
                    }

                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            } finally {
                sqlCommand?.Dispose();

                if(sqlConnection != null) {
                    if(sqlConnection.State != System.Data.ConnectionState.Closed) {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return sqlCommand;
        }

        #endregion ExecuteNonQueryCommand

        #region ExecuteDataTable

        public async Task<DataTable> AsyncExecuteDataTable(string aSqlQuery)
        {
            return await Task<DataTable>.Run(() => ExecuteDataTable(aSqlQuery));
        }

        public DataTable ExecuteDataTable(string aSqlQuery)
        {
            SqlConnection? sqlConnection = null;
            SqlDataAdapter? sqlDataAdapter = null;
            DataTable dataTable = new ();

            try {
                using(sqlConnection = GetConnection()) {
                    using(sqlDataAdapter = new SqlDataAdapter(aSqlQuery, sqlConnection)) {
                        sqlDataAdapter.Fill(dataTable);
                        sqlDataAdapter.Dispose();
                        sqlDataAdapter = null;
                    }

                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            } catch(Exception ex) {
                Debug.WriteLine(ex.Message);
                throw;
            } finally {
                sqlDataAdapter?.Dispose();

                if(sqlConnection != null) {
                    if(sqlConnection.State != System.Data.ConnectionState.Closed) {
                        sqlConnection.Close();
                    }

                    sqlConnection.Dispose();
                }
            }

            return dataTable;
        }

        #endregion ExecuteDataTable
    }
}

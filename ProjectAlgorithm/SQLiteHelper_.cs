using System;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;
using System.Configuration;

namespace SQL_
{
    public class SQLiteHelper
    {
        /// <summary>
        /// ConnectionString样例：Data Source=Test.db;Pooling=true;FailIfMissing=false
        /// </summary>
        private static readonly string dataSource = ConfigurationManager.AppSettings["SqliteConnection"];
        private static readonly string connectionString;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static SQLiteHelper()
        {
            try
            {
                SQLiteConnectionStringBuilder connectionStringBuilder = new SQLiteConnectionStringBuilder
                {
                    Version = 3,
                    Pooling = true,
                    FailIfMissing = false,
                    DataSource = dataSource
                };
                connectionString = connectionStringBuilder.ConnectionString;
                using (SQLiteConnection sqliteConn = new SQLiteConnection(connectionString))
                {
                    sqliteConn.Open();
                }
            }
            catch { }
        }

        #region basic methods

        /// <summary>
        /// 获取连接对象
        /// </summary>
        public static SQLiteConnection GetSQLiteConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        /// <summary>
        /// 预备命令
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        private static void PrepareCommand
            (SQLiteCommand cmd, SQLiteConnection conn, string cmdText, params object[] commandParameters)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Parameters.Clear();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 30;
            if (commandParameters != null)
            {
                foreach (object parm in commandParameters)
                {
                    cmd.Parameters.AddWithValue(string.Empty, parm);
                }
            }
        }

        /// <summary>
        /// 返回受影响的行数
        /// </summary>
        /// <param name="cmdText">执行语句</param>
        /// <param name="commandParameters">传入的参数</param>
        /// <returns>返回受影响行数</returns>
        public static int ExecuteNonQuery(string cmdText, params object[] commandParameters)
        {
            SQLiteCommand command = new SQLiteCommand();
            using (SQLiteConnection sqliteConnection = GetSQLiteConnection())
            {
                PrepareCommand(command, sqliteConnection, cmdText, commandParameters);
                return command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}
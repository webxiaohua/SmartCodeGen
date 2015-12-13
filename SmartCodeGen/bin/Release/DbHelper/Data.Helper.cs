using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace $namespace$
{
    /// <summary>
    /// SQLSERVER助手类
    /// </summary>
    public class DbHelper
    {
        public DbHelper()
        {
            this.connectionString = $connectionstring$;
        }
        public DbHelper(string connString)
        {
            this.connectionString = connString;
        }
        private string connectionString;
        private SqlConnection connection;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString
        {
            get { return this.connectionString; }
        }
        /// <summary>
        /// 数据连接
        /// </summary>
        public SqlConnection Connection
        {
            get 
            {
                if (this.connection == null)
                {
                    this.connection = new SqlConnection(this.connectionString);
                    this.connection.Open();
                }
                else if (this.connection.State != ConnectionState.Open)
                {
                    this.connection.Open();
                }
                return this.connection;
            }
        }
        
        /// <summary>
        /// 释放连接
        /// </summary>
        public void Dispose()
        {
            if (this.connection != null && this.connection.State != ConnectionState.Closed)
            {
                this.connection.Close();
            }
            this.connection.Dispose();
        }

        /// <summary>
        /// 得到一个SqlDataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string sql)
        {
            this.connection = new SqlConnection(ConnectionString);
            this.connection.Open();
            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                cmd.Prepare();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <summary>
        /// 得到一个SqlDataReader
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public SqlDataReader GetDataReader(string sql, SqlParameter[] parameter)
        {
            this.connection = new SqlConnection(ConnectionString);
            this.connection.Open();
            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                if (parameter != null && parameter.Length > 0)
                    cmd.Parameters.AddRange(parameter);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                cmd.Prepare();
                return dr;
            }
        }

        /// <summary>
        /// 得到一个DataTable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return dt;
                }
            }
        }

        /// <summary>
        /// 得到一个DataTable
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, SqlParameter[] parameter)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dr.Close();
                    dr.Dispose();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return dt;
                }
            }
        }

        /// <summary>
        /// 得到数据集
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetDataSet(string sql)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlDataAdapter dap = new SqlDataAdapter(sql, this.connection))
                {
                    DataSet ds = new DataSet();
                    dap.Fill(ds);
                    return ds;
                }
            }
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int Execute(string sql)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    cmd.Prepare();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 执行带参数的SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int Execute(string sql, SqlParameter[] parameter)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    int i = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return i;
                }
            }
        }

        /// <summary>
        /// 得到一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    object obj = cmd.ExecuteScalar();
                    cmd.Prepare();
                    return obj != null ? obj.ToString() : string.Empty;
                }
            }
        }

        /// <summary>
        /// 得到一个字段的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string ExecuteScalar(string sql, SqlParameter[] parameter)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (parameter != null && parameter.Length > 0)
                        cmd.Parameters.AddRange(parameter);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    cmd.Prepare();
                    return obj != null ? obj.ToString() : string.Empty;
                }
            }
        }

        /// <summary>
        /// 获取一个sql的字段名称
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public string GetFields(string sql, SqlParameter[] param)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                System.Text.StringBuilder names = new System.Text.StringBuilder(500);
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        names.Append("[" + dr.GetName(i) + "]" + (i < dr.FieldCount - 1 ? "," : string.Empty));
                    }
                    cmd.Parameters.Clear();
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return names.ToString();
                }
            }
        }

        /// <summary>
        /// 获取一个sql的字段名称
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="tableName">表名 </param>
        /// <returns></returns>
        public string GetFields(string sql, SqlParameter[] param, out string tableName)
        {
            using (this.connection = new SqlConnection(ConnectionString))
            {
                this.connection.Open();
                System.Text.StringBuilder names = new System.Text.StringBuilder(500);
                using (SqlCommand cmd = new SqlCommand(sql, this.connection))
                {
                    if (param != null && param.Length > 0)
                        cmd.Parameters.AddRange(param);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    tableName = dr.GetSchemaTable().TableName;
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        names.Append("[" + dr.GetName(i) + "]" + (i < dr.FieldCount - 1 ? "," : string.Empty));
                    }
                    cmd.Parameters.Clear();
                    dr.Close();
                    dr.Dispose();
                    cmd.Prepare();
                    return names.ToString();
                }
            }
        }
       
    }
}

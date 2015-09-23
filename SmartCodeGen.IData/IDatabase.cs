using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCodeGen.IData
{
    /// <summary>
    /// @Author:Robin
    /// @Date:20150922
    /// @Desc:数据库操作接口
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// 测试数据库连接
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="errMessage">错误信息</param>
        /// <returns></returns>
        bool TestDatabaseConnnection(string serverID, out string errMessage);
        /// <summary>
        /// 得到服务器所有数据库
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <returns>数据库列表</returns>
        List<string> GetDatabaseList(string serverID);
        /// <summary>
        /// 得到数据库所有表
        /// </summary>
        /// <param name="serverID">服务器ID</param>
        /// <param name="dbName">数据库名称</param>
        /// <returns>返回该数据库下的所有表</returns>
        List<Model.Tables> GetTables(string serverID, string dbName);
        /// <summary>
        /// 得到数据库所有视图
        /// </summary>
        /// <param name="serverID"></param>
        /// <returns></returns>
        List<Model.Views> GetViews(string serverID, string dbName);
        /// <summary>
        /// 得到一个表中所有字段
        /// </summary>
        /// <param name="serverID"></param>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<Model.Fields> GetFields(string serverID, string dbName, string tableName);

    }
}

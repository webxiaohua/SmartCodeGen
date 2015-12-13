using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCodeGen.Model;
using System.Reflection;

namespace SmartCodeGen.Factory
{
    public class Factory
    {
        public static IData.IDatabase CreateDatabaseInstance(DatabaseType databaseType)
        {
            string dllName = string.Empty;
            if (databaseType == DatabaseType.SqlServer2000
                || databaseType == DatabaseType.SqlServer2005
                || databaseType == DatabaseType.SqlServer2008)
            {
                dllName = "SqlServer";
            }
            else
            {
                dllName = databaseType.ToString();
            }
            return (IData.IDatabase)CreateInstance(dllName, "DataBase");
        }

        public static IData.ICreateCode CreateCreateCodeInstance(DatabaseType databaseType)
        {
            string dllName = string.Empty;
            if (databaseType == DatabaseType.SqlServer2000
                || databaseType == DatabaseType.SqlServer2005
                || databaseType == DatabaseType.SqlServer2008)
            {
                dllName = "SqlServer";
            }
            else
            {
                dllName = databaseType.ToString();
            }
            return (IData.ICreateCode)CreateInstance(dllName, "CreateCode");
        }

        private static object CreateInstance(string dllName, string className)
        {
            object obj = Assembly.Load(string.Format("SmartCodeGen.Data.{0}", dllName)).CreateInstance(string.Format("SmartCodeGen.Data.{0}.{1}", dllName, className));
            if (obj == null)
            {
                Common.Func.WriteLog(string.Format("SmartCodeGen.Data.{0}.{1} 创建实例为空", dllName, className));
            }
            return obj;
        }
    }
}

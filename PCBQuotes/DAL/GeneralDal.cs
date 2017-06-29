using Dapper;
using log4net;
using PCBQuotes.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PCBQuotes.DAL
{
    public class GeneralDal : IDisposable
    {
        private IDbConnection conn;
        //private ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GeneralDal()
        {
            var connStr = Helpers.AppConfigHelper.GetConnectionString("DefaultConnStr");
            conn = new SqlConnection(connStr);
            conn.Open();
        }

        public int CountTable<T>()
        {
            string tableName = Helpers.ModelHelper.GetTableNameByModel<T>();
            if (!string.IsNullOrEmpty(tableName))
            {
                string sql = string.Format("select count(*) from {0}", tableName);
                return (int)conn.ExecuteScalar(sql);
            }
            return 0;
        }

        public int CountTable<T>(string where)
        {
            string tableName = ModelHelper.GetTableNameByModel<T>();
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string sql = string.Format("select count(*) from {0} where {1}", tableName, string.IsNullOrWhiteSpace(where) ? "1 = 1" : where);
                return (int)conn.ExecuteScalar(sql);
            }
            return 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);//垃圾回收器不要调用指定对象的Dispose方法,前面已经手动调用了
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }
            }
        }
    }
}

using Dapper;
using log4net;
using PCBQuotes.Helpers;
using PCBQuotes.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PCBQuotes.BLL
{
    public class GeneralBll : IDisposable
    {
        private IDbConnection conn;
        private ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GeneralBll()
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

        /// <summary>
        /// 获取 分页数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="where"></param>
        /// <param name="startIndex">从1开始</param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<T> Select<T>(string orderBy, string where, int startIndex, int endIndex)
        {
            //conn.Open();
            string tableName = ModelHelper.GetTableNameByModel<T>();
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string sql = string.Format(@"SELECT
                                                *
                                            FROM
                                                (
                                                    SELECT

                                                        row_number() OVER(ORDER BY {1}) rownumber,
                                                        *
                                                    FROM

                                                        {0}

                                                    WHERE

                                                        {2}
                                                ) AS a
                                            WHERE

                                                a.rownumber BETWEEN {3}
                                            AND {4}",
                                            tableName, string.IsNullOrWhiteSpace(orderBy) ? "ID DESC" : orderBy,
                                            string.IsNullOrWhiteSpace(where) ? "1 = 1" : where, startIndex, endIndex);

                var re = conn.Query<T>(sql).ToList();
                return re;
            }
            return null;
        }

        /// <summary>
        /// 选择所有数据，少用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Select<T>()
        {
            string tableName = ModelHelper.GetTableNameByModel<T>();
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string sql = string.Format("SELECT * FROM {0}", tableName);
                var re = conn.Query<T>(sql).ToList();
                return re;
            }
            return null;
        }

        public List<PCBQuotes.Models.QuoMaterialCostViewModel> SelectQuoMaterialCostViewModel(int materialId)
        {
            //conn.Open();
            //string tableName = ModelHelper.GetTableNameByModel<T>();
            //if (!string.IsNullOrWhiteSpace(tableName))
            //{
                string sql = @"select a.*,b.LayerName,c.MaterialName from QuoMaterialCost a
left join QuoLayer b on a.LayerId = b.Id 
left join QuoMaterial c on a.MaterialId = c.Id where a.MaterialId = @MaterialId";

                var re = conn.Query<QuoMaterialCostViewModel>(sql,new { MaterialId = materialId}).ToList();
                return re;
            //}
            //return null;
        }

        public List<T> Select<T>(string where)
        {
            //conn.Open();
            string tableName = ModelHelper.GetTableNameByModel<T>();
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string sql = string.Format(@"SELECT
                                                *
                                            FROM {0}
                                                
                                            WHERE

                                                {1}",
                                            tableName,
                                            string.IsNullOrWhiteSpace(where) ? "1 = 1" : where);

                var re = conn.Query<T>(sql).ToList();
                return re;
            }
            return null;
        }

        public List<T> Select<T>(string where, int takeNum)
        {
            //conn.Open();
            string tableName = ModelHelper.GetTableNameByModel<T>();
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                string sql = string.Format(@"SELECT TOP {2}
                                                *
                                            FROM {0}
                                                
                                            WHERE

                                                {1}",
                                            tableName,
                                            string.IsNullOrWhiteSpace(where) ? "1 = 1" : where, takeNum);

                var re = conn.Query<T>(sql).ToList();
                return re;
            }
            return null;
        }

        public T Update<T>(T t)
        {
            var cols = ModelHelper.GetColumnNames(typeof(T), true, false);//t.GetType()
            var tbName = ModelHelper.GetTableNameByModel<T>();
            var fields = string.Join(",", cols);

            string[] psArr = new string[cols.Length];
            var p = new DynamicParameters();
            for (int i = 0; i < cols.Length; i++)
            {
                var tmp = "@" + cols[i];
                psArr[i] = cols[i] + "=" + tmp;
                p.Add(tmp, ModelHelper.GetValueByPropertyName<T>(t, cols[i]));
            }
            var paras = string.Join(",", psArr);
            string sql = string.Format(@"UPDATE   {0}  SET {1}  output inserted.*  WHERE Id=@Id", tbName, paras);
            p.Add("@Id", ModelHelper.GetValueByPropertyName<T>(t, "Id"));
            var re = conn.QueryFirstOrDefault<T>(sql, p);
            return re; 
        }

        public int Update<T>(int id, string fieldName, object value)
        {
            var tbName = ModelHelper.GetTableNameByModel<T>();
            string sql = string.Format(@"UPDATE {0} SET {1} = {2} WHERE ID = {3}", tbName, fieldName, "@" + fieldName, id);// 
            var p = new DynamicParameters();
            p.Add("@" + fieldName, value);
            return conn.Execute(sql, p);
        }

        public T Insert<T>(T t)
        {
            var cols = ModelHelper.GetColumnNames(typeof(T), true, false);//t.GetType()
            var tbName = ModelHelper.GetTableNameByModel<T>();
            var fields = string.Join(",", cols);

            string[] psArr = new string[cols.Length];
            var p = new DynamicParameters();
            for (int i = 0; i < cols.Length; i++)
            {
                var tmp = "@" + cols[i];
                psArr[i] = tmp;
                p.Add(tmp, ModelHelper.GetValueByPropertyName<T>(t, cols[i]));
            }
            var paras = string.Join(",", psArr);
            string sql = string.Format(@"INSERT INTO {0} ({1}) output inserted.*  VALUES ({2})", tbName, fields, paras);
            return conn.QueryFirstOrDefault<T>(sql, p);
            //try
            //{
            //    return conn.Execute(sql, p);
            //}
            //catch (Exception ex)
            //{
            //    Task.Factory.StartNew(() => {
            //        logger.Error("数据库操作异常", ex);
            //    });
            //    return 0;
            //}

        }

        public int Insert<T>(List<T> lst)
        {
            var cols = ModelHelper.GetColumnNames(typeof(T), true, false);//t.GetType()
            var tbName = ModelHelper.GetTableNameByModel<T>();
            var fields = string.Join(",", cols);

            string[] psArr = new string[cols.Length];
            //var p = new DynamicParameters();
            for (int i = 0; i < cols.Length; i++)
            {
                var tmp = "@" + cols[i];
                psArr[i] = tmp;
                //p.Add(tmp, ModelHelper.GetValueByPropertyName<T>(t, cols[i]));
            }
            var paras = string.Join(",", psArr);
            string sql = string.Format(@"INSERT INTO {0} ({1}) VALUES ({2})", tbName, fields, paras);
            return conn.Execute(sql, lst.ToArray());
        }

        public int Delete<T>(int id)
        {
            var tbName = ModelHelper.GetTableNameByModel<T>();
            string sql = string.Format(@"DELETE FROM {0}  WHERE  Id = @Id", tbName);
            return conn.Execute(sql, new { Id = id });
        }

        public int Delete<T>(List<int> ids)
        {
            var tbName = ModelHelper.GetTableNameByModel<T>();
            var paras = string.Join(",", ids);
            string sql = string.Format(@"DELETE FROM {0} WHERE  ID In ({1})", tbName, paras);
            return conn.Execute(sql);
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

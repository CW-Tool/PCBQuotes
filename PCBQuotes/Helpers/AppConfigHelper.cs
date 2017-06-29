using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace PCBQuotes.Helpers
{
    public class AppConfigHelper
    {
        /// <summary>
        /// 依据连接串名字connectionName返回数据连接字符串
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns>连接字符串</returns>
        public static string GetConnectionString(string connectionName)
        {
            if (ConfigurationManager.ConnectionStrings[connectionName] == null)
            {
                return string.Empty;
            }
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        /// <summary>
        /// 更新连接字符串
        /// </summary>
        /// <param name="connName">连接名称</param>
        /// <param name="connString">连接字符串</param>
        /// <param name="connProviderName">数据提供程序</param>
        public static void UpdateConnectionString(string connName,string connString,string connProviderName)
        {
            //打开打开可执行的配置文件*.exe.config
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            //如果有，先删除
            if (ConfigurationManager.ConnectionStrings[connName] != null)
            {
                config.ConnectionStrings.ConnectionStrings.Remove(connName); 
            }
            //新建连接字符串
            ConnectionStringSettings mySetting = new ConnectionStringSettings(connName,connString,connProviderName);
            //将新的连接字符串添加到配置文件中
            config.ConnectionStrings.ConnectionStrings.Add(mySetting);
            //保存更改
            config.Save(ConfigurationSaveMode.Modified);
            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("ConnectionStrings");
        }
    }
}

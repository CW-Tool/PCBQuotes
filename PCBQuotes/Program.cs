using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PCBQuotes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //加载log4net配置文件,记得调试时把配置文件发布
            var logConfigFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(logConfigFile);

            //全局异常处理
            GlobalExceptionHandler();

            //terlerik 控件本地化
            TelerikUILocalization();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.MainForm());
        }

         


        /// <summary>
        /// Telerik ui 本地化
        /// </summary>
        private static void TelerikUILocalization()
        {
            RadMessageLocalizationProvider.CurrentProvider = new Localization.CNRadMessageLocalizationProvider();
        }

        /// <summary>
        /// 全局异常处理，程序其它位置有异常直接throw,未处理的让这儿处理
        /// </summary>
        private static void GlobalExceptionHandler()
        {
            //将未处理异常给Application.ThreadException处理程序处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程上未处理异常
            Application.ThreadException += (s, e) => {
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error("UI线程异常", e.Exception);
            };
            //处理非线程异常
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error("未捕获异常", e.ExceptionObject as Exception);
            };
        }
    }
}
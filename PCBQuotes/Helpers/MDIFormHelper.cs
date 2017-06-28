using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PCBQuotes.Helpers
{
    public class MDIFormHelper
    {
        /// <summary>
        /// 打开MDI子窗口,没有创建，有直接显示
        /// </summary>
        /// <typeparam name="T">子窗口</typeparam>
        /// <param name="mdiParent">MDI父窗口</param>
        /// <returns></returns>
        public static T OpenUniqueMDIChildWindow<T>(Form mdiParent) where T : Form, new()
        {
            //查找 是否有此子窗口，有则显示 
            foreach (var m in mdiParent.MdiChildren)
            {
                if (m.GetType().Equals(typeof(T)))
                {
                    m.Activate();
                    if (m.WindowState == FormWindowState.Minimized)
                    {
                        m.WindowState = FormWindowState.Maximized;
                    }
                    return m as T;
                }
            }
            //没有 则 创建 
            T form = new T();
            form.MdiParent = mdiParent;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            return form;
        }
    }
}

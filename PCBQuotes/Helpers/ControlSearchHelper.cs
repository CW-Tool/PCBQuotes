using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PCBQuotes.Helpers
{
    public static class ControlSearchHelper
    {
        /// <summary>
        /// 向下递归查找控件
        /// </summary>
        /// <param name="parentControl">查找控件的父容器控件</param>
        /// <param name="findCtrlName">查找控件名称</param>
        /// <returns>若没有查找到返回NULL</returns>
        public static Control DownRecursiveFindControl(this Control parentControl, string findCtrlName)
        {
            Control _findedControl = null;
            if (!string.IsNullOrEmpty(findCtrlName) && parentControl != null)
            {
                foreach (Control ctrl in parentControl.Controls)
                {
                    if (ctrl.Name.Equals(findCtrlName))
                    {
                        _findedControl = ctrl;
                        break;
                    }
                    else
                    {
                        if (ctrl.Controls.Count > 0)
                            _findedControl = DownRecursiveFindControl(ctrl, findCtrlName);
                    }
                }
            }
            return _findedControl;
        }
        /// <summary>
        /// 将Control转换某种控件类型
        /// </summary>
        /// <typeparam name="T">控件类型</typeparam>
        /// <param name="control">Control</param>
        /// <param name="result">转换结果</param>
        /// <returns>若成功则返回控件；若失败则返回NULL</returns>
        public static T Cast<T>(this Control control, out bool result) where T : Control
        {
            result = false;
            T _castCtrl = null;
            if (control != null)
            {
                if (control is T)
                {
                    try
                    {
                        _castCtrl = control as T;
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        //Debug.WriteLine(string.Format("将Control转换某种控件类型异常，原因:{0}", ex.Message));
                        result = false;
                    }
                }
            }
            return _castCtrl;
        }
    }
}

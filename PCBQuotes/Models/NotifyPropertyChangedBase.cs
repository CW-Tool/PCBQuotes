using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PCBQuotes.Models
{
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    //扩展方法
    //public static class NotifyPropertyChangedBaseEx
    //{
    //    public static void OnPropertyChanged<T, TProperty>(this T notifyPropertyChangedBase, Expression<Func<T, TProperty>> propertyName)
    //        where T : NotifyPropertyChangedBase
    //    {
    //        var memberExpression = propertyName.Body as MemberExpression;
    //        if (null != memberExpression)
    //        {
    //            notifyPropertyChangedBase.OnPropertyChanged(memberExpression.Member.Name);
    //        }
    //        else
    //            throw new NotImplementedException();
    //    }
    //}
}

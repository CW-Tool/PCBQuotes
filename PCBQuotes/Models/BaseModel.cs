using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PCBQuotes.Models
{
     
    public partial class BaseModel : INotifyPropertyChanged//, IEditableObject
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int id;

        [Browsable(false)]
        [Key]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                this.OnPropertyChanged(x => x.Id);
            }
        }

        //private bool inTxn = false;
        //private object backup;//用这个字段来保存一个备份数据
        //public void BeginEdit()
        //{
        //    if (!inTxn)
        //    {
        //        backup = this.MemberwiseClone();
        //        inTxn = true;
        //    }

        //}

        //public void CancelEdit()
        //{
        //    if (inTxn)
        //    {
        //        inTxn = false;
        //    }
        //}

        //public void EndEdit()
        //{
        //    if (inTxn)
        //    {
        //        backup = null;
        //        inTxn = false;
        //    }

        //}
    }

    //扩展方法
    public static class NotifyPropertyChangedBaseExtended
    {
        public static void OnPropertyChanged<T, TProperty>(this T notifyPropertyChangedBase, Expression<Func<T, TProperty>> propertyName)
            where T : BaseModel
        {
            var memberExpression = propertyName.Body as MemberExpression;
            if (null != memberExpression)
            {
                notifyPropertyChangedBase.OnPropertyChanged(memberExpression.Member.Name);
            }
            else
                throw new NotImplementedException();
        }
    }
}

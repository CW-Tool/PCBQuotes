using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PCBQuotes.Models
{
    [Table("AppUser")]
    public class AppUser:BaseModel//NotifyPropertyChangedBase  
    {
        //private int id;
        private string userName;
        private string password;
        private string realName;
        private string email;
        private string tel;
        private string mobile;
        private string fax;
        private bool isDisabled;
        private bool isDeleted;

        //[Browsable(false)]
        //[Key]
         
        //public int Id
        //{
        //    get
        //    {
        //        return id;
        //    }

        //    set
        //    {
        //        id = value;
        //        this.OnPropertyChanged(x => x.Id);
        //    }
        //}

        [DisplayName("用户名")]
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
                this.OnPropertyChanged(x=>x.UserName);
            }
        }

        [Browsable(false)]
        [DisplayName("密码")]
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                this.OnPropertyChanged(x => x.Password);
            }
        }

        [DisplayName("姓名")]
        public string RealName
        {
            get
            {
                return realName;
            }

            set
            {
                realName = value;
                this.OnPropertyChanged(x=>x.RealName);
            }
        }

        [DisplayName("电子邮箱")]
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                this.OnPropertyChanged(x=>x.Email);
            }
        }

        [DisplayName("电话")]
        public string Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
                this.OnPropertyChanged(x=>x.Tel);
            }
        }

        [DisplayName("手机")]
        public string Mobile
        {
            get
            {
                return mobile;
            }

            set
            {
                mobile = value;
                this.OnPropertyChanged(x=>x.Mobile);
            }
        }

        [DisplayName("传真")]
        public string Fax
        {
            get
            {
                return fax;
            }

            set
            {
                fax = value;
                this.OnPropertyChanged(x => x.Fax);
            }
        }

        
        [DisplayName("禁用")]
        public bool IsDisabled
        {
            get
            {
                return isDisabled;
            }

            set
            {
                isDisabled = value;
                this.OnPropertyChanged(x=>x.IsDisabled);
            }
        }

        [Browsable(false)]
        [DisplayName("删除")]
        public bool IsDeleted
        {
            get
            {
                return isDeleted;
            }

            set
            {
                isDeleted = value;
                this.OnPropertyChanged(x=>x.IsDeleted);
            }
        }
    }
}

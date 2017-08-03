using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PCBQuotes.Models
{
    [Table("AppRole")]   
    public partial class AppRole:BaseModel//NotifyPropertyChangedBase,IEditableObject
    {
        

        //[Browsable(false)]
        //[Key]
        //[Display(AutoGenerateField = false,Name ="")]
        //public new  int  Id { get; set; }
 
        

        //[DisplayName("角色描述")]
        //[Display(Name = "角色描述")]
        //public string RoleDescription { get; set; }

        private string roleName;

        [DisplayName("角色名称")]
        [Display(Name = "角色名称")]
        public string RoleName
        {
            get
            {
                return roleName;
            }

            set
            {
                roleName = value;
                this.OnPropertyChanged(x => x.RoleName);
            }
        }

        private string roleDescription;

        [DisplayName("角色描述")]
        [Display(Name = "角色描述")]
        public string RoleDescription
        {
            get
            {
                return roleDescription;
            }

            set
            {
                roleDescription = value;
                this.OnPropertyChanged(x => x.RoleDescription);
            }
        }

        private AppRole backup;//用这个字段来保存一个备份数据
        private bool firstEdit = true;
        public void BeginEdit()
        {

            //开始编辑，此时将当前的状态保存起来，以便后续可以根据情况提交或者撤销更改
            if (firstEdit)
            {
                this.backup = this.MemberwiseClone() as AppRole;//通过克隆的方式直接地复制一份数据
                firstEdit = false;
            }
            
        }

        public void EndEdit()
        {
             
            //结束编辑，这里可以不做任何事情，也可以添加一些额外的逻辑
        }

        public void CancelEdit()
        {
            //撤销编辑，此时将对象状态恢复到备份的状态
            this.Id = backup.Id;
            this.RoleName = backup.RoleName;
            this.RoleDescription = backup.RoleDescription;
        }
    }
}

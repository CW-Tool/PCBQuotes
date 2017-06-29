using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCBQuotes.Models
{
    [Table("UserRole")]   
    public partial class UserRole
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int  ID { get; set; }

        [Display(Name = "角色名称")]
        public string RoleName { get; set; }

        [Display(Name = "角色描述")]
        public string RoleDescription { get; set; }
    }
}

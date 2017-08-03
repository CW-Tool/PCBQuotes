using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PCBQuotes.Models
{
    [Table("QuoMaterial")]
    public partial class QuoMaterial : BaseModel
    {
        //private int id;
        private string materialName;
        private string tg;
        private string remark;

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

        [DisplayName("物料名称")]
        public string MaterialName
        {
            get
            {
                return materialName;
            }

            set
            {
                materialName = value;
                this.OnPropertyChanged(x => x.MaterialName);
            }
        }

        [DisplayName("TG")]
        public string TG
        {
            get
            {
                return tg;
            }

            set
            {
                tg = value;
                this.OnPropertyChanged(x => x.TG);
            }
        }

        [DisplayName("备注")]
        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
                this.OnPropertyChanged(x => x.Remark);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PCBQuotes.Models
{
    
    [Table("QuoLayer")]
    public class QuoLayer:BaseModel//NotifyPropertyChangedBase
    {
        //private int id;
        private string layerName;
        private int layerValue;
        private string remark;

        //[Browsable(false)]
        //[Key]
        //public new int Id
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

        [DisplayName("名称")]
        public string LayerName
        {
            get
            {
                return layerName;
            }

            set
            {
                layerName = value;
                this.OnPropertyChanged(x => x.LayerName);
            }
        }

        [DisplayName("层数")]
        public int LayerValue
        {
            get
            {
                return layerValue;
            }

            set
            {
                layerValue = value;
                this.OnPropertyChanged(x=>x.LayerValue);
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
                this.OnPropertyChanged(x=>x.Remark);
            }
        }
    }
}

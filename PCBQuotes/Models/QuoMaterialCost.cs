using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PCBQuotes.Models
{
    [Table("QuoMaterialCost")]
    public partial class QuoMaterialCost:BaseModel
    {
        //ID 在基类中
        private int layerId;
        private int materialId;
        private double cost;
        private string remark;

        //[Browsable(false)]
        [DisplayName("层数")]
        public int LayerId
        {
            get
            {
                return layerId;
            }

            set
            {
                layerId = value;
                this.OnPropertyChanged(x => x.LayerId);
            }
        }

        //[Browsable(false)]
        [DisplayName("物料名称")]
        public int MaterialId
        {
            get
            {
                return materialId;
            }

            set
            {
                materialId = value;
                this.OnPropertyChanged(x=>x.MaterialId);
            }
        }

        [DisplayName("价格")]
        public double Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
                this.OnPropertyChanged(x => x.Cost);
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

    public partial class QuoMaterialCostViewModel:QuoMaterialCost
    {
        //private string layerName;
        //private string materialName;

        //[DisplayName("层数")]
        //public string LayerName
        //{
        //    get
        //    {
        //        return layerName;
        //    }

        //    set
        //    {
        //        layerName = value;
        //        this.OnPropertyChanged(x => x.LayerName);
        //    }
        //}

        //[DisplayName("物料名称")]
        //public string MaterialName
        //{
        //    get
        //    {
        //        return materialName;
        //    }

        //    set
        //    {
        //        materialName = value;
        //        this.OnPropertyChanged(x=>x.MaterialName);
        //    }
        //}
    }
}

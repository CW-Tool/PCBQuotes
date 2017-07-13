using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PCBQuotes.Helpers
{
    public class VirtualGridEditCommandCellElement: VirtualGridCellElement
    {
        private RadButtonElement btnDelete;
        private RadButtonElement btnEdit;

        //定义委托
        public delegate void EditButtonClickHandle(object sender, EventArgs args);
        public delegate void DeleteButtonClickHandle(object sender,EventArgs args);
        //定义事件
        public event EditButtonClickHandle EditButtonClicked;
        public event DeleteButtonClickHandle DeleteButtonClicked;

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

            this.btnEdit = new RadButtonElement();
            this.btnEdit.Image = global::PCBQuotes.Properties.Resources.Edit_18px;
            this.btnEdit.Text = "编辑";
            this.btnEdit.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnEdit.Padding = new Padding { Left = 10, Right = 10, Top=5,Bottom=5 };
           

            this.btnDelete = new RadButtonElement();
            this.btnDelete.Image = global::PCBQuotes.Properties.Resources.Delete_18px;
            this.btnDelete.Text = "删除";
            this.btnDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
            this.btnDelete.Padding = new Padding {  Left=10,Right=10, Top = 5, Bottom = 5 };
           

            this.Children.Add(btnEdit); 
            this.Children.Add(btnDelete);
        }
        protected override void UpdateInfo(VirtualGridCellValueNeededEventArgs args)
        {
            base.UpdateInfo(args);
            //约定使用ID列构建Cell，传递ID值
            if (args.FieldName=="ID"&& args.Value is int)
            {
                this.Value = args.Value;
            }
            this.Text = string.Empty;
        }
        //public override bool IsCompatible(int data, object context)
        //{
        //    //return base.IsCompatible(data, context);
        //    VirtualGridRowElement rowElement = context as VirtualGridRowElement;

        //    return data == 3 && rowElement.RowIndex >= 0;

        //}
        public override void Attach(int data, object context)
        {
            base.Attach(data, context);
            this.btnEdit.Click += BtnEdit_Click;
            this.btnDelete.Click += BtnDelete_Click;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.DeleteButtonClicked != null)
            {
                DeleteButtonClicked(sender, e);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (this.EditButtonClicked!=null)
            {
                this.EditButtonClicked(sender, e);
            }
        }

        public override void Detach()
        {
            this.btnDelete.Click -= BtnDelete_Click;
            this.btnEdit.Click -= BtnEdit_Click;
            base.Detach();
        }
        protected override SizeF ArrangeOverride(SizeF finalSize)
        {
            SizeF size = base.ArrangeOverride(finalSize);

            this.btnEdit.Arrange(new RectangleF(10,
                (finalSize.Height - this.btnEdit.DesiredSize.Height) / 2f, this.btnEdit.DesiredSize.Width, this.btnEdit.DesiredSize.Height));
            this.btnDelete.Arrange(new RectangleF(10+ this.btnEdit.DesiredSize.Width+10,
                (finalSize.Height - this.btnDelete.DesiredSize.Height) / 2f, this.btnDelete.DesiredSize.Width, this.btnDelete.DesiredSize.Height));
            //this.btnEdit.Arrange(new RectangleF((finalSize.Width - this.btnEdit.DesiredSize.Width) / 2f - this.btnEdit.DesiredSize.Width,
            //    (finalSize.Height - this.btnEdit.DesiredSize.Height) / 2f , this.btnEdit.DesiredSize.Width, this.btnEdit.DesiredSize.Height));
            //this.btnDelete.Arrange(new RectangleF((finalSize.Width - this.btnDelete.DesiredSize.Width) / 2f,
            //    (finalSize.Height - this.btnDelete.DesiredSize.Height) / 2f, this.btnDelete.DesiredSize.Width, this.btnDelete.DesiredSize.Height));

            return size;
        }
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(VirtualGridCellElement);
            }
        }

    }
}

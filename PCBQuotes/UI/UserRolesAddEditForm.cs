﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using PCBQuotes.Helpers;

namespace PCBQuotes.UI
{
    public partial class UserRolesAddEditForm : Telerik.WinControls.UI.RadForm
    {
        private   readonly object obj = new object();//用于线程锁对象
        private   SynchronizationContext syncContext = SynchronizationContext.Current;//线程中更新UI模型传播上下文
        private BLL.GeneralBll bll = new BLL.GeneralBll();
        public Models.AppRole UserRole { get; set; }
        public Enums.EditFormMode EditMode { get; set; }

        
        public UserRolesAddEditForm()
        {
            InitializeComponent();
            this.AcceptButton = this.btnSubmit;
            this.CancelButton = this.btnCanel;

            this.FormClosed += (s, e) => {
                //释放 资源 
                if (bll!=null)
                {
                    bll.Dispose();
                    bll = null;
                }
            };

            //设置dataentity
            this.deUserRole.FitToParentWidth = true;
            this.deUserRole.ShowValidationPanel = true;
            this.deUserRole.EditorInitializing += (s, e) => {
                e.Editor.Name = e.Property.Name;
            };
            this.deUserRole.ItemValidating += (s, e) => {
                Models.AppRole role = this.deUserRole.CurrentObject as Models.AppRole;
                switch (e.Label.Text)
                {
                    case "角色名称":
                        if (string.IsNullOrWhiteSpace(role.RoleName))
                        {
                            string errorMessage = "角色名称不能为空！";
                            e.ErrorProvider.SetError(s as Control, errorMessage);
                            e.Cancel = true;
                            AddErrorLabel(this.deUserRole, e.Label.Text, errorMessage);
                        }
                        else
                        {
                            e.ErrorProvider.Clear();
                            this.deUserRole.ValidationPanel.PanelContainer.Controls.RemoveByKey(e.Label.Text);
                        }
                        break;
                    default:
                        break;
                }
            }; 

            this.Shown += (s, e) => {
                //设置窗体title
                switch (EditMode)
                {
                    case Enums.EditFormMode.Add:
                        this.Text = "新增";
                        UserRole = new Models.AppRole()  ;
                        break;
                    case Enums.EditFormMode.Edit:
                        this.Text = "编辑";
                        break;
                    case Enums.EditFormMode.Delete:
                        this.Text = "删除";
                        break;
                    default:
                        this.Text = "新增/编辑";
                        break;
                }
                if (UserRole!=null)
                {
                    this.deUserRole.DataSource = this.UserRole;
                    this.UserRole.BeginEdit();
                }
            };

            this.btnCanel.Click += (s, e) => {
                //this.UserRole.CancelEdit();
                this.DialogResult = DialogResult.Cancel;
            };
            
            this.btnSubmit.Click += (s, e) => {
                var t= ValidationHelper.hasValidationErrors(this.deUserRole.Controls);
                if (t)
                {
                    return;
                }
                
                this.btnSubmit.Enabled = false;
                Task.Factory.StartNew(() => {
                    Models.AppRole re =null;
                    if (EditMode == Enums.EditFormMode.Add)
                    {
                        re = bll.Insert<Models.AppRole>(this.UserRole);
                    }
                    else if (EditMode == Enums.EditFormMode.Edit)
                    {
                        re = bll.Update<Models.AppRole>(this.UserRole);
                    } 
                    
                    syncContext.Post((state)=> {
                        this.btnSubmit.Enabled = true;
                        Models.AppRole sta = (Models.AppRole)state;
                        if (sta!=null)
                        {
                            this.UserRole = sta;
                            this.DialogResult = DialogResult.OK;
                            //this.SubmitSucess = true;
                        }
                        else
                        {
                            RadMessageBox.Show(this, "保存失败!", "", MessageBoxButtons.OK, RadMessageIcon.Error);
                        }
                    },re );
                });
            };
        }

        private void AddErrorLabel(RadDataEntry dataEntry,string propertyName, string errorMessage)
        {
            if (!dataEntry.ValidationPanel.PanelContainer.Controls.ContainsKey(propertyName))
            {
                RadLabel label = new RadLabel();
                label.Name = propertyName;
                label.Text = "" + propertyName + " : " + errorMessage;
                label.Dock = DockStyle.Top;
                //label.MaximumSize = new System.Drawing.Size(480, 0);
                label.TextWrap = true;
                dataEntry.ValidationPanel.PanelContainer.Controls.Add(label);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PCBQuotes.Helpers
{
    public class DataEntryHelper
    {
        public static  void AddErrorLabel(RadDataEntry dataEntry, string propertyName, string errorMessage)
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

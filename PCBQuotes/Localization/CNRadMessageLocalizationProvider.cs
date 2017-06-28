using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls;

namespace PCBQuotes.Localization
{
    public class CNRadMessageLocalizationProvider: RadMessageLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadMessageStringID.AbortButton: return "退出";
                case RadMessageStringID.CancelButton: return "取消";
                case RadMessageStringID.IgnoreButton: return "忽略";
                case RadMessageStringID.NoButton: return "否";
                case RadMessageStringID.OKButton: return "OK";
                case RadMessageStringID.RetryButton: return "重试";
                case RadMessageStringID.YesButton: return "是";
                default:
                    return base.GetLocalizedString(id); 
            }
        }
    }
}

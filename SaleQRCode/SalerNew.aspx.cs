using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FROST.Utility;

namespace SaleQRCode {
    public partial class SalerNew : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if(Request["salerName"] != null && Request["salerMobile"]!=null && Request["qrcodeId"] != null) {
                Saler saler = new Saler();
                saler.Name = Request["salerName"].Trim();
                saler.QRCodeId = Convert.ToInt32(Request["qrcodeId"].Trim());
                if (!General.CheckMobilePhone(Request["salerMobile"].Trim())) {
                    Message.Dialog("手机号码不正确。");
                    return;
                }
                saler.Mobile = Request["salerMobile"].Trim();
                if (SalerController.Check(saler.Mobile))
                    Message.Dialog("指定手机号码的营销员已存在。");

                if (SalerController.Add(saler)) {
                    Message.Dialog("营销员添加成功。", "SalerList.aspx");
                }
                else {
                    Message.Dialog("添加失败，错误代码：Saler.Add");
                }
            }
        }
    }
}
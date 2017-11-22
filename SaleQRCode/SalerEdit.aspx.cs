using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FROST.Utility;

namespace SaleQRCode {
    public partial class SalerEdit : System.Web.UI.Page {
        public Saler saler = new Saler();
        protected void Page_Load(object sender, EventArgs e) {
            if(Request.HttpMethod == "GET" && Request["id"] != null) {
                saler.Id = Convert.ToInt32(Request["id"].Trim());
                if (!SalerController.Check(saler.Id))
                    Message.Dialog("无效的营销员ID");
                if (CustomerControllers.Count(saler.Id) > 0)
                    Message.Dialog("已关联客户的营销员不能修改，请先转移关系或做离职处理。");
                saler = SalerController.Get(saler.Id);
            }
            if(Request.HttpMethod == "POST" && Request["id"] != null) {

                if (Request["salerName"] == null)
                    Message.Dialog("姓名不能为空。");
                if (Request["salerMobile"] == null)
                    Message.Dialog("手机号码不能为空。");
                saler.Status = Convert.ToInt32(Request["status"]);
                saler.Id = Convert.ToInt32(Request["id"]);
                saler.Mobile = Request["salerMobile"].Trim();
                saler.Name = Request["salerName"].Trim();
                if (!string.IsNullOrEmpty(Request["qrcodeid"]))
                    saler.QRCodeId = Convert.ToInt32(Request["qrcodeId"]);
                else
                    saler.QRCodeId = 0;
                string sql = "select count(*) from [crm_saler] where id<>" + saler.Id + " and mobile = '" + saler.Mobile + "'";
                int n =Convert.ToInt32( MsSQLHelper.ExecuteScalar(sql));
                if (n > 0)
                    Message.Dialog("手机号码已注册为其他的营销员，请重新修改。");
                if (SalerController.Update(saler))
                    Message.Dialog("修改成功。","SalerList.aspx");
                else
                    Message.Dialog("信息修改失败。");
            }
        }
    }
}
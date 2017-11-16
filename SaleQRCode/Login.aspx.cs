using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaleQRCode {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["act"] != null && Request["act"] == "logout" && Session["loginid"] != null) {
                Session.Clear();
            }
            if (Session["loginid"] != null)
                Response.Redirect("Main.aspx");
            if (Request["loginPassword"] != null) {
                WeChat.AccessTokenContainer.GetAccessToken();
                if (Request["loginPassword"].Trim() == "weizhi12") {
                    Session.Add("loginid", DateTime.Now);
                    Response.Redirect("Main.aspx");
                }
                else {
                    lbMsg.InnerText = "口令错误。";
                }
            }
        }
    }
}
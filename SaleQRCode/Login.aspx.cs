using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace SaleQRCode {
    public partial class Login : System.Web.UI.Page {
        XmlDocument document = new XmlDocument();
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["act"] != null && Request["act"] == "logout" && Session["loginid"] != null) {
                Session.Clear();
            }
            if (Session["loginid"] != null)
                Response.Redirect("Main.aspx");
            if (Request["loginPassword"] != null) {
                document.Load(Server.MapPath("/App_Data/AccessToken.xml"));
                XmlNode node = document.SelectSingleNode("WeChat/Password");
                WeChat.AccessTokenContainer.GetAccessToken();
                if (Request["loginPassword"].Trim() == node.InnerText) {
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
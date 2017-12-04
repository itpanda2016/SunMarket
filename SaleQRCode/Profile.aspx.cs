using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Web.UI.WebControls;

namespace SaleQRCode {
    public partial class Profile : System.Web.UI.Page {
        XmlDocument document = new XmlDocument();
        protected void Page_Load(object sender, EventArgs e) {
            if(Request.HttpMethod == "POST") {
                if(Request["newPassword"].Trim() == Request["confirmPassword"].Trim()) {
                    document.Load(Server.MapPath("/App_Data/AccessToken.xml"));
                    XmlNode node = document.SelectSingleNode("WeChat/Password");
                    node.InnerText = Request["newPassword"].Trim();
                    document.Save(Server.MapPath("/App_Data/AccessToken.xml"));
                    Message.Dialog("密码修改成功。");
                }
                else {
                    Message.Dialog("请确认输入的两个密码是否一致。");
                }
            }
        }
    }
}
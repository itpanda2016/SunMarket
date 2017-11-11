using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaleQRCode.Content.Master {
    public partial class SiteAdmin : System.Web.UI.MasterPage {
        public string activeMenu = "";
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["loginid"] == null)
                Response.Redirect("/Login.aspx");
            activeMenu = Request.Url.ToString();
        }
    }
}
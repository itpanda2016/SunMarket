using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SaleQRCode {
    public partial class CustomerList : System.Web.UI.Page {
        public DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e) {
            dt = CustomerControllers.Get();
            if(dt != null) {
                dt.Columns.Add("状态", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++) {
                    if (Convert.ToInt32(dt.Rows[i]["subscribe"]) == 0)
                        dt.Rows[i]["状态"] = "未关注";
                    else
                        dt.Rows[i]["状态"] = "已关注";
                }
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }
    }
}
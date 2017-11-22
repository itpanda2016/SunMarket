using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SaleQRCode {
    public partial class SalerList : System.Web.UI.Page {
        public DataTable dt = new DataTable();
        public int id;
        protected void Page_Load(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(Request["id"])) {
                id = Convert.ToInt32(Request["id"].Trim());
                if (SalerController.Delete(id)) {
                    Message.Dialog("删除成功。" + id, "/SalerList.aspx");
                }
                else {
                    Message.Dialog("删除失败。");
                }
                
            }
            dt = SalerController.Get();
            if (dt != null) {
                dt.Columns.Add("状态",typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++) {
                    if (Convert.ToInt32(dt.Rows[i]["status"]) == 0)
                        dt.Rows[i]["状态"] = "正常";
                    else
                        dt.Rows[i]["状态"] = "离职";
                }
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }
    }
}
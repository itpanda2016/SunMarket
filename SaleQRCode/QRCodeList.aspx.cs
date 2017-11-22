using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SaleQRCode {
    public partial class QRCodeList : System.Web.UI.Page {
        public DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e) {
            dt = QRCodeController.GetList();
            if(dt != null) {
                //dt.Columns.Add("saler_id", typeof(int));
                for (int i = 0; i < dt.Rows.Count; i++) {
                    var obj = dt.Rows[i]["saler_id"];
                    if (dt.Rows[i]["saler_id"] ==DBNull.Value)
                        dt.Rows[i]["ticket"] = "查看图片";
                    else
                        dt.Rows[i]["ticket"] = "<a href=\"https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=" + dt.Rows[i]["ticket"]
                            + "\" target=\"_blank\">查看图片</a>" ;
                }
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }
    }
}
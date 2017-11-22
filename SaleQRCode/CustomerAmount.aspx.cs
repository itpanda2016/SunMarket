using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FROST.Utility;
using System.Text;

namespace SaleQRCode {
    public partial class CustomerAmount : System.Web.UI.Page {
        public DataTable dt = new DataTable();
        public string openid;
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["id"] != null)
                openid = Request["id"].Trim();
            StringBuilder sb = new StringBuilder();
            sb.Append("select b.openid,order_id,order_sn,a.user_id,order_status,shipping_status,pay_status,consignee,goods_amount,order_amount,money_paid,add_time,confirm_time,pay_time,shipping_time from ecs_order_info as a");
            sb.Append(" left join ecs_users as b on a.user_id = b.user_id");
            sb.Append(" where b.openid <> ''");
            sb.Append(" order by order_id desc");
            dt = DbHelperMySQL.Query(sb.ToString()).Tables[0];
            if (dt != null) {
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }
    }
}
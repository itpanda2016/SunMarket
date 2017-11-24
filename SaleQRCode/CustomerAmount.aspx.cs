using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FROST.Utility;
using System.Text;
using FROST.WeixinMP;

namespace SaleQRCode {
    public partial class CustomerAmount : System.Web.UI.Page {
        public DataTable dt = new DataTable();
        public string openid = "";
        public MemberResult member = new MemberResult();
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["id"] != null) {
                openid = Request["id"].Trim();
                member = MailListApi.GetMemberInfo(openid, WeChat.AccessTokenContainer.GetAccessToken());
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("select b.openid,order_id,order_sn,a.user_id,order_status,shipping_status,pay_status,consignee,goods_amount,order_amount,money_paid,add_time,confirm_time,pay_time,shipping_time from ecs_order_info as a");
            sb.Append(" left join ecs_users as b on a.user_id = b.user_id");
            sb.Append(" where 1=1 ");
            sb.Append(" and b.openid <> ''");
            if (openid != "")
                sb.Append(" and b.openid = '" + openid + "'");
            sb.Append(" order by order_id desc");
            dt = DbHelperMySQL.Query(sb.ToString()).Tables[0];
            if (dt != null) {
                dt.Columns.Add("ordertime", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++) {
                    dt.Rows[i]["ordertime"] = General.UnixTimeToTime(dt.Rows[i]["add_time"].ToString()).ToString();
                }
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }
    }
}
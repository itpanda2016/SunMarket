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
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace SaleQRCode {
    public partial class CustomerAmount : System.Web.UI.Page {
        public DataTable dt = new DataTable();
        public string openid = "";
        public string pageTitle = "";
        public MemberResult member = new MemberResult();
        protected void Page_Load(object sender, EventArgs e) {
            if (Request["id"] != null) {
                openid = Request["id"].Trim();
                member = MailListApi.GetMemberInfo(openid, WeChat.AccessTokenContainer.GetAccessToken());
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("select b.openid,a.order_id,order_sn,a.user_id,order_status,shipping_status,pay_status,consignee,add_time,d.order_amount as 'paid_amount' from ecs_order_info as a");
            sb.Append(" left join ecs_users as b on a.user_id = b.user_id");
            sb.Append(" left join ecs_pay_log as d on a.order_id = d.order_id");
            sb.Append(" where 1=1 ");
            sb.Append(" and b.openid <> ''");
            if (openid != "")
                sb.Append(" and b.openid = '" + openid + "'");
            sb.Append(" order by a.order_id desc");
            dt = DbHelperMySQL.Query(sb.ToString()).Tables[0];
            if (dt != null) {
                dt.Columns.Add("订单日期", typeof(string));
                dt.Columns.Add("订单状态", typeof(string));
                dt.Columns.Add("支付状态", typeof(string));
                for (int i = 0; i < dt.Rows.Count; i++) {
                    dt.Rows[i]["订单日期"] = General.UnixTimeToTime(dt.Rows[i]["add_time"].ToString()).ToString();
                    dt.Rows[i]["订单状态"] = (OrderStatus)Convert.ToInt32(dt.Rows[i]["order_status"]);
                    dt.Rows[i]["支付状态"] = (PayStatus)Convert.ToInt32(dt.Rows[i]["pay_status"]);
                }
                if (!string.IsNullOrEmpty(Request["action"])) {
                    XSSFWorkbook workbook;
                    using (FileStream file = new FileStream(Server.MapPath("~/App_Data/订单导出模板.xlsx"),FileMode.Open,FileAccess.Read)) {
                        workbook = new XSSFWorkbook(file);
                    }
                    ISheet sheet = workbook.GetSheetAt(0);  //应该是从0开始？
                    for (int i = 0; i < dt.Rows.Count; i++) {
                        IRow row = sheet.CreateRow(i + 1);
                        for (int k = 0; k < dt.Columns.Count; k++) {
                            ICell cell = row.CreateCell(k);
                            cell.SetCellValue(dt.Rows[i][k].ToString());
                        }
                    }
                    NpoiHelper.DataTableToExcel(dt, Server.MapPath("~/App_Data/" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")), ExcelVersion.xlsx);
                    Message.Dialog("导出成功。");
                }
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }
    }
    enum OrderStatus {
        已确认 = 1,
        已取消 = 2,
        已收货 = 5,
        已退货 = 4
    }
    enum PayStatus {
        未支付 = 0,
        已付款 = 2
    }
}
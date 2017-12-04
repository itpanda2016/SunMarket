using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Text;
using FROST.Utility;
using System.Data;
using NPOI.HSSF.UserModel;

namespace SaleQRCode {
    /// <summary>
    /// HandlerExportExcel 的摘要说明
    /// </summary>
    public class HandlerExportExcel : IHttpHandler {
        public DataTable dt = new DataTable();
        public string openid = "";

        public void ProcessRequest(HttpContext context) {
            if (context.Request["id"] != null) {
                openid = context.Request["id"].Trim();
                //member = MailListApi.GetMemberInfo(openid, WeChat.AccessTokenContainer.GetAccessToken());
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("select add_time,b.openid,order_sn,order_status,pay_status,consignee,d.order_amount as 'paid_amount' from ecs_order_info as a");
            sb.Append(" left join ecs_users as b on a.user_id = b.user_id");
            sb.Append(" left join ecs_pay_log as d on a.order_id = d.order_id");
            sb.Append(" where 1=1 ");
            sb.Append(" and b.openid <> ''");
            if (openid != "")
                sb.Append(" and b.openid = '" + openid + "'");
            sb.Append(" order by a.order_id desc");
            dt = DbHelperMySQL.Query(sb.ToString()).Tables[0];
                
            //context.Response.ContentType = "application/x=excel";     //2003
            context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";     //2007
            string filename = HttpUtility.UrlEncode(DateTime.Now.ToString("yyyyMMddHHmmss") +".xlsx");
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
            IWorkbook workbook;
            workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();
            int rownum = 0;
            IRow row = sheet.CreateRow(rownum);
            //dt.Columns["add_time"].ColumnName = "订单日期";
            dt.Columns["order_sn"].ColumnName = "订单编号";
            dt.Columns["openid"].ColumnName = "Openid";
            //dt.Columns["order_status"].ColumnName = "订单状态";
            //dt.Columns["pay_status"].ColumnName = "支付状态";
            dt.Columns["consignee"].ColumnName = "收货人";
            dt.Columns["paid_amount"].ColumnName = "已付款金额";

            dt.Columns.Add("用户昵称", typeof(string));
            dt.Columns.Add("订单日期", typeof(string));
            dt.Columns.Add("订单状态", typeof(string));
            dt.Columns.Add("支付状态", typeof(string));

            for (int i = 0; i < dt.Rows.Count; i++) {
                dt.Rows[i]["订单日期"] = General.UnixTimeToTime(dt.Rows[i]["add_time"].ToString()).ToString();
                dt.Rows[i]["订单状态"] = (OrderStatus)Convert.ToInt32(dt.Rows[i]["order_status"]);
                dt.Rows[i]["支付状态"] = (PayStatus)Convert.ToInt32(dt.Rows[i]["pay_status"]);
                if (openid != "")
                    dt.Rows[i]["用户昵称"] = CustomerControllers.Get(openid).NickName;

            }
            dt.Columns.Remove("add_time");
            dt.Columns.Remove("order_status");
            dt.Columns.Remove("pay_status");

            for (int i = 0; i < dt.Columns.Count; i++) {
                row.CreateCell(i).SetCellValue(dt.Columns[i].Caption.ToString());
            }
            for (int i = 0; i < dt.Rows.Count; i++) {
                row = sheet.CreateRow(i + 1);
                for (int k = 0; k < dt.Columns.Count; k++) {
                    ICell cell = row.CreateCell(k);
                    cell.SetCellValue(dt.Rows[i][k].ToString());
                }
            }
            workbook.Write(context.Response.OutputStream);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
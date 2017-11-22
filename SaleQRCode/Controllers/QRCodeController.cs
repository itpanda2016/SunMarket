using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using FROST.Utility;

namespace SaleQRCode {
    /// <summary>
    /// 微信二维码处理
    /// 获取出来的图片显示
    ///     <img style="border:1px solid silver;background:#DEDEDE;padding:4px;" src="https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket=<%=ticket.ticket %>" alt="AlternateText" />
    /// </summary>
    public class QRCodeController {
        /// <summary>
        /// 添加二维码记录（永久整型，请通过UPDATE更新SceneId以及Ticket）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(WeChatQRCode model) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into wechat_qrcode (gmt_create, qrcode_type) " +
                "values (@gmt_create,@qrcode_type)");
            SqlParameter[] parameter = {
                new SqlParameter("@gmt_create", DateTime.Now),
                //new SqlParameter("@gmt_modified",models.Status),
                new SqlParameter("@qrcode_type",model.QRCodeType)
                //new SqlParameter("@scene_id",model.SceneID),
                //new SqlParameter("@scene_str",model.SceneStr),
                //new SqlParameter("@expire_seconds",model.ExpireSeconds),
                };
            int ret = MsSQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, parameter);
            //ret = MsSQLHelper.ExecuteScalar("select @@")
            if (ret == 0)
                return false;
            return true;
        }
        /// <summary>
        /// 更新永久整型二维码：SceneID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(WeChatQRCode model) {
            StringBuilder sb = new StringBuilder();
            sb.Append("update wechat_qrcode set ");
            sb.Append("scene_id = @scene_id,gmt_modified = @gmt_modified,ticket = @ticket");
            sb.Append(" where id = @id");
            SqlParameter[] parameter = {
                new SqlParameter("@scene_id",model.SceneID),
                new SqlParameter("@gmt_modified",DateTime.Now),
                new SqlParameter("@ticket",model.Ticket),
                new SqlParameter("@id",model.Id)
            };
            int ret = MsSQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, parameter);
            if (ret == 0)
                return false;
            return true;
        }
        /// <summary>
        /// 获取最新的一条记录
        /// </summary>
        /// <returns></returns>
        public static int GetLastID() {
            StringBuilder sb = new StringBuilder();
            sb.Append("select top 1 id from wechat_qrcode order by gmt_create desc");
            int ret = Convert.ToInt32(MsSQLHelper.ExecuteScalar(sb.ToString()));
            if (ret <= 0)
                return -1;
            return ret;
        }
        /// <summary>
        /// 获取清单（还是表格好，因为可以排序、过滤）
        /// </summary>
        /// <returns></returns>
        public static DataTable GetList() {
            StringBuilder sb = new StringBuilder();
            sb.Append("select a.id, a.gmt_create,b.id as saler_id,b.name as saler_name,qrcode_type, scene_id, scene_str, expire_seconds, ticket from wechat_qrcode as a");
            sb.Append(" left join crm_saler as b on a.id = b.qrcode_id");
            DataTable table = MsSQLHelper.ExecuteDataTable(sb.ToString());
            if (table.Rows.Count > 0)
                return table;
            return null;
        }

    }
}
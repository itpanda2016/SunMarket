using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FROST.Utility;

namespace SaleQRCode {
    public class CustomerControllers {
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Customer model) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into crm_customer (saler_id,openid,qrcode_id,subscribe,nickname,headimgurl,subscribe_time,gmt_create) " +
                "values (@saler_id,@openid,@qrcode_id,@subscribe,@nickname,@headimgurl,@subscribe_time,@gmt_create)");
            SqlParameter[] parameter = {
                new SqlParameter("@saler_id", model.SalerId),
                new SqlParameter("@openid",model.Openid),
                new SqlParameter("@qrcode_id",model.QRCodeId),
                new SqlParameter("@subscribe",model.Subscribe),
                new SqlParameter("@nickname",model.NickName),
                new SqlParameter("@headimgurl",model.Headimgurl),
                new SqlParameter("@subscribe_time",model.SubscribeTime),
                new SqlParameter("@gmt_create",DateTime.Now)
                };
            int ret = MsSQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, parameter);
            if (ret == 0)
                return false;
            return true;
        }
        /// <summary>
        /// 获取清单（还是表格好，因为可以排序、过滤）
        /// </summary>
        /// <returns></returns>
        public static DataTable Get() {
            StringBuilder sb = new StringBuilder();
            sb.Append("select id,saler_id,openid,gmt_create,qrcode_id,subscribe,nickname,headimgurl,subscribe_time from crm_customer");
            DataTable table = MsSQLHelper.ExecuteDataTable(sb.ToString());
            if (table.Rows.Count > 0)
                return table;
            return null;
        }
        /// <summary>
        /// 暂时只返回nickname
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static Customer Get(string openid) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select openid,nickname,saler_id" +
                " from crm_customer where openid = {0}", openid);
            SqlDataReader reader = MsSQLHelper.ExecuteReader(sb.ToString());
            Customer model = new Customer();
            if (reader.Read()) {
                model.Openid = openid;
                model.NickName = reader["nickname"].ToString();
                model.SalerId = Convert.ToInt32(reader["saler_id"]);
                return model;
            }
            return null;
        }

        /// <summary>
        /// 根据ID（营销员）统计粉丝记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Count(int salerId) {
            string sb = "select count(*) from crm_customer where saler_id = " + salerId;
            int ret = Convert.ToInt32(MsSQLHelper.ExecuteScalar(sb));
            return ret;
        }
        /// <summary>
        /// 更新粉丝状态（0-取消关注，1-关注状态）
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="subscribe"></param>
        /// <returns></returns>
        public static bool Update(string openid,int subscribe) {
            string sb = string.Format("update crm_customer set subscribe ={0} where openid='{1}'", subscribe, openid);
            int ret = MsSQLHelper.ExecuteNonQuery(sb);
            if (ret >= 1)
                return true;
            return false;
        }
        /// <summary>
        /// 查询粉丝是否存在
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static bool IsHave(string openid) {
            string sb = string.Format("select count(*) from crm_customer where openid='{0}'", openid);
            int ret = Convert.ToInt32(MsSQLHelper.ExecuteScalar(sb));
            if (ret > 0)
                return true;
            return false;
        }
        /// <summary>
        /// 粉丝再次关注时，更新数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(Customer model) {
            StringBuilder sb = new StringBuilder();
            sb.Append("update crm_customer set ");
            sb.Append("saler_id = @salerid,gmt_modified = @gmtModified,");
            sb.Append("qrcode_id = @qrcodeid,subscribe=@subscribe,");
            sb.Append("nickname = @nickname,headimgurl=@headimgurl");
            sb.Append(" where openid = @openid");
            SqlParameter[] parameter = {
                new SqlParameter("@salerid",model.SalerId),
                new SqlParameter("@gmtModified",DateTime.Now),
                new SqlParameter("@qrcodeid",model.QRCodeId),
                new SqlParameter("@subscribe",model.Subscribe),
                new SqlParameter("@nickname",model.NickName),
                new SqlParameter("@headimgurl",model.Headimgurl),
                new SqlParameter("@openid",model.Openid)
            };
            int ret = MsSQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, parameter);
            if (ret == 0)
                return false;
            return true;
        }
    }
}
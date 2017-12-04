using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FROST.Utility;

namespace SaleQRCode {
    public class SalerController {
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Add(Saler model) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into crm_saler (name,mobile,status,gmt_create,qrcode_id) " +
                "values (@name,@mobile,@status,@gmtCreate,@qrcode_id)");
            SqlParameter[] parameter = {
                new SqlParameter("@name", model.Name),
                new SqlParameter("@status",model.Status),
                new SqlParameter("@mobile",model.Mobile),
                new SqlParameter("@qrcode_id",model.QRCodeId),
                new SqlParameter("@gmtCreate",DateTime.Now)
                };
            int ret = MsSQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, parameter);
            if (ret == 0)
                return false;
            return true;
        }
        /// <summary>
        /// 判断手机号码是否已存在
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool Check(string mobile) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select count(*) from crm_saler where mobile ='{0}'",mobile);
            int ret = Convert.ToInt32(MsSQLHelper.ExecuteScalar(sb.ToString()));
            if (ret > 0)
                return true;
            return false;
        }
        /// <summary>
        /// 判断手机号码是否已存在
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool Check(int id) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select count(*) from crm_saler where id ={0}", id);
            int ret = Convert.ToInt32(MsSQLHelper.ExecuteScalar(sb.ToString()));
            if (ret > 0)
                return true;
            return false;
        }

        public static Saler Get(int id) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select id,name,mobile,status,gmt_create,gmt_modified,qrcode_id" +
                " from crm_saler where id = {0}", id);
            SqlDataReader reader = MsSQLHelper.ExecuteReader(sb.ToString());
            Saler model = new Saler();
            if (reader.Read()) {
                model.Id = id;
                model.Name = reader["name"].ToString();
                model.Status = Convert.ToInt32(reader["status"]);
                model.Mobile = reader["mobile"].ToString();
                model.GMTCreate = Convert.ToDateTime(reader["gmt_create"]);
                if (reader["qrcode_id"] != DBNull.Value)
                    model.QRCodeId = Convert.ToInt32(reader["qrcode_id"]);
                if (reader["gmt_modified"] != DBNull.Value)
                    model.GMTModified = Convert.ToDateTime(reader["gmt_modified"]);
                return model;
            }
            return null;
        }
        /// <summary>
        /// 根据openid，从customer拿到saler_id，再获取具体的saler详细信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static Saler Get(string openid) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select b.name,b.mobile from crm_customer as a left join crm_saler as b on a.saler_id=b.id where a.openid = {0}", openid);
            SqlDataReader reader = MsSQLHelper.ExecuteReader(sb.ToString());
            Saler model = new Saler();
            if (reader.Read()) {
                //model.Id = openid;
                model.Name = reader["name"].ToString();
                model.Status = Convert.ToInt32(reader["status"]);
                model.Mobile = reader["mobile"].ToString();
                model.GMTCreate = Convert.ToDateTime(reader["gmt_create"]);
                if (reader["qrcode_id"] != DBNull.Value)
                    model.QRCodeId = Convert.ToInt32(reader["qrcode_id"]);
                if (reader["gmt_modified"] != DBNull.Value)
                    model.GMTModified = Convert.ToDateTime(reader["gmt_modified"]);
                return model;
            }
            return null;
        }

        public static int GetId(int qrcodeId) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select id" +
                " from crm_saler where qrcode_id = {0}", qrcodeId);
            int ret = Convert.ToInt32(MsSQLHelper.ExecuteScalar(sb.ToString()));
            return ret;
        }
        public static bool Update(Saler model) {
            StringBuilder sb = new StringBuilder();
            sb.Append("update crm_saler set ");
            sb.Append("name = @name,status = @status,");
            sb.Append("qrcode_id = @qrcodeid,");
            sb.Append("mobile = @mobile,gmt_modified = @gmtModified");
            sb.Append(" where id = @id");
            SqlParameter[] parameter = {
                new SqlParameter("@name",model.Name),
                new SqlParameter("@status",model.Status),
                new SqlParameter("@mobile",model.Mobile),
                new SqlParameter("@gmtModified",DateTime.Now),
                new SqlParameter("@qrcodeid",model.QRCodeId),
                new SqlParameter("@id",model.Id)
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
            sb.Append("select id,name,status,mobile,gmt_create,gmt_modified,qrcode_id from crm_saler");
            DataTable table = MsSQLHelper.ExecuteDataTable(sb.ToString());
            if (table.Rows.Count > 0)
                return table;
            return null;
        }
        /// <summary>
        /// 删除（如果已关联二维码，不允许删除）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id) {
            string sb = "delete from crm_saler where (qrcode_id = 0 or qrcode_id = '') and id=" + id;
            int ret = MsSQLHelper.ExecuteNonQuery(sb);
            if (ret > 0)
                return true;
            return false;
        }
    }
}
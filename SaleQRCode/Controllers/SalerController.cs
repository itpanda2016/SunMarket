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
        public static bool Add(CRMSaler model) {
            StringBuilder sb = new StringBuilder();
            sb.Append("Insert into crm_saler (name,mobile,status,gmt_create,qrcode_id) " +
                "values (@activityName,@status,@startTime,@endTime,@tagId,@gmtCreate,@qrcode_id)");
            SqlParameter[] parameter = {
                new SqlParameter("@activityName", model.Name),
                new SqlParameter("@status",model.Status),
                new SqlParameter("@startTime",model.Mobile),
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
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool IsHaveByMobile(CRMSaler model) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select count(*) from crm_saler where mboile ='{0}'", model.Mobile);
            int ret = Convert.ToInt32(MsSQLHelper.ExecuteScalar(sb.ToString()));
            if (ret > 0)
                return true;
            return false;
        }

        public static CRMSaler Get(int id) {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select id,name,mobile,status,gmt_create,gmt_modified,qrcode_id" +
                " from crm_saler where id = {0}", id);
            SqlDataReader reader = MsSQLHelper.ExecuteReader(sb.ToString());
            CRMSaler model = new CRMSaler();
            if (reader.Read()) {
                model.Id = id;
                model.Name = reader["activity_name"].ToString();
                model.Status = Convert.ToInt32(reader["status"]);
                model.GMTCreate = Convert.ToDateTime(reader["gmt_create"]);
                if (reader["qrcode_id"] != DBNull.Value)
                    model.QRCodeId = Convert.ToInt32(reader["qrcode_id"]);
                if (reader["gmt_modified"] != DBNull.Value)
                    model.GMTModified = Convert.ToDateTime(reader["gmt_modified"]);
                return model;
            }
            return null;
        }

        public static bool Update(CRMSaler model) {
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
    }
}
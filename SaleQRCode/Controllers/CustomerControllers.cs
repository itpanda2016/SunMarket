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
            sb.Append("Insert into crm_customer (saler_id,openid,qrcode_id,follow_time,gmt_create) " +
                "values (@saler_id,@openid,@qrcode_id,@follow_time,@gmt_create)");
            SqlParameter[] parameter = {
                new SqlParameter("@saler_id", model.SalerId),
                new SqlParameter("@openid",model.Openid),
                new SqlParameter("@qrcode_id",model.QRCodeId),
                new SqlParameter("@follow_time",model.FollowTime),
                new SqlParameter("@gmt_create",DateTime.Now)
                };
            int ret = MsSQLHelper.ExecuteNonQuery(sb.ToString(), CommandType.Text, parameter);
            if (ret == 0)
                return false;
            return true;
        }
    }
}
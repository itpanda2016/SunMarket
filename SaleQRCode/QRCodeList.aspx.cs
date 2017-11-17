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
                rptList.DataSource = dt;
                rptList.DataBind();
            }
        }
    }
}
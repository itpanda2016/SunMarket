using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FROST.Utility;
using FROST.WeixinMP;
using FROST.WeixinMP.AdvancedAPI.Ticket;
using SaleQRCode.Controllers;
using SaleQRCode.Models;
using WeChat;

namespace SaleQRCode {
    public partial class QRCodeNew : System.Web.UI.Page {
        public string accessToken = "";
        public TicketResult ticket = new TicketResult();
        public string obj = "";
        protected void Page_Load(object sender, EventArgs e) {
            // && !string.IsNullOrEmpty(Request["qrcode_number"])
            if (Request.HttpMethod == "POST") {
                WeChatQRCode qRCode = new WeChatQRCode();
                qRCode.QRCodeType = "QR_LIMIT_SCENE";
                if (QRCodeController.Add(qRCode)) {
                    qRCode.Id = qRCode.SceneID = QRCodeController.GetLastID();
                    accessToken = AccessTokenContainer.GetAccessToken();
                    ticket = OtherApi.GetTicket(accessToken, qRCode.SceneID);
                    qRCode.Ticket = ticket.ticket;
                    if(QRCodeController.Update(qRCode)) {
                        Message.Dialog("添加二维码成功。","/QRCodeList.aspx");
                    }
                    else {
                        Message.Dialog("添加失败！！！");
                    }
                }
            }
        }
    }
}
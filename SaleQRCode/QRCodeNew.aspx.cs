using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FROST.Utility;
using FROST.WeixinMP;

using FROST.WeixinMP.AdvancedAPI.Ticket;

namespace SaleQRCode {
    public partial class QRCodeNew : System.Web.UI.Page {
        public string accessToken = "";
        public TicketResult ticket = new TicketResult();
        public string obj = "";
        protected void Page_Load(object sender, EventArgs e) {
            accessToken = WeChat.AccessTokenContainer.GetAccessToken();
            ticket = OtherApi.GetTicket(accessToken, 1001);
            obj = OtherApi.GetQRCode(Server.UrlEncode(ticket.ticket));
        }
    }
}
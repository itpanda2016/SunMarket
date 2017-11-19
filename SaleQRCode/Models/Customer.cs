using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleQRCode {
    public class Customer {
        public int Id { set; get; }
        public int SalerId { set; get; }
        public string Openid { set; get; }
        public int QRCodeId { set; get; }
        public DateTime FollowTime { set; get; }
        /// <summary>
        /// 事件类型，subscribe(订阅)、unsubscribe(取消订阅)
        /// </summary>
        public string Status { set; get; }
        public DateTime GMTCreate { set; get; }
        public DateTime GMTModified { set; get; }

    }
}
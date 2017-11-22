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
        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        public int Subscribe { set; get; }
        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        public string Headimgurl { set; get; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { set; get; }
        public DateTime GMTCreate { set; get; }
        public DateTime GMTModified { set; get; }
        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        public DateTime SubscribeTime { set; get; }
    }
}
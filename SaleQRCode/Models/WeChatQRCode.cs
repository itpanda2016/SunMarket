using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FROST.Utility;

namespace SaleQRCode {
    public class WeChatQRCode {
        /// <summary>
        /// 系统ID
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GMTCreate { set; get; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime GMTModified { set; get; }
        /// <summary>
        /// 二维码类型（QR_SCENE为临时的整型参数值，QR_STR_SCENE为临时的字符串参数值，QR_LIMIT_SCENE为永久的整型参数值，QR_LIMIT_STR_SCENE为永久的字符串参数值）
        /// </summary>
        public string QRCodeType { set; get; }
        /// <summary>
        /// 二维码【永久的整型参数值】
        /// </summary>
        public int SceneID { set; get; }
        /// <summary>
        /// 二维码【永久的字符串参数值】
        /// </summary>
        public string SceneStr { set; get; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public int ExpireSeconds { set; get; }
        /// <summary>
        /// 二维码Ticket
        /// </summary>
        public string Ticket { set; get; }
    }
}
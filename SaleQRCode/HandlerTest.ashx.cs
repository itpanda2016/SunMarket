using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SufeiUtil;

namespace SaleQRCode {
    /// <summary>
    /// HandlerTest 的摘要说明
    /// </summary>
    public class HandlerTest : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string url = "http://61.188.37.66:9528/api/values/checkWechat?number=sbfhuabsbfvwq21c54e545we5asd5qw5";
            HttpItem item = new HttpItem();
            item.URL = url;
            HttpHelper helper = new HttpHelper();
            context.Response.Write(helper.GetHtml(item).Html);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
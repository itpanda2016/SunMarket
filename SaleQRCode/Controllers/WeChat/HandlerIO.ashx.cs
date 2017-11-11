using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleQRCode.Controllers.WeChat {
    /// <summary>
    /// HandlerIO 的摘要说明
    /// </summary>
    public class HandlerIO : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            context.Response.End();
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
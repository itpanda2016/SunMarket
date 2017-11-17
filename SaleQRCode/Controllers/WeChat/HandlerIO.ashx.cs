using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using FROST.Utility;
using System.Configuration;

namespace SaleQRCode.Controllers.WeChat {
    /// <summary>
    /// HandlerIO 的摘要说明
    /// 20171117
    ///     1）校验代码必须和消息处理代码放在一起，因为微信每次接收消息时都会校验
    /// </summary>
    public class HandlerIO : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/plain";
            TxtLogHelper logHelper = new TxtLogHelper(context.Server.MapPath("~/App_Data/"));
            logHelper.Info("创建日志：" + DateTime.Now.ToString());
            //context.Response.Write("Hello World");
            //context.Response.End();
            if (context.Request.HttpMethod== "POST") {
                logHelper.Info("进入POST事件");
                XmlReader reader = XmlReader.Create(context.Request.InputStream);
                XDocument xDocument = XDocument.Load(reader);
                XElement xe = xDocument.Element("xml");
                string fromOpenid = xe.Element("FromUserName").Value;
                string toOpenid = xe.Element("ToUserName").Value;
                logHelper.Info("获取到fromOpenid：" + fromOpenid + "，以及toOpenid：" + toOpenid);
                string strRespose = "<xml>";
                strRespose += "<ToUserName><![CDATA[{0}]]></ToUserName>";
                strRespose += "<FromUserName><![CDATA[{1}]]></FromUserName>";
                strRespose += "<CreateTime>{2}</CreateTime>";
                strRespose += "<MsgType><![CDATA[text]]></MsgType>";
                strRespose += "<Content><![CDATA[{3}]]></Content>";
                strRespose += "</xml>";

                context.Response.Write(string.Format(strRespose, fromOpenid, toOpenid, DateTime.Now.ToBinary(),
                    "感谢您的关注或回复。"));
                logHelper.Info("完成消息回复。");
            }
            else if(context.Request.HttpMethod == "GET") {
                string token = ConfigurationManager.AppSettings["Token"];
                //context.Response.ContentType = "text/plain";
                string echoStr = context.Request.QueryString["echoStr"];//随机字符串 
                string signature = context.Request.QueryString["signature"];//微信加密签名
                string timestamp = context.Request.QueryString["timestamp"];//时间戳 
                string nonce = context.Request.QueryString["nonce"];//随机数 
                string[] ArrTmp = { token, timestamp, nonce };
                Array.Sort(ArrTmp);     //字典排序
                string tmpStr = string.Join("", ArrTmp);
                tmpStr = Encrypt.SHA1(tmpStr).ToLower();  //貌似没有测试
                if (tmpStr == signature) {
                    context.Response.Write(echoStr);
                }
                else {
                    context.Response.Write(false);
                }
            }
            context.Response.End();

        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
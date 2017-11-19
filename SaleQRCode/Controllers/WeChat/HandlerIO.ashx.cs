using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using FROST.Utility;
using System.Configuration;
using System.Text;
using SaleQRCode;

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
            if (context.Request.HttpMethod== "POST") {
                logHelper.Info("进入POST事件");
                XmlReader reader = XmlReader.Create(context.Request.InputStream);
                XDocument xDocument = XDocument.Load(reader);
                XElement xe = xDocument.Element("xml");
                string fromOpenid = xe.Element("FromUserName").Value;
                string toOpenid = xe.Element("ToUserName").Value;
                string msgType = xe.Element("MsgType").Value;

                logHelper.Info("获取到fromOpenid：" + fromOpenid + "，以及toOpenid：" + toOpenid);
                string strRespose = "<xml>";
                strRespose += "<ToUserName><![CDATA[{0}]]></ToUserName>";
                strRespose += "<FromUserName><![CDATA[{1}]]></FromUserName>";
                strRespose += "<CreateTime>{2}</CreateTime>";
                strRespose += "<MsgType><![CDATA[text]]></MsgType>";
                strRespose += "<Content><![CDATA[{3}]]></Content>";
                strRespose += "</xml>";
                StringBuilder defReturn = new StringBuilder();
                defReturn.Append("终于等到你！感谢您关注：阳光菜篮\n");
                defReturn.Append("阳光菜篮商贸有限公司商城是坚持让“老百姓种的菜始终在餐桌上”“把菜市场搬到家里”的绿色健康方便快捷的理念，立足于德阳本地，与各安全的食品生产基地签订合作协议，严控各类生鲜产品的质量，完善采购渠道，完整配送体系，用优质的售后服务，以保证让每个顾客花最少的钱而买到最优质的生鲜产品，享受到亲切的一站式服务。\n");
                defReturn.Append("我们提供生鲜网上配送服务：\n");
                defReturn.Append("我公司主营业；时令水果 时令蔬菜 家禽肉类\n");
                defReturn.Append("粮油调料 酒水饮料 休闲食品等\n");
                defReturn.Append("客服电话：0838 - 3203899\n");

                if (msgType == "text") {
                    //context.Response.Write(string.Format(strRespose, fromOpenid, toOpenid, DateTime.Now.ToBinary(),defReturn.ToString()));
                }else if(msgType == "event") {
                    string eventKey = xe.Element("EventKey").Value.Replace("qrscene_","");
                    string eventType = xe.Element("Event").Value;
                    if(eventType == "subscribe") {
                        defReturn.Clear();
                        Customer customer = new Customer();
                        customer.Openid = fromOpenid;
                        customer.SalerId = SalerController.GetId(Convert.ToInt32(eventKey));
                        customer.QRCodeId = Convert.ToInt32(eventKey);
                        customer.FollowTime = DateTime.Now;
                        if (CustomerControllers.Add(customer)) {
                            defReturn.Append("感谢关注，您绑定ID为：" + customer.SalerId + "，来自二维码：" + customer.QRCodeId);
                        }
                        else {
                            defReturn.Append("关注失败。");
                        }
                    }
                }
                else {
                    //context.Response.Write(string.Format(strRespose, fromOpenid, toOpenid, DateTime.Now.ToBinary(), defReturn.ToString()));
                }
                context.Response.Write(string.Format(strRespose, fromOpenid, toOpenid, DateTime.Now.ToBinary(), defReturn.ToString()));
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
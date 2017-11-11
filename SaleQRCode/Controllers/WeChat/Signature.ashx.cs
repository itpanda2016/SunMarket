﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using FROST.Utility;

namespace WeChat {
    /// <summary>
    /// Signature 的摘要说明
    /// </summary>
    public class Signature : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string token = ConfigurationManager.AppSettings["Token"];
            context.Response.ContentType = "text/plain";
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
            context.Response.End();
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}
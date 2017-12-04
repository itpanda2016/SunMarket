using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using SufeiUtil;
using Newtonsoft.Json;
using System.Configuration;

namespace WeChat {
    /// <summary>
    /// XML版本，可以优化为多用户使用，也就是按用户添加节点。
    /// </summary>
public class AccessTokenContainer {
        private static XmlDocument xml = new XmlDocument();
        public static string GetAccessToken() {
            xml.Load(HttpContext.Current.Server.MapPath("/App_Data/AccessToken.xml"));
            string appId = ConfigurationManager.AppSettings["AppId"].Trim();
            string appSecret = ConfigurationManager.AppSettings["AppSecret"].Trim();
            if (appId == "" || appSecret == "")
                return "No AppId, No AppSecret";

            XmlNode access_token = xml.SelectSingleNode("WeChat/AccessToken");
            XmlNode expires = xml.SelectSingleNode("WeChat/Expires");
            //todo Debug期间每次都获取新的accesstoken
            //if (CheckAccessToken(expires)) return access_token.InnerText;
            //获取新的access_token
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appId + "&secret=" + appSecret;
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem();
            item.URL = url;
            string ret = http.GetHtml(item).Html;
            if (ret.IndexOf("errcode") > 0)
                return "Get AccessToken Error, return by http.GetHtml:" + ret;
            ModelsAccessTokenOK tokenOK = JsonConvert.DeserializeObject<ModelsAccessTokenOK>(ret);
            access_token.InnerText = tokenOK.access_token;

            expires.InnerText = DateTime.Now.AddSeconds(tokenOK.expires_in).ToString("yyyy-MM-dd HH:mm:ss");
            xml.Save(HttpContext.Current.Server.MapPath("/App_Data/AccessToken.xml"));
            return access_token.InnerText;
        }
        /// <summary>
        /// 根据expires判断access_token是否可用
        /// </summary>
        /// <param name="nodeExpires"></param>
        /// <returns></returns>
        private static bool CheckAccessToken(XmlNode nodeExpires) {
            DateTime time = DateTime.Now.AddSeconds(-180);   //取一个相比于当前时间已经过去了的时间
            if (nodeExpires.InnerText.Trim() == "")
                return false;
            time = Convert.ToDateTime(nodeExpires.InnerText.Trim());
            //哈哈，这儿判断纠结了半天，结果是前面在存放时间的时候，格式输错了：
            //HH应该大小，才表示24小时制，如果是hh，就是12小时制
            //但DateTime.Now返回的就是24小时制，所以为了保险，DateTime.Now返回值也应该再转换一次
            if (time <= DateTime.Now)
                return false;
            return true;
        }
    }

    public class ModelsAccessTokenOK {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }

    public class ModelsAccessTokenError {
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }
}
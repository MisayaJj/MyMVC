using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MyMVC.Struts
{
    /// <summary>
    /// 网页编程常用帮助类
    /// </summary>
    public class PageHelp
    {
        private System.Web.HttpApplicationState Application = null;
        private System.Web.HttpRequest Request = null;
        private System.Web.HttpResponse Response = null;
        private System.Web.SessionState.HttpSessionState Session = null;
        private System.Web.HttpServerUtility Server = null;
        private System.Web.HttpContext Context = null;

        public PageHelp()
        {
            Application = System.Web.HttpContext.Current.Application;
            Request = System.Web.HttpContext.Current.Request;
            Response = System.Web.HttpContext.Current.Response;
            Session = System.Web.HttpContext.Current.Session;
            Server = System.Web.HttpContext.Current.Server;
            Context = System.Web.HttpContext.Current;
        }

        #region 获取URL 中的参数
        /// <summary>
        /// 从Request中的Url中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 ""</returns>
        public string Query(string name)
        {
            if (Request.QueryString[name] != null)
                return Request.QueryString[name].ToString().Trim();
            return "";
        }
        /// <summary>
        /// 从Request中的Url中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public int QueryInt32(string name)
        {
            Int32 value = 0;
            Int32.TryParse(Query(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Url中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public Int64 QueryInt64(string name)
        {
            Int64 value = 0;
            Int64.TryParse(Query(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Url中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 false</returns>
        public bool QueryBool(string name)
        {
            bool value = false;
            bool.TryParse(Query(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Url中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public float QueryFloat(string name)
        {
            float value = 0;
            float.TryParse(Query(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Url中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public decimal QueryDecimal(string name)
        {
            decimal value = 0;
            decimal.TryParse(Query(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Url中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 new DateTime()</returns>
        public DateTime QueryDate(string name)
        {
            DateTime value = new DateTime();
            DateTime.TryParse(Query(name), out value);
            return value;
        }
        #endregion

        #region 获取Param 中的参数
        /// <summary>
        /// 从Request中的Params中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 ""</returns>
        public string Param(string name)
        {
            if (Request.Params[name] != null)
                return Request.Params[name].ToString().Trim();
            return "";
        }
        /// <summary>
        /// 从Request中的Params中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public int ParamInt32(string name)
        {
            Int32 value = 0;
            Int32.TryParse(Param(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Params中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public Int64 ParamInt64(string name)
        {
            Int64 value = 0;
            Int64.TryParse(Param(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Params中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 false</returns>
        public bool ParamBool(string name)
        {
            bool value = false;
            bool.TryParse(Param(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Params中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public float ParamFloat(string name)
        {
            float value = 0;
            float.TryParse(Param(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Params中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public decimal ParamDecimal(string name)
        {
            decimal value = 0;
            decimal.TryParse(Param(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Params中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 new DateTime()</returns>
        public DateTime ParamDate(string name)
        {
            DateTime value = new DateTime();
            DateTime.TryParse(Param(name), out value);
            return value;
        }
        #endregion

        #region 获取Form 中的参数
        /// <summary>
        /// 从Request中的Form中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 ""</returns>
        public string FormString(string name)
        {
            if (Request.Form[name] != null)
                return Request.Form[name].ToString().Trim();
            return "";
        }
        /// <summary>
        /// 从Request中的Form中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public int FormInt32(string name)
        {
            Int32 value = 0;
            Int32.TryParse(FormString(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Form中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public Int64 FormInt64(string name)
        {
            Int64 value = 0;
            Int64.TryParse(FormString(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Form中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 false</returns>
        public bool FormBool(string name)
        {
            bool value = false;
            bool.TryParse(FormString(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Form中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public float FormFloat(string name)
        {
            float value = 0;
            float.TryParse(FormString(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Form中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 0</returns>
        public decimal FormDecimal(string name)
        {
            decimal value = 0;
            decimal.TryParse(FormString(name), out value);
            return value;
        }
        /// <summary>
        /// 从Request中的Form中根据参数获取值
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>返回值，为空返回 new DateTime()</returns>
        public DateTime FormDate(string name)
        {
            DateTime value = new DateTime();
            DateTime.TryParse(FormString(name), out value);
            return value;
        }
        #endregion

        #region 获取Session中的值
        /// <summary>
        /// 从Session中根据key获取string值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>string</returns>
        public string GetSession(string key)
        {
            if (Session[key] != null) return Session[key].ToString();
            else return "";
        }
        /// <summary>
        /// 从Session中根据key获取Int32值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Int32</returns>
        public Int32 GetSessionInt32(string key)
        {
            int v = 0;
            if (Session[key] != null) int.TryParse(Session[key].ToString().Trim(), out v);
            return v;
        }
        /// <summary>
        /// 从Session中根据key获取Int64值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Int64</returns>
        public Int64 GetSessionInt64(string key)
        {
            long v = 0;
            if (Session[key] != null) long.TryParse(Session[key].ToString().Trim(), out v);
            return v;
        }
        /// <summary>
        /// 从Session中根据key获取bool值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>bool</returns>
        public bool GetSessionBool(string key)
        {
            bool v = false;
            if (Session[key] != null) bool.TryParse(Session[key].ToString().Trim(), out v);
            return v;
        }
        /// <summary>
        /// 从Session中根据key获取bool值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>decimal</returns>
        public decimal GetSessionDecimal(string key)
        {
            decimal v = 0;
            if (Session[key] != null) decimal.TryParse(Session[key].ToString().Trim(), out v);
            return v;
        }
        /// <summary>
        /// 从Session中根据key获取DateTime值
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>DateTime</returns>
        public DateTime GetSessionDateTime(string key)
        {
            DateTime v = new DateTime();
            if (Session[key] != null) DateTime.TryParse(Session[key].ToString().Trim(), out v);
            return v;
        }
        #endregion

        #region 类型转换
        /// <summary>
        /// 类型转换为string
        /// </summary>
        /// <param name="o">值</param>
        /// <returns>返回转换后的类型，为空返回 ""</returns>
        public string Parse(object o)
        {
            if (o != null)
                return o.ToString().Trim();
            return "";
        }
        /// <summary>
        /// 类型转换为Int32
        /// </summary>
        /// <param name="o">值</param>
        /// <returns>返回转换后的类型，为空返回 0</returns>
        public int ParseInt32(object o)
        {
            Int32 value = 0;
            if (o != null)
                Int32.TryParse(o.ToString().Trim(), out value);
            return value;
        }
        /// <summary>
        /// 类型转换为Int64
        /// </summary>
        /// <param name="o">值</param>
        /// <returns>返回转换后的类型，为空返回 0</returns>
        public Int64 ParseInt64(object o)
        {
            Int64 value = 0;
            if (o != null)
                Int64.TryParse(o.ToString().Trim(), out value);
            return value;
        }
        /// <summary>
        /// 类型转换为bool
        /// </summary>
        /// <param name="o">值</param>
        /// <returns>返回转换后的类型，为空返回 false</returns>
        public bool ParseBool(object o)
        {
            bool value = false;
            if (o != null)
                bool.TryParse(o.ToString().Trim(), out value);
            return value;
        }
        /// <summary>
        /// 类型转换为Float
        /// </summary>
        /// <param name="o">值</param>
        /// <returns>返回转换后的类型，为空返回 0</returns>
        public float ParseFloat(object o)
        {
            float value = 0;
            if (o != null)
                float.TryParse(o.ToString().Trim(), out value);
            return value;
        }
        /// <summary>
        /// 类型转换为Decimal
        /// </summary>
        /// <param name="o">值</param>
        /// <returns>返回转换后的类型，为空返回 0</returns>
        public decimal ParseDecimal(object o)
        {
            decimal value = 0;
            if (o != null)
                decimal.TryParse(o.ToString().Trim(), out value);
            return value;
        }
        /// <summary>
        /// 类型转换为DateTime
        /// </summary>
        /// <param name="o">值</param>
        /// <returns>返回转换后的类型，为空返回 new DateTime()</returns>
        public DateTime ParseDate(object o)
        {
            DateTime value = new DateTime();
            if (o != null)
                DateTime.TryParse(o.ToString().Trim(), out value);
            return value;
        }
        #endregion

        #region 检查图片或者文件是否存在
        /// <summary>
        /// 检查图片文件是否存在
        /// </summary>
        /// <param name="o">图片路径</param>
        /// <returns>图片路径，不存在图片时返回空图片路径</returns>
        public string GetImage(object o)
        {
            return GetImage(o, "/images/no.jpg");

        }
        /// <summary>
        /// 检查图片文件是否存在
        /// </summary>
        /// <param name="o">图片路径</param>
        /// <param name="replaceImg">不存在替换的图片路径</param>
        /// <returns>图片路径，不存在图片时返回替换图片路径</returns>
        public string GetImage(object o, string replaceImg)
        {
            string path = Parse(o);
            if (!string.IsNullOrEmpty(path))
            {
                if (System.IO.File.Exists(Server.MapPath(path))) return path;
                else return replaceImg;
            }
            else return replaceImg;

        }
        /// <summary>
        /// 检查文件是否存在
        /// </summary>
        /// <param name="o">文件路径</param>
        /// <returns>true:存在  false:不存在</returns>
        public bool FileExists(object o)
        {
            string path = Parse(o);
            if (!string.IsNullOrEmpty(path))
            {
                if (System.IO.File.Exists(Server.MapPath(path))) return true;
                else return false;
            }
            return false;
        }
        #endregion

        #region MapPath
        /// <summary>
        /// 返回与Web服务器上指定虚拟路径对应的物理文件路径，替代Server.MapPath有可能HttpContext.Current为null的情况
        /// </summary>
        /// <param name="path">Web服务器的虚拟路径</param>
        /// <returns>返回与Web服务器上指定虚拟路径对应的物理文件路径</returns>
        public string MapPath(string path)
        {
            if (path.StartsWith("/")) path = path.Substring(1, path.Length - 1);
            return System.IO.Path.Combine(HttpRuntime.AppDomainAppPath, path.Replace("/", "\\"));
        }
        #endregion

        /// <summary>
        /// 获取当前网站的域名
        /// </summary>
        /// <returns></returns>
        public string GetDomain()
        {
            return string.Format("{0}://{1}", Request.Url.Scheme, Request.Url.Authority);
        }

    }
}

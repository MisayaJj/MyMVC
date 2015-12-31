using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections;
using System.ComponentModel;
using System.Configuration;

namespace MyMVC.Struts
{
    /// <summary>
    /// 主控制器，主要是拦截请求根据请求映射对应的处理程序并转发处理请求
    /// </summary>
    internal class ActionControl : IHttpHandler, IRequiresSessionState
    {
        public System.Web.HttpApplicationState Application = null;
        public System.Web.HttpRequest Request = null;
        public System.Web.HttpResponse Response = null;
        public System.Web.SessionState.HttpSessionState Session = null;
        public System.Web.HttpServerUtility Server = null;
        public System.Web.HttpContext Context = null;
        //要执行的action方法
        public string defaultMethod = "";
        //cache key
        private string configcachekey = "strutsconfig";
        //是否要进行SQL注入过滤
        private bool isnoINJ = false;

        #region ProcessRequest

        public void ProcessRequest(HttpContext context)
        {
            this.Application = context.Application;
            this.Request = context.Request;
            this.Response = context.Response;
            this.Session = context.Session;
            this.Server = context.Server;
            this.Context = context;

            StrutsConfig sc = null;
            if (MyMVC.Comm.Cache.GetCache(configcachekey) != null)
            {
                sc = MyMVC.Comm.Cache.GetCache(configcachekey) as StrutsConfig;
            }
            else
            {
                sc = ConfigurationManager.GetSection("strutsConfig") as StrutsConfig;
                MyMVC.Comm.Cache.SetCache(configcachekey, sc);
            }
            if (sc != null)
            {
                ActionMapping(sc);
            }
            else if (string.IsNullOrEmpty(sc.Assembly))
            {
                throw new Exception("strutsConfig中的assembly为空。");
            }
            else
            {
                throw new Exception("未能在web.config文件中读取到strutsConfig节点信息。");
            }
        }


        /// <summary>
        /// 根据请求映射对应的action 处理程序
        /// </summary>
        /// <param name="sc">StrutsConfig</param>
        public void ActionMapping(StrutsConfig sc)
        {
            string assembly = sc.Assembly;
            string rawurl = Request.RawUrl;
            string urlFile = Request.FilePath;
            string className = string.Format("{0}{1}.{2}", sc.Assembly, System.IO.Path.GetDirectoryName(rawurl).Replace("\\", ""), System.IO.Path.GetFileNameWithoutExtension(urlFile)).ToLower();
            //如果没有目录则过滤掉多余的层级
            className = className.Replace("..", ".");
            //过去掉要执行的方法
            className = Regex.Replace(className, "!.*", "");
            //反射类
            object o = System.Reflection.Assembly.Load(assembly).CreateInstance(className, true);
            if (o != null)
            {
                Assembly ass = Assembly.Load(assembly);
                Type t = ass.GetType(className, true, true);
                //初始化Action
                MethodInfo mi = t.GetMethod("ProcessRequest");
                //执行的方法
                string todo = Regex.Match(System.IO.Path.GetFileNameWithoutExtension(urlFile), "!.*").Value.Replace("!", "");
                if (todo != "") { defaultMethod = todo; }
                else { defaultMethod = "Execute"; }

                MethodInfo[] mis = t.GetMethods();
                bool isUpMethod = false;
                foreach (MethodInfo m in mis)
                {
                    if (m.Name == defaultMethod) { isUpMethod = true; defaultMethod = m.Name; }
                }
                if (!isUpMethod)
                {
                    foreach (MethodInfo m in mis)
                    {
                        if (m.Name.ToLower() == defaultMethod.ToLower()) { isUpMethod = true; defaultMethod = m.Name; }
                    }
                }
                //要执行的请求
                MethodInfo mtodo = t.GetMethod(defaultMethod);
                //是否存在NoInjection标签
                if (mtodo != null)
                {
                    NoInjection[] noij = mtodo.GetCustomAttributes(typeof(NoInjection), true) as NoInjection[];
                    if (noij.Length > 0) isnoINJ = true;
                    else isnoINJ = false;

                    //根据请求中的参数给Action动态赋值
                    string[] k1 = Request.QueryString.AllKeys;
                    string[] k2 = Request.Form.AllKeys;
                    string[] keys = MergeArray(k1, k2);
                    foreach (string k in keys)
                    {
                        bool flag = false;
                        PropertyInfo[] pis = t.GetProperties();
                        foreach (PropertyInfo p in pis)
                        {
                            if (p.Name == k)
                            {
                                try
                                {
                                    p.SetValue(o, ChanageType(Request.Params[k], p.PropertyType), null);
                                    flag = true;
                                    break;
                                }
                                catch { }
                            }
                        }
                        if (!flag)
                        {
                            foreach (PropertyInfo p in pis)
                            {
                                if (p.Name.ToLower() == k.ToLower())
                                {
                                    try
                                    {
                                        p.SetValue(o, ChanageType(Request.Params[k], p.PropertyType), null);
                                    }
                                    catch { }
                                    break;
                                }
                            }
                        }
                    }
                    //执行初始化
                    mi.Invoke(o, new object[] { Context });
                    //执行要执行的方法
                    mtodo.Invoke(o, null);
                }
                else
                {
                    Response.Redirect(sc.Error);
                }
            }
            else
            {
                Response.Redirect(sc.Error);
            }
        }
        #endregion

        #region ChangeTypes
        public object ChanageType(object value, Type convertsionType)
        {
            //判断convertsionType类型是否为泛型，因为nullable是泛型类,
            if (convertsionType.IsGenericType && convertsionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString().Length == 0)
                {
                    return null;
                }
                //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                NullableConverter nullableConverter = new NullableConverter(convertsionType);
                //将convertsionType转换为nullable对的基础基元类型
                convertsionType = nullableConverter.UnderlyingType;
            }
            //是否要防SQL注入
            if (isnoINJ && convertsionType.Name == "String" && value != null)
            {
                string strT = value.ToString().Replace("'", "");
                return Convert.ChangeType(strT, convertsionType);
            }
            else
                return Convert.ChangeType(value, convertsionType);
        }
        #endregion

        #region 辅助方法

        /// <summary>
        /// 合并数组
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static string[] MergeArray(string[] a, string[] b)
        {

            ArrayList student = new ArrayList();
            foreach (string s1 in a)
            {
                student.Add(s1);
            }
            foreach (string s2 in b)
            {
                bool flag = true;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] == s2)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    student.Add(s2);
                }
            }
            string[] c1 = (string[])student.ToArray(typeof(string));
            return c1;
        }
        public bool IsReusable
        {
            get { return true; }
        }

        #endregion

    }
}

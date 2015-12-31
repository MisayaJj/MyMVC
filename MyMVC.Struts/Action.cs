using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MyMVC.Struts
{
    /// <summary>
    /// <para>请求控制处理中的Control基类</para>
    /// <para>使用说明:</para>
    /// <para>1.需要在web.config中配置strutsConfig节点，并在assembly中设置控制器的类库</para>
    /// <para>2.在httpHandlers配置拦截器</para>
    /// <para>3.控制器继承CnGine.Struts.Action 重写默认的Execute方法</para>
    /// <para>4.如需验证请重写Validate方法，Validate方法会在Execute和自定义方法之前执行</para>
    /// <para>5.在有参数传递跳转到视图层请使用Server.Transfer("") (注：参数传递仅在Transfer时才有效)</para>
    /// <para>6.请求user.do和user!reg.do时候会分别执行Execute和reg方法 (注：方法区分大小写，若唯一则忽略大小写)</para>
    /// <para>7.在get post请求中有参数传递，如果在控制器中有同名的属性，会自动赋值 (注：属性名分大小写，若唯一则忽略大小写)</para>
    /// <para>8.如果根据请求无法映射出对应的处理程序会跳转到默认值~/error/404.html(可在strutsConfig修改)</para>
    /// </summary>
    public class Action
    {
        public System.Web.HttpApplicationState Application = null;
        public System.Web.HttpRequest Request = null;
        public System.Web.HttpResponse Response = null;
        public System.Web.SessionState.HttpSessionState Session = null;
        public System.Web.HttpServerUtility Server = null;
        public System.Web.HttpContext Context = null;
        // 通用的常用辅助方法
        public PageHelp PageHelp = new PageHelp();

        public void ProcessRequest(HttpContext context)
        {
            this.Application = context.Application;
            this.Request = context.Request;
            this.Response = context.Response;
            this.Session = context.Session;
            this.Server = context.Server;
            this.Context = context;
            Init();
            Validate();
        }
        public virtual void Init()
        {

        }
        public virtual void Validate()
        {
        }
        /// <summary>
        /// 重载执行的方法(默认的方法)
        /// </summary>
        public virtual void Execute()
        {

        }
        /// <summary>
        /// <para>1.在上下文中传递参数,尽在在Server.Transfer("") 时有效</para>
        /// <para>2.获取值使用 Context.Items[""]</para>
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="o">值</param>
        protected void AddItem(string key, object o)
        {
            Context.Items.Add(key, o);
        }

    }
}

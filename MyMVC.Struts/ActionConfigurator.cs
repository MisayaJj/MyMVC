using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;

namespace MyMVC.Struts
{
    /// <summary>
    /// 配置文件映射类
    /// </summary>
    public class ActionConfigurator : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            StrutsConfig sc = new StrutsConfig();
            foreach (XmlNode xn in section.ChildNodes)
            {
                switch (xn.Name.ToLower())
                {
                    case "assembly":
                        sc.Assembly = xn.SelectSingleNode("@value").InnerText;
                        break;
                    case "config":
                        sc.Config = xn.SelectSingleNode("@value").InnerText;
                        break;
                    case "error":
                        sc.Error = xn.SelectSingleNode("@value").InnerText;
                        break;
                }
            }
            return sc;

        }

    }
}

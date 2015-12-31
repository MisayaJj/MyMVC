using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMVC.Controller
{
    public class Home : MyMVC.Struts.Action
    {

        public string name { set; get; }



        [MyMVC.Struts.NoInjection]
        public override void Execute()
        {
            string str = string.Format("now:{0},name:{1}", DateTime.Now.ToString(), name);
            //Response.Write(str);

            string path1 = System.AppDomain.CurrentDomain.BaseDirectory + "/view/home.cshtml";  //Server.MapPath("~/view/home.cshtml");
            var tmpl = System.IO.File.ReadAllText(path1, Encoding.GetEncoding("UTF-8"));

            var list = new List<MyMVC.Model.Student>()
            {
                 new MyMVC.Model.Student(){ Name="张三",Age=10 },
                 new MyMVC.Model.Student(){ Name="李四",Age=20 },
                 new MyMVC.Model.Student(){ Name="王五",Age=30 },
            };
            string result = RazorEngine.Razor.Parse(tmpl, new { StudentList = list, Para = str, aaa = "bbb" });
            Response.Write(result);
        }

    }
}

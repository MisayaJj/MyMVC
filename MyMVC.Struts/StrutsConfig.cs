using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMVC.Struts
{
    public class StrutsConfig
    {
        private string _config = "Control";
        private string _assembly = "";
        private string _error = "~/error/404.html";

        public string Config
        {
            set { this._config = value; }
            get { return this._config; }
        }

        public string Assembly
        {
            set { this._assembly = value; }
            get { return this._assembly; }
        }
        public string Error
        {
            set { this._error = value; }
            get { return this._error; }
        }

    }
}

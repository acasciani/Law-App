using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LawAppWeb
{
    public partial class ApplicationsController : OpenAccessBaseApiController<Application, LawApp>
    {
        public Application CreateApplication(string name)
        {
            Application newApp = new Application()
            {
                ApplicationName = name
            };

            HttpResponseMessage response = this.Post(newApp);

            return null;
        }
    }
}
﻿using Microsoft.Owin;
using OrangeBricks.Web.App_Start;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrangeBricks.Web.Startup))]
namespace OrangeBricks.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           
        }
    }
}

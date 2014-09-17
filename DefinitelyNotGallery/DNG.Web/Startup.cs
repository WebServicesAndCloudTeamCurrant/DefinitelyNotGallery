using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Ninject.Web.WebApi;
using Ninject.Web;
using Ninject;
using System.Reflection;
using DNG.Data;
[assembly: OwinStartup(typeof(DNG.Web.Startup))]

namespace DNG.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app); 
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IDngData>().To<DngData>()
                .WithConstructorArgument("context",
                    c => new DngDbContext());

            
        }
    }
}

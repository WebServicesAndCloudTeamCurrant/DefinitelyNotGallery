using Microsoft.Owin;

[assembly: OwinStartup(typeof(DNG.Web.Startup))]

namespace DNG.Web
{
    using DNG.Data;
    using Ninject;
    using Ninject.Web.Common.OwinHost;
    using Ninject.Web.WebApi.OwinHost;
    using Owin;
    using System.Reflection;
    using System.Web.Http;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel)
                .UseNinjectWebApi(GlobalConfiguration.Configuration);
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
            kernel.Bind<IDngData>()
                .To<DngData>()
                .WithConstructorArgument("context", c => new DngDbContext());
        }
    }
}
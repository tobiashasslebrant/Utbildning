using System.Configuration;
using Utbildning.App.Core.DB;
using Utbildning.App.Core.Models;
using Utbildning.App.Core.Repositories;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Utbildning.App.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Utbildning.App.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Utbildning.App.Web.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDatabase<Article>>()
                .ToMethod(m => new MongoDatabase<Article>(ConfigurationManager.AppSettings["MongoDBConnectionString"]));
            
            kernel.Bind<IArticleRepository>().To<ArticleRepository>();
        }        
    }
}

using BLL;
using DLL;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.BLL.Logic;
using Task_1.DAL.Abstract;

namespace Task_1.Common.NinjectConfig
{
    public class Config
    {
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            kernel
                .Bind<SqlDALConfig>()
                .ToSelf()
                .InSingletonScope()
                .WithConstructorArgument(
                "connectionString",
                ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            kernel
                .Bind<IRecipieLogic>()
                .To<RecipieLogic>()
                .InSingletonScope();
            kernel
                .Bind<IUserLogic>()
                .To<UserLogic>()
                .InSingletonScope();
            kernel.Bind<IImageLogic>()
                .To<ImageLogic>()
                .InSingletonScope();
            kernel
                .Bind<IUserDAL>()
                .To<UserDAL>()
                .InSingletonScope();
            kernel
                .Bind<IRecipieDAL>()
                .To<RecipieDAL>()
                .InSingletonScope();
            kernel
                .Bind<IImageDAL>()
                .To<ImageDAL>()
                .InSingletonScope();
        }
    }
}

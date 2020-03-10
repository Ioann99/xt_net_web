using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks_1.Common.NinjectConfig
{
    public class Config
    {
        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel
                   .Bind<IAwardLogic>().To(Task_1.BLL.Logic.AwardLogic);
            kernel
                .Bind<IUserLogic>()
                .To<UserLogic>()
                .InSingletonScope();
            kernel
                .Bind<IUserDAL>()
                .To<UserDAL>()
                .InSingletonScope();
            kernel
                .Bind<IAwardDAL>()
                .To<AwardDAL>()
                .InSingletonScope();
            kernel
                .Bind<IUserAwardDAL>()
                .To<UserAwardDAL>()
                .InSingletonScope();
            kernel
                .Bind<IPictureDAL>()
                .To<PictureDAL>()
                .InSingletonScope();
        }
    }
}

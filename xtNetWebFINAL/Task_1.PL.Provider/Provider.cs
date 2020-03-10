using BLL;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL;
using Task_1.Entities;
using Task_1.BLL.Logic;
using Task_1.DAL.Abstract;

namespace Task_1.PL.Providers
{
    public static class Provider
    {
        //static Provider()
        //{
        //    UserDAL UserDAL = new UserDAL();
        //    ImageDAL ImageDAL = new ImageDAL();
        //    AwardDAL AwardDAL = new AwardDAL();

        //    UserLogic = new UserLogic(UserDAL);
        //    ImageLogic = new ImageLogic(ImageDAL);
        //    AwardLogic = new AwardLogic(AwardDAL);

        //}

        public static IAwardDAL AwardDAL { get; private set; }
        public static IAwardLogic AwardLogic { get; private set; }

        public static IUserDAL UserDAL { get; private set; }
        public static IUserLogic UserLogic { get; private set; }

        public static IImageDAL ImageDAL { get; private set; }
        public static IImageLogic ImageLogic { get; private set; }
    }
}

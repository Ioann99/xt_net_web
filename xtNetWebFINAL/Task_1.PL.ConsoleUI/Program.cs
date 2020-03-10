//using DLL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Task_1.Entities;

//namespace Task_1.PL.ConsoleUI
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            UserDAL dal = new UserDAL();
//            UserDTO user = new UserDTO()
//            {
//                Id = Guid.NewGuid(),
//                Name = "pasha",
//                Birthdate = DateTime.Now,
//                Image_id = Guid.NewGuid()
//            };
//            dal.Create(user);
//            Console.WriteLine(user.Id + " " + user.Name + " " + user.Birthdate);

//            UserDTO u = dal.Get(user.Id);
//            Console.WriteLine(u.Id + " " + u.Name);

//            u.Name = u.Name + "_Modifed";
//            u.Birthdate = DateTime.Now;
//            dal.Update(u);
//            Console.WriteLine(u.Id + " " + u.Name + " " + u.Birthdate);

//            dal.Delete(u.Id);
//            u = dal.Get(user.Id);

//            Console.ReadKey();
//        }
//    }
//}

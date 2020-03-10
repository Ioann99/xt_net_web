using BLL;
using DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.DAL.Abstract;
using Task_1.Entities;

namespace Task_1.BLL.Logic
{
    public class UserLogic : IUserLogic
    {
        private IUserDAL userDAL;
        private IRecipieDAL recipieDAL;

        public UserLogic(IUserDAL userDAL, IRecipieDAL recipieDAL)
        {
            this.recipieDAL = recipieDAL;
            this.userDAL = userDAL;
        }

        public int Create(UserDTO user)
        {
            return userDAL.Create(user);
        }

        public bool Delete(int id)
        {
            return userDAL.Delete(id);
        }

        public UserDTO Get(int id)
        {
            return userDAL.Get(id);
        }

        public bool Update(UserDTO user)
        {
            return userDAL.Update(user);
        }

        public List<UserDTO> GetAll()
        {
            return userDAL.GetAll().ToList();
        }

        public List<UserDTO> GetAllByLetter(char letter)
        {
            return userDAL.GetAll()
                .Where(x =>
                x.Name.StartsWith(letter.ToString(), StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public List<UserDTO> GetAllByString(string query)
        {
            return userDAL.GetAll()
                .Where(x =>
                x.Name.EndsWith(query, StringComparison.InvariantCultureIgnoreCase) ||
                x.Name.StartsWith(query, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public bool AddRecipie(int user_id, int recipie_id)
        {
            UserDTO user = userDAL.Get(user_id);
            RecipieDTO recipie = recipieDAL.Get(recipie_id);
            if (user != null && recipie != null && !recipieDAL.GetRecipiesByUserId(user_id).Contains(recipie))
            {
                return userDAL.AddRecipie(user_id, recipie_id);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveRecipie(int user_id, int recipie_id)
        {
            UserDTO user = userDAL.Get(user_id);
            RecipieDTO recipie = recipieDAL.Get(recipie_id);
            if (user != null && recipie != null && recipieDAL.GetRecipiesByUserId(user_id).Find(x => x.Id == recipie.Id) != null)
            {
                return userDAL.RemoveRecipie(user_id, recipie_id);
            }
            else
            {
                return false;
            }
        }
    }
}

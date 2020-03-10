using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.DAL.Abstract;
using Task_1.Entities;

namespace Task_1.BLL.Logic
{
    public class RecipieLogic : IRecipieLogic
    {

        IRecipieDAL recipieDAL;

        public RecipieLogic(IRecipieDAL recipieDAL)
        {
            if (recipieDAL == null)
            {
                throw new ArgumentException("Null pointer in BLL constructir");
            }
            else
            {
                this.recipieDAL = recipieDAL;
            }
        }

        public int Create(RecipieDTO recipie)
        {
            return recipieDAL.Create(recipie);
        }

        public bool Delete(int id)
        {
            return recipieDAL.Delete(id);
        }

        public RecipieDTO Get(int id)
        {
            return recipieDAL.Get(id);
        }

        public List<RecipieDTO> GetAll()
        {
            return recipieDAL.GetAll().ToList();
        }

        public RecipieDTO GetByString(string query)
        {
           return  recipieDAL.GetAll()
                .Where(x => x.Title
                    .Equals(query, StringComparison.InvariantCultureIgnoreCase))
                    .FirstOrDefault();
        }

        public List<RecipieDTO> GetAllByLetter(char letter)
        {
            return recipieDAL.GetAll()
                .Where(x =>
                x.Title.StartsWith(letter.ToString(), StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public List<RecipieDTO> GetAllByString(string query)
        {
            return recipieDAL.GetAll()
                .Where(x =>
                x.Title.IndexOf(query, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
        }

        public List<RecipieDTO> GetAllByUser(int id)
        {
            return recipieDAL.GetRecipiesByUserId(id).ToList();
        }

        public List<RecipieDTO> GetMissingRecipies(int id)
        {
            var existingRecipies = recipieDAL.GetRecipiesByUserId(id);
            var recipies = recipieDAL.GetAll();
            recipies.RemoveAll(x => existingRecipies.Find(y => y.Id == x.Id) != null);
            return recipies;
        }

        public bool Update(RecipieDTO recipie)
        {
            return recipieDAL.Update(recipie);
        }
    }
}

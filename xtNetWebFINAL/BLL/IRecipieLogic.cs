using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Entities;

namespace BLL
{
    public interface IRecipieLogic
    {
        RecipieDTO Get(int id);

        List<RecipieDTO> GetAll();

        bool Update(RecipieDTO recipie);

        bool Delete(int id);

        int Create(RecipieDTO recipie);

        RecipieDTO GetByString(string query);

        List<RecipieDTO> GetAllByUser(int id);

        List<RecipieDTO> GetMissingRecipies(int id);

        List<RecipieDTO> GetAllByLetter(char letter);

        List<RecipieDTO> GetAllByString(string query);
    }
}

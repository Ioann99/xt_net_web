using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Entities;

namespace Task_1.DAL.Abstract
{
    public interface IRecipieDAL
    {
        RecipieDTO Get(int id);

        List<RecipieDTO> GetRecipiesByUserId(int id);

        List<RecipieDTO> GetAll();

        bool Update(RecipieDTO recipie);

        bool Delete(int id);

        int Create(RecipieDTO recipie);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Entities;

namespace BLL
{
    public interface IUserLogic
    {
        UserDTO Get(int id);

        List<UserDTO> GetAll();


        bool Update(UserDTO user);

        bool Delete(int id);

        int Create(UserDTO user);

        List<UserDTO> GetAllByLetter(char letter);

        List<UserDTO> GetAllByString(string query);

        bool AddRecipie(int user_id, int recipie_id);

        bool RemoveRecipie(int user_id, int recipie_id);
    }
}

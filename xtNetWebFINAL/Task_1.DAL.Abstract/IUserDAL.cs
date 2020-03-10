using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.Entities;

namespace Task_1.DAL.Abstract
{
    public interface IUserDAL
    {
        UserDTO Get(int id);

        List<UserDTO> GetAll();

        bool Update(UserDTO user);

        bool Delete(int id);
        int Create(UserDTO user);

        bool AddRecipie(int user_id, int reccipie_id);

        bool RemoveRecipie(int user_id, int recipie_id);
    }
}

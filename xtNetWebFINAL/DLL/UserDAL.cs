using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.DAL.Abstract;
using Task_1.Entities;

namespace DLL
{
    public class UserDAL : IUserDAL
    {
        private SqlDALConfig config;

        public UserDAL(SqlDALConfig config)
        {
            this.config = config;
        }

        public int Create(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Users.Create]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Birthdate", user.Birthdate);
                command.Parameters.AddWithValue("@Image_id", user.Image_id);

                connection.Open();
                int userID = (int)(decimal)command.ExecuteScalar();

                return userID;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Users.DeleteUserById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public UserDTO Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Users.GetUserById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new UserDTO()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Birthdate = (DateTime)reader["Birthdate"],
                        Image_id = (int)reader["Image_id"],
                    };
                }

                return null;
            }
        }

        public List<UserDTO> GetAll()
        {
            return GetAllYield().ToList();
        }


        private IEnumerable<UserDTO> GetAllYield()
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Users.GetAll]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new UserDTO()
                    {
                        Id = (Int32)reader["Id"],
                        Name = (string)reader["Name"],
                        Birthdate = (DateTime)reader["Birthdate"],
                        Image_id = (int)reader["Image_id"],
                    };
                }
            }
        }

        public bool Update(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Users.UpdateUserById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Birthdate", user.Birthdate);
                command.Parameters.AddWithValue("@Image_id", user.Image_id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool AddRecipie(int user_id, int recipie_id)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Users.AddRecipie]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@User_id", user_id);
                command.Parameters.AddWithValue("@Recipie_id", recipie_id);

                connection.Open();

                int rows = command.ExecuteNonQuery();

                if (rows <= 0)
                {
                    return false;
                }

                return rows == 1;
            }
        }

        public bool RemoveRecipie(int user_id, int recipie_id)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Users.RemoveRecipie]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@User_id", user_id);
                command.Parameters.AddWithValue("@Recipie_id", recipie_id);
          
                connection.Open();
                var rowsAffected = (int)(decimal)command.ExecuteNonQuery();

                if (rowsAffected <= 0)
                {
                    return false;
                }
                return rowsAffected == 1;
            }
        }
    }
}

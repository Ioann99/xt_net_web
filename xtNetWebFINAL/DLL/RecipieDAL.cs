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
    public class RecipieDAL : IRecipieDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

        public int Create(RecipieDTO recipie)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("[Recipies.Create]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Title", recipie.Title);
                command.Parameters.AddWithValue("@Description", recipie.Description);
                command.Parameters.AddWithValue("@Image_id", recipie.Image_id);

                connection.Open();
                recipie.Id = (int)(decimal)command.ExecuteScalar();

                return recipie.Id;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("[Recipies.DeleteRecipieById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<RecipieDTO> GetRecipiesByUserId(int id)
        {
            return GetRecipiesByUserIdYield(id).ToList();
        }

        private IEnumerable<RecipieDTO> GetRecipiesByUserIdYield(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                SqlCommand command = new SqlCommand("[Recipies.GetRecipiesByUserId]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return new RecipieDTO()
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        Image_id = (int)reader["Image_id"]
                    };
                }

            }

        }

        public List<RecipieDTO> GetAll()
        {
            return GetAllYield().ToList();
        }

        private IEnumerable<RecipieDTO> GetAllYield()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("[Recipies.GetAll]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new RecipieDTO()
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        Image_id = (int)reader["Image_id"]
                    };
                }
            }
        }

        public bool Update(RecipieDTO recipie)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("[Recipies.UpdateRecipieById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", recipie.Id);
                command.Parameters.AddWithValue("@Title", recipie.Title);
                command.Parameters.AddWithValue("@Description", recipie.Description);
                command.Parameters.AddWithValue("@Image_id", recipie.Image_id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public RecipieDTO Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("[Recipies.GetRecipieById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new RecipieDTO()
                    {
                        Id = (int)reader["Id"],
                        Title = (string)reader["Title"],
                        Description = (string)reader["Description"],
                        Image_id = (int)reader["Image_id"]
                    };
                }

                return null;
            }
        }

        //private IEnumerable<RecipieDTO> GetMissingRecipiesYield(int id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("[Recipies.GetMissingRecipies]", connection);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@Id", id);

        //        connection.Open();
        //        var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            yield return new RecipieDTO()
        //            {
        //                Id = (int)reader["Id"],
        //                Title = (string)reader["Title"],
        //                Description = (string)reader["Description"],
        //                Image_id = (int)reader["Image_id"]
        //            };
        //        }
        //    }
        //}

        //public List<RecipieDTO> GetMissingRecipies(int id)
        //{
        //    using (SqlConnection connection = new SqlConnection(ConnectionString))
        //    {
        //        SqlCommand command = new SqlCommand("[Users_Recipies.GetMissingRecipies]", connection);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@Id", id);

        //        List<RecipieDTO> list = new List<RecipieDTO>();
        //        connection.Open();
        //        var reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            list.Add(new RecipieDTO()
        //            {
        //                Id = (int)reader["Id"],
        //                Title = (string)reader["Title"],
        //                Description = (string)reader["Description"],
        //                Image_id = (int)reader["Image_id"]
        //            });
        //        }
        //        return list;
        //    }
        //}
    }
}

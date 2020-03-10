using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.DAL.Abstract;
using Task_1.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace DLL
{
    public class ImageDAL : IImageDAL
    {

        SqlDALConfig config;

        public ImageDAL(SqlDALConfig config)
        {
            this.config = config;
        }

        public int Create(ImageDTO img)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Images.Create]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Type", img.Type);
                command.Parameters.AddWithValue("@Data", img.Data);

                connection.Open();

                int imageID = (int)(decimal)command.ExecuteScalar();

                return imageID;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Images.DeleteImageById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public ImageDTO Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Images.GetImageById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new ImageDTO()
                    {
                        Id = (int)reader["Id"],
                        Data = (byte[])reader["Data"],
                        Type = (string)reader["Type"]
                    };
                }

                return null;
            }
        }

        public List<ImageDTO> GetAll()
        {
            return GetAllYield().ToList();
        }

        private IEnumerable<ImageDTO> GetAllYield()
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Images.GetAll]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    yield return new ImageDTO()
                    {
                        Id = (int)reader["Id"],
                        Type = (string)reader["Type"],
                        Data = (byte[])reader["Data"]
                    };
                }
            }
        }

        public bool Update(ImageDTO img)
        {
            using (SqlConnection connection = new SqlConnection(config.connectionString))
            {
                SqlCommand command = new SqlCommand("[Images.UpdateImageById]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", img.Id);
                command.Parameters.AddWithValue("@Type", img.Type);
                command.Parameters.AddWithValue("@Data", img.Data);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}

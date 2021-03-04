using MotionPicturesAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPicturesAPI.DAO
{
    public class MotionPictureSQLDAO : IMotionPictureDAO
    {
        private string ConnectionString = "Server=.\\SQLEXPRESS;Database=MotionPictures;Trusted_Connection=True;";

        public int DeleteMotionPicture(int id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int EditMotionPicture(MotionPicture editedMotionPicture)
        {
            int rowsAffected = 0;
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("update MotionPictures set Name = @name, Description = @description, Release_Year = @releaseYear where ID = @id;");
                    command.Parameters.AddWithValue("@name", editedMotionPicture.Name);
                    command.Parameters.AddWithValue("@description", editedMotionPicture.Description);
                    command.Parameters.AddWithValue("@releaseYear", editedMotionPicture.ReleaseYear);
                    command.Parameters.AddWithValue("@id", editedMotionPicture.ID);

                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public List<MotionPicture> GetAllMotionPictures()
        {
            List<MotionPicture> motionPictures = new List<MotionPicture>();

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand("select * from MotionPictures", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        motionPictures.Add(GetMotionPictureFromReader(reader));
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return motionPictures;
        }

        public MotionPicture GetMotionPictureByID(int id)
        {
            MotionPicture motionPicture = new MotionPicture();

            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from MotionPictures where ID = @id",conn);
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        motionPicture = GetMotionPictureFromReader(reader);
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return motionPicture;
        }

        public MotionPicture PostMotionPicture(MotionPicture newPicture)
        {
            try
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("insert into MotionPictures (Name, Description, Release_Year) values (@name, @description, @release_year); select scope_identity();", conn);
                    command.Parameters.AddWithValue("@name", newPicture.Name);
                    command.Parameters.AddWithValue("@description", newPicture.Description);
                    command.Parameters.AddWithValue("@release_year", newPicture.ReleaseYear);
                    newPicture.ID = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return newPicture;
        }

        private MotionPicture GetMotionPictureFromReader(SqlDataReader reader)
        {
            MotionPicture motionPicture = new MotionPicture()
            {
                ID = Convert.ToInt32(reader["ID"]),
                Name = Convert.ToString(reader["Name"]),
                Description = Convert.ToString(reader["Description"]),
                ReleaseYear = Convert.ToInt32(reader["Release_Year"])
            };

            return motionPicture;
        }
    }
}

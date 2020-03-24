using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Gravirozas.Model.Entity;
namespace Gravirozas.Repository
{
    public class AruRepository
    {
        public Aru Create(Aru entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AruCreate";

                command.Parameters.Add(new SqlParameter("@Nev", entity.Nev));
                command.Parameters.Add(new SqlParameter("@Leiras", entity.Leiras));
                command.Parameters.Add(new SqlParameter("@Mennyiseg", entity.Mennyiseg));
                command.Parameters.Add(new SqlParameter("@Ar", entity.Ar));
                command.Parameters.Add(new SqlParameter("@Kep", entity.Kep));

                connection.Open();
                int result = (int)command.ExecuteScalar();
                if (result < 1)
                {
                    throw new Exception("Error in AruCreate stored procedure.");
                }

                entity.Id = (int)result;
                return entity;
            }
        }

        public Aru Update(Aru entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AruUpdate";

                command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                command.Parameters.Add(new SqlParameter("@Nev", entity.Nev));
                command.Parameters.Add(new SqlParameter("@Leiras", entity.Leiras));
                command.Parameters.Add(new SqlParameter("@Mennyiseg", entity.Mennyiseg));
                command.Parameters.Add(new SqlParameter("@Ar", entity.Ar));
                command.Parameters.Add(new SqlParameter("@Kep", entity.Kep));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                if (result < 1)
                {
                    throw new Exception("Error in UpdateAru stored procedure.");
                }

                return entity;
            }
        }

        public int UpdateMennyiseg(int id, int menny)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AruUpdateMennyiseg";

                command.Parameters.Add(new SqlParameter("@Id", id));
                command.Parameters.Add(new SqlParameter("@Mennyiseg", menny));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                if (result < 1)
                {
                    throw new Exception("Error in UpdateAru stored procedure.");
                }

                return result;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AruUpdate";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }

        private Aru Mapentity(SqlDataReader data)
        {
            Aru result = new Aru();

            result.Id = int.Parse(data["Id"].ToString());
            result.Nev = data["Nev"].ToString();
            result.Leiras = data["Leiras"].ToString();
            result.Mennyiseg = int.Parse(data["Mennyiseg"].ToString());
            result.Ar = int.Parse(data["Ar"].ToString());
            result.Kep = data["Kep"].ToString();

            return result;
        }

        public int Elerheto(int id)
        {
            int result = 0;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AruAvailable";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = int.Parse(reader["Mennyiseg"].ToString());
                    }
                }
            }

            return result;
        }
        public Aru GetByID(int id)
        {
            Aru result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AruGetByID";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = Mapentity(reader);
                    }
                }
            }

            return result;
        }
        public List<Aru> GetAll()
        {
            List<Aru> result = new List<Aru>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AruGetAll";

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(Mapentity(reader));
                    }
                }
            }

            return result;
        }

        public Aru GetByName(string nev)
        {
            Aru result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AruGetByName";

                command.Parameters.Add(new SqlParameter("@Nev", nev));

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = Mapentity(reader);
                    }
                }
            }

            return result;
        }

    }
}
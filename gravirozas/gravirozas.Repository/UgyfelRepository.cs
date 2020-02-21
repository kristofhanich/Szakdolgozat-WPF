using Gravirozas.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Gravirozas.Repository
{
    public class UgyfelRepository
    {
        public Ugyfel Create(Ugyfel entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UgyfelCreate";

                command.Parameters.Add(new SqlParameter("@Nev", entity.Nev));
                command.Parameters.Add(new SqlParameter("@Cim", entity.Cim));
                command.Parameters.Add(new SqlParameter("@Telefonszam", entity.Telefonszam));

                connection.Open();
                int result = (int)command.ExecuteScalar();
                if (result < 1)
                {
                    throw new Exception("Error in CreateUgyfel stored procedure.");
                }

                entity.Id = (int)result;
                return entity;
            }
        }



        public Ugyfel Update(Ugyfel entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UgyfelUpdate";

                command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                command.Parameters.Add(new SqlParameter("@Nev", entity.Nev));
                command.Parameters.Add(new SqlParameter("@Cim", entity.Cim));
                command.Parameters.Add(new SqlParameter("@Telefonszam", entity.Telefonszam));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                if (result < 1)
                {
                    throw new Exception("Error in UpdateUgyfel stored procedure.");
                }

                return entity;
            }
        }



        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UgyfelDelete";

                command.Parameters.Add(new SqlParameter("@Id", id));

                connection.Open();
                int result = (int)command.ExecuteNonQuery();
                return result == 1 ? true : false;
            }
        }

        private Ugyfel Mapentity(SqlDataReader data)
        {
            Ugyfel result = new Ugyfel();

            result.Id = int.Parse(data["Id"].ToString());
            result.Nev = data["Nev"].ToString();
            result.Cim = data["Cim"].ToString();
            result.Telefonszam = data["Telefonszam"].ToString();

            return result;
        }



        public Ugyfel GetByID(int id)
        {
            Ugyfel result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UgyfelGetByID";

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


        public List<Ugyfel> GetAll()
        {
            List<Ugyfel> result = new List<Ugyfel>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UgyfelGetAll";

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
    }
}

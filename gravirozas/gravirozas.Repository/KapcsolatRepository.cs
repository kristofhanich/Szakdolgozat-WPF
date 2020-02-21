using Gravirozas.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Gravirozas.Repository
{
    public class KapcsolatRepository
    {

        public Kapcsolat Create(Kapcsolat entity)
        {
            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateKapcsolat";

                command.Parameters.Add(new SqlParameter("@UgyfelID", entity.UgyfelID));
                command.Parameters.Add(new SqlParameter("@AruID", entity.AruID));
                command.Parameters.Add(new SqlParameter("@Darab", entity.Darab));
                command.Parameters.Add(new SqlParameter("@HatarIdo", entity.HatarIdo));
                command.Parameters.Add(new SqlParameter("@TeljesAr", entity.TeljesAr));

                connection.Open();
                int result = (int)command.ExecuteScalar();
                if (result < 1)
                {
                    throw new Exception("Error in CreateKapcsolat stored procedure.");
                }

                entity.ID = (int)result;
                return entity;
            }
        }

        public Kapcsolat GetByID(int id)
        {
            Kapcsolat result = null;

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "KapcsolatByID";

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


        private Kapcsolat Mapentity(SqlDataReader data)
        {
            Kapcsolat result = new Kapcsolat();
            result.ID = int.Parse(data["ID"].ToString());
            result.AruID = int.Parse(data["AruID"].ToString());
            result.UgyfelID = int.Parse(data["UgyfelID"].ToString());
            result.Datum = DateTime.Parse(data["Datum"].ToString());
            result.HatarIdo = DateTime.Parse(data["HatarIdo"].ToString());
            result.Darab = int.Parse(data["Darab"].ToString());
            result.TeljesAr = int.Parse(data["TeljesAr"].ToString());

            return result;
        }
    }
}

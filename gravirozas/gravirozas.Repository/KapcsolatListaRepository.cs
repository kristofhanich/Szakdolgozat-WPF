using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Gravirozas.Model.Entity;

namespace Gravirozas.Repository
{
    public class KapcsolatListaRepository
    {
        public List<KapcsolatLista> GetAll()
        {
            List<KapcsolatLista> result = new List<KapcsolatLista>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "KapcsolatListaGetAll";

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

        private KapcsolatLista Mapentity(SqlDataReader data)
        {
            KapcsolatLista result = new KapcsolatLista();
            result.UgyfelNev = data["UgyfelNev"].ToString();
            result.AruNev = data["AruNev"].ToString();
            result.Datum = DateTime.Parse(data["Datum"].ToString());
            result.HatarIdo = DateTime.Parse(data["HatarIdo"].ToString());
            result.Darab = int.Parse(data["Darab"].ToString());
            result.TeljesAr = int.Parse(data["TeljesAr"].ToString());
            return result;
        }
    }
}

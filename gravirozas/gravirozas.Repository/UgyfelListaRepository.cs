using Gravirozas.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Gravirozas.Repository
{
    public class UgyfelListaRepository
    {
        public List<Ugyfel> GetAll()
        {
            List<Ugyfel> result = new List<Ugyfel>();

            using (SqlConnection connection = new SqlConnection(Connection.String))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UgyfelListaGetAll";

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

        private Ugyfel Mapentity(SqlDataReader data)
        {
            Ugyfel result = new Ugyfel();
            result.Nev = data["Nev"].ToString();
            result.Cim = data["Cim"].ToString();
            result.Telefonszam = data["Telefonszam"].ToString();
            return result;
        }
    }
}

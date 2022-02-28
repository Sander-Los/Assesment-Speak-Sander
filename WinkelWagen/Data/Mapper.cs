using System;
using System.Data.SqlClient;



namespace WinkelWagen
{
    /// <summary>
    /// Klasse die de communicatie met de DB verzorgt.
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Haalt de gevraagde tour uit de database. Gaat er van uit dat het item in de database zit.
        /// </summary>
        /// <param name="code"> Code van de gevraagde tour.</param>
        /// <returns></returns>
        public Tour getTour(string code)
        {
            Tour tour = new Tour();
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.WinkelWagenDBConnectionString);

            string sql = "SELECT * FROM Tours WHERE ID = @TourID ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@TourID";
            param.Value = code;
            cmd.Parameters.Add(param);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            {
                while (reader.Read())
                {
                    tour.ID = ((string)reader["ID"]).Trim();
                    tour.Naam = (string)reader["naam"];
                    tour.Prijs = (Decimal)reader["Prijs"];
                }
                conn.Close();
            }

            return tour;
        }
    }
}

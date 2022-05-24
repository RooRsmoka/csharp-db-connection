using System.Data.SqlClient;

namespace csharp_db_connection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string stringaDiConnesione = "Data Source=desktop-9jghovp;Initial Catalog=biblioteca;Integrated Security=True;Pooling=False";

            using (SqlConnection conn = new SqlConnection(stringaDiConnesione))
            {
                conn.Open();

                using (SqlCommand insert = new SqlCommand
                    (@"insert into Clienti(Id, Nome, Cognome, Codice_cliente) values (1, 'Giovanni', 'Verdi', 656294)", conn))
                {
                    var numRows = insert.ExecuteNonQuery();
                    Console.WriteLine(numRows);
                }

                using (SqlCommand query = new SqlCommand("select * from Clienti", conn))
                {
                    using (SqlDataReader reader = query.ExecuteReader())
                    {
                        Console.WriteLine(reader.FieldCount);
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                                Console.Write("{0}, ", reader[i]);
                            Console.WriteLine(); 
                        }
                    }
                }
            }
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication5
{
    public class dbService
    {
        public static bool CheckIndex(string index)
        {
            Console.WriteLine(index + " my index");
            string strCommand =  "SELECT IndexNumber FROM Student where Student.IndexNumber = @IndexNumber" ;;
            // skorzystalem z eski mojego kolegi bo, niestety, nie moge podlaczyc z mac os do swojej bazy danych
            // (baza kolegi zostala zmieniona przez Pana Profesora Gago i przez to dziala), a u windowsa
            // z ktorego korzystalem juz skonczyla sie licenzja
            string connetionString = connetionString =
                "Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=s18714;User ID=inzs18714;Password=admin";;
            SqlConnection connection = new SqlConnection(connetionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = strCommand;
            command.Parameters.AddWithValue("IndexNumber", index);
            connection.Open();
            Console.WriteLine("connected");
            SqlDataReader reader = command.ExecuteReader();
            bool exists = reader.Read();
            if (exists)
            {
                Console.WriteLine("exists");
                return true;
            }
            return false;
        }
    }
}
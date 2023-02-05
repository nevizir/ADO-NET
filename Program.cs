using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SalesDB;Integrated Security=True;Connect Timeout=2;";

            SqlConnection connection = new SqlConnection(conn);
            
            connection.Open();
            Console.WriteLine("Connected!");


            //Task 1 ------------------------------------------------------------------
            /*Console.WriteLine("Enter name ::");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname ::");
            string surname = Console.ReadLine();
            */
            //string cmdText = @"insert into Buyers (Name, Surname) " + $"values ({name}, {surname})";

            //SqlCommand command = new SqlCommand(cmdText, connection);
            //command.CommandTimeout = 5; // default - 30sec

            //// ExecuteNonQuery - виконує команду яка не повертає результат (insert, update, delete...),
            ////                   але метод повертає кількітсь рядків, які були задіяні
            //int rows = command.ExecuteNonQuery();

            // Console.WriteLine(rows + " rows affected!");


            #region Task 2
            /*
            //Task 2 ------------------------------------------------------------------
            Console.WriteLine("Enter year ::");
            int year = Int32.Parse(Console.ReadLine());
            string cmdText = @"select * from Sales " + $" where YEAR(DateOFSell) > {year} AND YEAR(DateOFSell) < 2022";

            SqlCommand command = new SqlCommand(cmdText, connection);

            // ExecuteReader - виконує команду select та повертає результат у вигляді DbDataReader
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read()!)
            {
                Console.WriteLine(
                    $"{reader["BuyersId"]}\t" +
                    $"{reader["SellersId"]}\t" +
                    $"{reader["Bil"]}$\t" +
                    $"{reader["DateOFSell"]}");
            }
            */
            #endregion

            #region Task 3
            /*
            string cmdText = @"select * from Sales as s JOIN Buyers as b on s.BuyersId = b.Id" + $" where b.Name = 'Marcello' AND b.Surname = 'Gersam'";

            SqlCommand command = new SqlCommand(cmdText, connection);

            // ExecuteReader - виконує команду select та повертає результат у вигляді DbDataReader
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()!)
            {
                Console.WriteLine(
                    $"{reader["BuyersId"]}\t" +
                    $"{reader["SellersId"]}\t" +
                    $"{reader["Bil"]}$\t" +
                    $"{reader["DateOFSell"]}");
            }
            */
            #endregion

            #region Task 4
            /*
            Console.WriteLine("Enter id What you want delete");
            int id = Int32.Parse(Console.ReadLine());
            string cmdText = @"delete Sales " + "from Sales as s inner join Buyers as b on s.BuyersId = b.Id " + $"where b.Id = {id}; ";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5; // default - 30sec
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
            */
            #endregion

            #region Task 5
            
            var cmdText = @"select top 1 Sellers.Name,Sellers.Surname, Sales.Bil" + $"From Sales Join Sellers on Sales.SellersId = Sellers.Id" + $"order by Bil desc;";

            SqlCommand command = new SqlCommand(cmdText, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()!)
            {
                Console.WriteLine(
                    $"{reader["Name"]}\t" +
                    $"{reader["Surname"]}\t" +
                    $"{reader["Bil"]}$\t");     
            }
            #endregion

            connection.Close();
            Console.WriteLine("Disconnected!");
        }
    }
}
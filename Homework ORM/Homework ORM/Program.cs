using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Net;
using System.Numerics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Homework_ORM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseManager dbManager = new DatabaseManager();

            // Създаване на базата данни
            dbManager.CreateDatabase();

            // Създаване на таблицата 
            dbManager.CreateTable();
            dbManager.CreateTable2();
            dbManager.Orders();

            //добавям данни в таблицата client
            dbManager.AddInfoClient(1, "Иван Петров", "ivan.petrov@gmail.com", "0888123456", "София");
            dbManager.AddInfoClient(2, "Ивелин Иванов", "ivelin.ivanov21@gmail.com", "0884356387", "Велико Търново");
            dbManager.AddInfoClient(3, "Стоян Георгиев", "stoqn_georgiev0@gmail.com", "0893519401", "София");

            //добавям данни в таблицата products
            dbManager.AddProducts(1, "keybord", 87.99);
            dbManager.AddProducts(2, "mouse", 23.50);
            dbManager.AddProducts(3, "mousepad", 10.20);
            dbManager.AddProducts(4, "computer", 859.99);
            dbManager.AddProducts(5, "monitor", 254.50);


            //добавям поръчки
            dbManager.AddOrders(1, 1); 
            dbManager.AddOrders(1, 2); 
            dbManager.AddOrders(1, 3);
            dbManager.AddOrders(1, 5);
            dbManager.AddOrders(2, 5);
            dbManager.AddOrders(2, 3); 
            dbManager.AddOrders(3, 4); 
            dbManager.AddOrders(1, 4);
            dbManager.AddOrders(2, 4);         
            dbManager.AddOrders(3, 5); 


            dbManager.GetProductBuyersCount();


        }
    }
    public class DatabaseManager
    {
        string  connectionString = "Server=DESKTOP-RJC6MC1;Database=C#;Trusted_Connection=True;TrustServerCertificate=true;";


        public void CreateDatabase()
        {
            string query = "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'C#')CREATE DATABASE C#";
            ExecuteQuery(query);
        }

        public void CreateTable()
        {
            string query = @"
            USE [C#]; 
           
            CREATE TABLE products (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                Name VARCHAR(30) NOT NULL,
                Price DECIMAL(10,2) NOT NULL
            );";
            ExecuteQuery(query);
        }

        public void CreateTable2()
        {
            string query= @"
            USE[C#]; 
          
            CREATE TABLE client(
                Id INT IDENTITY(1, 1) PRIMARY KEY,
                ClientName VARCHAR(30) NOT NULL,
                Email VARCHAR(100) UNIQUE,
                Phone VARCHAR(20),
                Address	VARCHAR(255),
                
            ); ";
            ExecuteQuery(query);
        }
        

        public void AddProducts(int id, string name, double price)
        {
            string query = $@"
    INSERT INTO products (Name, Price)
    VALUES ('{name}', '{price}');";
            
            ExecuteQuery(query);
        }


        public void AddInfoClient(int id, string name, string email, string phone, string address)
        {
            string query = $@"
    INSERT INTO client (ClientName, Email, Phone, Address)
    VALUES ('{name}', '{email}', '{phone}', '{address}');";

            ExecuteQuery(query);
        }

        public void Orders()
        {
            string query = @"
    CREATE TABLE Orders (
        OrderId INT IDENTITY(1,1) PRIMARY KEY,
        ClientId INT NOT NULL,
        ProductId INT NOT NULL,
        FOREIGN KEY (ClientId) REFERENCES Client(Id),
        FOREIGN KEY (ProductId) REFERENCES Products(Id)
    );";

            ExecuteQuery(query);
        }


        public void AddOrders(int clientId, int productId)
        {
            string query = $@"
        INSERT INTO Orders (ClientId, ProductId)
        VALUES ({clientId}, {productId});";

            ExecuteQuery(query);
        }



        public void GetProductBuyersCount()
        {
            string query = @"
    SELECT p.Name AS ProductName, COUNT(DISTINCT o.ClientId) AS BuyerCount
    FROM Orders o
    JOIN Products p ON o.ProductId = p.Id
    GROUP BY p.Name
    ORDER BY BuyerCount DESC;";

            using (SqlConnection C = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, C);
                C.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("Продукт / Брой купувачи");
                

                while (reader.Read())
                {
                    string productName = reader["ProductName"].ToString();
                    int buyerCount = Convert.ToInt32(reader["BuyerCount"]);

                    Console.WriteLine($"{productName} / {buyerCount}");
                }

                reader.Close();
            }
        }


        private void ExecuteQuery(string query)
        {
            using (SqlConnection C = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, C);
                C.Open();
                cmd.ExecuteNonQuery();
               // Console.WriteLine("Готово");
            }
        }
    }



}



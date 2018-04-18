using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.Common;

namespace Hw_ADO.NET
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var conn = ConfigurationManager.ConnectionStrings["Test"];
            //string connectionString = conn.ConnectionString;

            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
                
            //    SqlCommand createTableShoppersCommand = new SqlCommand
            //        ("" +
            //        "create table Shoppers" +
            //        "(" +
            //        "id_shopper int not null primary key," +
            //        "first_name_shopper varchar(200) not null," +
            //        "second_name_shopper varchar(200) not null," +
            //        ")");
            //    createTableShoppersCommand.Connection = connection;

            //    createTableShoppersCommand.ExecuteNonQuery();

            //    SqlCommand createTableSellersCommand = new SqlCommand
            //        ("" +
            //        "create table Sellers" +
            //        "(" +
            //        "id_seller int not null primary key," +
            //        "first_name_seller varchar(200) not null," +
            //        "second_name_seller varchar(200) not null," +
            //        ")");
            //    createTableSellersCommand.Connection = connection;

            //    createTableSellersCommand.ExecuteNonQuery();

            //    SqlCommand createTableOrdersCommand = new SqlCommand
            //        ("" +
            //        "create table Orders" +
            //        "(" +
            //        "id_order int not null primary key," +
            //        "id_shoppper int not null foreign key references Shoppers(id_shopper)," +
            //        "id_seller int not null foreign key references Sellers(id_seller)," +
            //        "price int not null," +
            //        "dateTransaction datetime not null" +
            //        ")");
            //    createTableOrdersCommand.Connection = connection;

            //    createTableOrdersCommand.ExecuteNonQuery();
            }
        private void Shoppers_Click(object sender, RoutedEventArgs e)
        {
            List<Shopper> shoppers = new List<Shopper>();
            var conn = ConfigurationManager.ConnectionStrings["Test"];
            string connectionString = conn.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Shoppers");
                command.Connection = connection;
                var reader = command.ExecuteReader();
                while(reader.Read())
                {
                    shoppers.Add(Parse(reader));
                }
                grid.ItemsSource = shoppers;
            }

            Shopper Parse(DbDataReader reader)
            {
                return new Shopper
                {
                    Id = Convert.ToInt32(reader["id_shopper"]),
                    FirstName = Convert.ToString(reader["first_name_shopper"]),
                    SecondName = Convert.ToString(reader["second_name_shopper"])
                };
            }
        }

        private void Salers_Click(object sender, RoutedEventArgs e)
        {
            List<Seller> sellers = new List<Seller>();
            var conn = ConfigurationManager.ConnectionStrings["Test"];
            string connectionString = conn.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Sellers");
                command.Connection = connection;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sellers.Add(Parse(reader));
                }
                grid.ItemsSource = sellers;
            }

            Seller Parse(DbDataReader reader)
            {
                return new Seller
                {
                    Id = Convert.ToInt32(reader["id_shopper"]),
                    FirstName = Convert.ToString(reader["first_name_shopper"]),
                    SecondName = Convert.ToString(reader["second_name_shopper"])
                };
            }
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            List<Order> orders = new List<Order>();
            var conn = ConfigurationManager.ConnectionStrings["Test"];
            string connectionString = conn.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Orders");
                command.Connection = connection;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(Parse(reader));
                }
                grid.ItemsSource = orders;
            }

            Order Parse(DbDataReader reader)
            {
                return new Order
                {
                    Id = Convert.ToInt32(reader["id_order"]),
                    SellerId = Convert.ToInt32(reader["id_seller"]),
                    ShopperId = Convert.ToInt32(reader["id_shopper"]),
                    Price = Convert.ToInt32(reader["price"]),
                    DateTransaction = Convert.ToDateTime(reader["SellingDate"])
                };
            }
        }
    }
}

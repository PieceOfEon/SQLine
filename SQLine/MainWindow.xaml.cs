using System;
using System.Collections.Generic;
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
using Microsoft.Data.Sqlite;

namespace SQLine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private double a;
        string connectionString = "Data Source = userdata.db";
        public MainWindow()
        {
            

            InitializeComponent();
            //aaaa
            //using (var connection = new SqliteConnection("Data Source = userdata.db"))
            //{
            //    connection.Open();

            //    SqliteCommand command = new SqliteCommand(connectionString);
            //    command.Connection = connection;


            //    //Cоздание Таблицы
            //    //command.CommandText = "CREATE TABLE Product(_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL, Price INTEGER NOT NULL, Count INTEGER NOT NULL)";
            //    //command.CommandText = "DROP TABLE Userrs";

            //    //int number = command.ExecuteNonQuery();

            //    //Console.WriteLine("Taблиа создана");
         
            //Console.Read();


        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if(NameProduct.Text!="" && CountProduct.Text!="" && PriceProduct.Text!="" )
            {
                using (var connection = new SqliteConnection("Data Source = userdata.db"))
                {
                    connection.Open();

                    SqliteCommand command = new SqliteCommand(connectionString);
                    command.Connection = connection;
                    //"+NameProduct+" ,"+PriceProduct+", "+CountProduct+"
                    //Доабвление значений
                    command.CommandText = "INSERT INTO Product(Name,Price, Count) VALUES('" + NameProduct.Text + "' ," + PriceProduct.Text + ", " + CountProduct.Text + ")";
                    //int number = command.ExecuteNonQuery();
                    a += Convert.ToDouble(PriceProduct.Text) * Convert.ToDouble(CountProduct.Text);
                    TotalPrice.Text = a.ToString();
                    //Console.WriteLine("Taблиа создана");
                    int number = command.ExecuteNonQuery();
                    MessageBox.Show($"В таблицу Product добавлено объектов:{number}");
                    //Console.WriteLine($"В таблицу Userrs добавлено объектов:{number}");
                    //Console.WriteLine($"Обновленно объектов: {number}");
                }
                //Console.Read();
            }


        }
    }
}

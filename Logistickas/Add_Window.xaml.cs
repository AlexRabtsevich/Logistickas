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
using System.Windows.Shapes;
using System.Data;
using System.Data.SQLite;

namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для Add_Window.xaml
    /// </summary>
    public partial class Add_Window : Window
    {
        public Add_Window()
        {
            InitializeComponent();
        }

        private async void Add_Button_DB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string conStr = "Data Source=Bd\\Base.db; Version=3";

                if (TextBox_Name.Text != null && TextBox_Price.Text != "" && TextBox_Quantity.Text != "")
                {
                    using (SQLiteConnection sQLite = new SQLiteConnection(conStr))
                    {
                        sQLite.Open();
                        SQLiteCommand command = sQLite.CreateCommand();

                        command.CommandText = "INSERT INTO MAIN(Название_товара, Количество_товара, Цена_товара_за_одну_еденицу) values(@name, @quantity, @price)";

                        command.Parameters.Add("@name", System.Data.DbType.String).Value = TextBox_Name.Text.ToUpper();
                        command.Parameters.Add("@quantity", System.Data.DbType.Int32).Value = TextBox_Quantity.Text;
                        command.Parameters.Add("@price", System.Data.DbType.Double).Value = TextBox_Price.Text.Replace(".", ",");

                        await command.ExecuteNonQueryAsync();

                        MessageBox.Show("Запись добавленна успешно", "Успех", MessageBoxButton.OK);

                        TextBox_Name.Text = string.Empty;
                        TextBox_Quantity.Text = string.Empty;
                        TextBox_Price.Text = string.Empty;

                    }
                }
                else
                    MessageBox.Show("Поля не должны быть пустыми", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Cansel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
} 

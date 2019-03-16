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
    /// Логика взаимодействия для Update_To_BD.xaml
    /// </summary>
    public partial class Update_To_BD : Window
    {
        private string name;
        private string price;
        private int quantity;

        public Update_To_BD()
        {
            InitializeComponent();
            Button_Add.Background = Brushes.LightGray;
            Button_Reduce.Background = Brushes.LightGray;
            Button_Update.Background = Brushes.LightSeaGreen;
            Button_New_Add.Background = Brushes.LightGray;
            Button_Cancel.Background = Brushes.LightSeaGreen;

            TextBox_ID_Update.IsReadOnly = true;
           TextBox_Add_Update.IsReadOnly = true;            

            TextBox_ID_Update.TextAlignment = TextAlignment.Center;
            TextBox_Name_Update.TextAlignment = TextAlignment.Center;
            TextBox_Price_Update.TextAlignment = TextAlignment.Center;
            TextBox_Add_Update.TextAlignment = TextAlignment.Center;
            
        }
       


        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Button_Add.Background = Brushes.LightSeaGreen;
            Button_Reduce.Background = Brushes.LightGray;
            Button_New_Add.Background = Brushes.LightGray;
            
            TextBox_Add_Update.IsReadOnly = false;
            TextBox_Add_Update.Text = string.Empty;
            
        }

        private void Button_Reduce_Click(object sender, RoutedEventArgs e)
        {
            Button_Reduce.Background = Brushes.LightSeaGreen;
            Button_New_Add.Background = Brushes.LightGray;
            Button_Add.Background = Brushes.LightGray;



        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_New_Add_Click(object sender, RoutedEventArgs e)
        {
            Button_Reduce.Background = Brushes.LightGray;
            Button_New_Add.Background = Brushes.LightSeaGreen;
            Button_Add.Background = Brushes.LightGray;
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (TextBox_Name_Update.Text != "" && TextBox_Price_Update.Text != "" && TextBox_Add_Update.Text != "")
                {


                    using (SQLiteConnection DB = new SQLiteConnection("Data Source=Bd\\Base.db; Version=3"))
                    {
                        
                        if (Button_Add.Background== Brushes.LightSeaGreen)
                        {
                            quantity += Convert.ToInt32(TextBox_Add_Update.Text);
                        }
                        DB.Open();
                        SQLiteCommand command = DB.CreateCommand();
                        command.CommandText = "UPDATE MAIN SET Название_товара =@NAME , Количество_товара =@QUANTITY, Цена_товара_за_одну_еденицу =@PRICE WHERE Код_товара = @ID";
                        command.Parameters.Add("@ID", System.Data.DbType.Int64).Value = TextBox_ID_Update.Text;
                        command.Parameters.Add("@NAME", System.Data.DbType.String).Value = TextBox_Name_Update.Text;
                        command.Parameters.Add("@QUANTITY", System.Data.DbType.Int32).Value =quantity;
                        command.Parameters.Add("@PRICE", System.Data.DbType.Double).Value =Convert.ToDouble( TextBox_Price_Update.Text);

                        command.ExecuteScalar();
                        MessageBox.Show("OK");
                    }

                }
                else
                {
                    MessageBox.Show("Поля не могут быть пустыми", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            quantity =Convert.ToInt32( TextBox_Add_Update.Text);
        }
    }
}

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
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using System.Drawing;

namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для DataBasePage.xaml
    /// </summary>
    public partial class DataBasePage : UserControl
    {
        private SQLiteConnection DB;
        private readonly string cnStr = "Data Source=Bd\\Base.db; Version=3";
        private string commanStr = string.Empty;
        SQLiteDataAdapter adapter;
        DataSet table;
        private Int64 number_ID_Data;
        

        public DataBasePage()
        {
            InitializeComponent();
            InitializeDataGrids();           

        }

        private void InitializeDataGrids()
        {
            DataGrids.Font = new Font("Times", 18);
            DataGrids.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            DataGrids.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            DataGrids.ColumnHeadersHeight = 38;
            DataGrids.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DataGrids.AllowUserToAddRows = false;
        }

        private async void OpenBD()
        {
            try
            {
                using (DB = new SQLiteConnection(cnStr))
                {
                    await DB.OpenAsync();

                    commanStr = "SELECT * FROM MAIN";

                    SQLiteCommand command = new SQLiteCommand(commanStr, DB);

                    adapter = new SQLiteDataAdapter(command);

                    table = new DataSet();
                    adapter.Fill(table);

                    DataGrids.DataSource = table.Tables[0];
                    DataGrids.Columns[0].ReadOnly = true;
                    DataGrids.Columns[1].ReadOnly = true;
                    DataGrids.Columns[2].ReadOnly = true;
                    DataGrids.Columns[3].ReadOnly = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        

        private  void OpenBd_Button_Click(object sender, RoutedEventArgs e)
        {
             OpenBD();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {

            Add_Window window = new Add_Window();
            window.ShowDialog();

        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                number_ID_Data = (Int64)DataGrids.CurrentRow.Cells[0].Value;

                MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить запись", "Удаление записи", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {

                    using (DB = new SQLiteConnection(cnStr))
                    {
                        DB.OpenAsync();
                        SQLiteCommand command = DB.CreateCommand();

                        command.CommandText = "DELETE FROM MAIN WHERE Код_товара =@ID";

                        command.Parameters.Add("@ID", System.Data.DbType.Int64).Value = number_ID_Data;

                        command.ExecuteNonQuery();

                        MessageBox.Show("Запись удалена успешно","Удаление",MessageBoxButton.OK);

                        OpenBD();

                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        
        private void Button_Find_BD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Find_To_BD find_To_BD = new Find_To_BD();
                find_To_BD.ShowDialog();

                using (DB = new SQLiteConnection(cnStr))
                {
                    DB.OpenAsync();
                    if (find_To_BD.ID)
                    {
                        commanStr = "SELECT* FROM MAIN WHERE Код_товара LIKE  '%' || @ID || '%' ";
                    }
                    else
                    {
                        commanStr = "SELECT* FROM MAIN WHERE Название_товара LIKE  '%' || @NAME || '%' ";

                    }

                    if (find_To_BD.TextBox_Find.Text != "")
                    {
                        SQLiteCommand command = new SQLiteCommand(commanStr, DB);

                        command.Parameters.Add("@ID", System.Data.DbType.Int32).Value = find_To_BD.TextBox_Find.Text;
                        command.Parameters.Add("NAME", System.Data.DbType.String).Value = find_To_BD.TextBox_Find.Text.ToUpper();

                        command.ExecuteScalar();
                        adapter = new SQLiteDataAdapter(command);

                        table = new DataSet();
                        adapter.Fill(table);

                        DataGrids.DataSource = table.Tables[0];
                        DataGrids.Columns[0].ReadOnly = true;
                        DataGrids.Columns[1].ReadOnly = true;
                        DataGrids.Columns[2].ReadOnly = true;
                        DataGrids.Columns[3].ReadOnly = true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DB = new SQLiteConnection(cnStr))
                {

                    Update_To_BD update_To = new Update_To_BD();

                    commanStr = "SELECT * FROM MAIN";

                    SQLiteCommand command = new SQLiteCommand(commanStr, DB);

                    adapter = new SQLiteDataAdapter(command);

                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataTable.TableName = "MAIN";

                    DataView view = new DataView(dataTable, "", "Код_товара", DataViewRowState.CurrentRows);

                    number_ID_Data =view.Find( (long)DataGrids.CurrentRow.Cells[0].Value);

                    if (number_ID_Data != -1)
                    {
                        DataRow row = dataTable.Rows[(int)number_ID_Data];

                        update_To.TextBox_ID_Update.Text = row["Код_товара"].ToString();
                        update_To.TextBox_Name_Update.Text = row["Название_товара"].ToString();
                        update_To.TextBox_Add_Update.Text = row["Количество_товара"].ToString();
                        update_To.TextBox_Price_Update.Text = row["Цена_товара_за_одну_еденицу"].ToString();

                    }

                    update_To.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            OpenBD();
        }
    }
}

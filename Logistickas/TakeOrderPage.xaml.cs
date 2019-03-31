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
using System.Data.SQLite;
using System.Data;
using System.Collections;
using System.Collections.ObjectModel;

namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для TakeOrderPage.xaml
    /// </summary>
    public partial class TakeOrderPage : UserControl
    {
        private SQLiteConnection DB;

        private readonly string cnStr = "Data Source=Bd\\Base.db; Version=3";

        private string commanStr = string.Empty;

        ObservableCollection<Bd> CollectionBaseData = new ObservableCollection<Bd>();

        public static ObservableCollection<Bd> TakeDataBase=null; 

        public static int countShop=0;

        private int takequantity;

        private int quantity;

        public static StringBuilder builder = new StringBuilder();


        Bd bd;


        public TakeOrderPage()
        {
            InitializeComponent();
            TakeDataBase = new ObservableCollection<Bd>();

            TextDriver.Text += string.Format(" {0}, {1} , {2}", Make_Deal_Page.driverTake.Name, Make_Deal_Page.driverTake.SecondName,
                                    Make_Deal_Page.driverTake.LastName);

            TextPlaceHere.Text += string.Format("{0}, г. {1}, ул. {2}, д. {3}", TakePlacePage.Place.NamePlace, 
                                    TakePlacePage.Place.City, TakePlacePage.Place.Street, TakePlacePage.Place.House);
            TextQuantityPlace.Text += " "+countShop.ToString();
        }
        private async void OpenBD()
        {
            try
            {
                using(DB=  new SQLiteConnection(cnStr))
                {

                    await  DB.OpenAsync();

                    commanStr = "SELECT * FROM MAIN";

                    SQLiteCommand command = new SQLiteCommand(commanStr, DB);

                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        CollectionBaseData.Add(new Bd(Convert.ToInt64(reader.GetValue(0)), reader.GetValue(1).ToString(),Convert.ToInt32( reader.GetValue(2)),Convert.ToDouble( reader.GetValue(3))));

                    }
                    ListOrderData.ItemsSource = CollectionBaseData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void BuutonOrderBack_Click(object sender, RoutedEventArgs e)
        {
            GridOrder.Children.Clear();
            GridOrder.Children.Add(new TakePlacePage());
        }

        private async void ButtonOrderNext_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                quantity = bd.quantity - takequantity;

                countShop++;

                using (DB = new SQLiteConnection(cnStr))
                {
                    await DB.OpenAsync();

                    SQLiteCommand command = DB.CreateCommand();

                    foreach (Bd item in TakeDataBase)
                    {
                        command.CommandText = "UPDATE MAIN SET Количество_товара=Количество_товара-@quant WHERE Код_товара = @ID";

                        command.Parameters.Add("@ID", System.Data.DbType.Int64).Value = item.id;

                        command.Parameters.Add("@quant", System.Data.DbType.Int32).Value = item.quantity;

                        await command.ExecuteScalarAsync();

                    }
                    
                    GridOrder.Children.Clear();
                    GridOrder.Children.Add(new TakeFinishPage());
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void GridOrder_Loaded(object sender, RoutedEventArgs e)
        {
            OpenBD();
            ListShowTake.ItemsSource = TakeDataBase;

            ButtonOrderNext.IsEnabled = false;
        }

        private void ButtonShowListTake_Click(object sender, RoutedEventArgs e)
        {
            if (GridShowTake.Height == 30)
            {
                GridShowTake.Height = 250;
                GridOrderTouch.Height = 180;
                ListShowTake.Height = 250;
                ButtonShowListTake.Content = "v";
            }
            else if (GridShowTake.Height == 250)
            {
                GridShowTake.Height = 30;
                GridOrderTouch.Height = 400;
                ListShowTake.Height = 100;
                ButtonShowListTake.Content = "^";

            }
        }

        private void  ListOrderData_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                takequantity = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Введите количество товара", "Добавление товара к заказу"));

                bd = (Bd)ListOrderData.SelectedItems[0];

                int idex = ListOrderData.SelectedIndex;

                if (takequantity <= bd.quantity && takequantity > 0)
                {
                    TakeDataBase.Add(new Bd(bd.id, bd.name, takequantity, (takequantity * bd.price)));

                    CollectionBaseData[idex]=(new Bd(bd.id,bd.name,bd.quantity-takequantity,bd.price));

                    if (TakeDataBase.Count > 0)
                    {
                        ButtonOrderNext.IsEnabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Введенное количество товара не может быть больше текущего количества","Повторите попытку",MessageBoxButton.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

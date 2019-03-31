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
using System.IO;

namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для TakeFinishPage.xaml
    /// </summary>
    public partial class TakeFinishPage : UserControl
    {
        private string stringOrderWay = string.Empty;
        private string catalog = @"OurOrders\";
        public TakeFinishPage()
        {
            InitializeComponent();
        }

        private void ButtonFinishEnd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream stream = new FileStream(stringOrderWay, FileMode.CreateNew))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(TakeOrderPage.builder);
                        MessageBox.Show("Заказ завершен успешно", "Успех", MessageBoxButton.OK);
                        TakeOrderPage.builder.Clear();
                        TakePlacePage.Place = null;
                        TakeOrderPage.countShop = 0;
                        Make_Deal_Page.driverTake = null;
                    }
                }
                GridFinish.Children.Clear();
                GridFinish.Children.Add(new Make_Deal_Page());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ButtonFinishNewOrder_Click(object sender, RoutedEventArgs e)
        {
            GridFinish.Children.Clear();
            GridFinish.Children.Add(new TakePlacePage());
        }

        private void GridFinish_Loaded(object sender, RoutedEventArgs e)
        {
            stringOrderWay = string.Format(@"{0}{1}{2}.txt", catalog, Make_Deal_Page.driverTake.LastName, DateTime.Now.ToString().Replace(".", string.Empty).Replace(":", "-"));


            if (TakeOrderPage.countShop <= 1)
            {
                TakeOrderPage.builder.AppendLine(String.Format("Водитель: {0}, {1}, {2} моб.тел: {3}", Make_Deal_Page.driverTake.Name,
                    Make_Deal_Page.driverTake.LastName, Make_Deal_Page.driverTake.SecondName, Make_Deal_Page.driverTake.NumberPhone));

                TakeOrderPage.builder.AppendLine(string.Format("Название машины {0} номер машины {1}", Make_Deal_Page.driverTake.Car,
                    Make_Deal_Page.driverTake.NumberCar));
            }
            TakeOrderPage.builder.AppendLine(new string('_', 73));

            TakeOrderPage.builder.AppendLine(string.Format("Пункт разгрузки: {0}.", TakeOrderPage.countShop));

            TakeOrderPage.builder.AppendLine(string.Format("Название: {0}. Адрес г. {1} ул. {2} номер ул. {3} ", 
               TakePlacePage.Place.NamePlace, TakePlacePage.Place.City, TakePlacePage.Place.Street, TakePlacePage.Place.House));

            TakeOrderPage.builder.AppendLine(new string('_', 73));

            double price = 0;

            foreach (Bd item in TakeOrderPage.TakeDataBase)
            {
                TakeOrderPage.builder.AppendLine(string.Format("Код: {0} Название: {1} Количество: {2} Цена: {3}", item.id, item.name, item.quantity, item.price));
                price += item.price;
            }
            TakeOrderPage.builder.AppendLine(new string('_', 146));

            TakeOrderPage.builder.AppendLine(string.Format("Общая цена за товары: {0}", price));
            TextBlockFinish.Text= (TakeOrderPage.builder.ToString());
        }

        private void ButtonShowWayGrid_Click(object sender, RoutedEventArgs e)
        {
            stringOrderWay = string.Format(@"{0}{1}{2}.txt", catalog, Make_Deal_Page.driverTake.LastName, DateTime.Now.ToString().Replace(".", string.Empty).Replace(":", "-"));


            TextBoxCatalog.Text = "...\\OurOrders\\";
            TextBoxWay.Text = string.Format("{0}{1}", Make_Deal_Page.driverTake.LastName, DateTime.Now.ToString().Replace(".", string.Empty).Replace(":", "-"));

            if (GridShowFinish.Height==30)
            {
                GridShowFinish.Height = 225;
                GridTextBlock.Height = 280;
                ButtonShowWayGrid.Content = "v";
            }
            else if (GridShowFinish.Height==225)
            {

                GridShowFinish.Height = 30;
                GridTextBlock.Height = 480;
                ButtonShowWayGrid.Content = "^";

            }
        }

        private void ButtonFindCatalog_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    catalog = dialog.SelectedPath + @"\";
                }
                TextBoxCatalog.Text = dialog.SelectedPath;

                stringOrderWay = string.Format(@"{0}{1}{2}.txt", catalog, Make_Deal_Page.driverTake.LastName, DateTime.Now.ToString().Replace(".", string.Empty).Replace(":", "-"));


                stringOrderWay = string.Format(@"{0}{1}.txt", catalog,TextBoxWay.Text );

            }
        }
    }
}

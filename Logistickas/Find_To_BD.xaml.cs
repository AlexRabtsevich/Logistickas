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
    /// Логика взаимодействия для Find_To_BD.xaml
    /// </summary>
    public partial class Find_To_BD : Window
    {
       
        private bool ID = false;

        public Find_To_BD()
        {
            InitializeComponent();
            TextBox_Find.Visibility = Visibility.Hidden;
            Button_Find_ID.Background = Brushes.LightGray;
            Button_Find_Name.Background = Brushes.LightGray;
            Button_Find_OK.Background = Brushes.LightSeaGreen;
            Button_Find_OK.IsEnabled = false;

        }

        private void Button_Find_ID_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_Find.Text = "Введите код товара";
            Button_Find_ID.Background = Brushes.LightSeaGreen;
            Button_Find_Name.Background = Brushes.LightGray;
            TextBox_Find.Visibility = Visibility.Visible;
            ID = true;
        }

        private void Button_Find_Name_Click(object sender, RoutedEventArgs e)
        {
            TextBlock_Find.Text = "Введите название товара";
            Button_Find_Name.Background = Brushes.LightSeaGreen;
            Button_Find_ID.Background = Brushes.LightGray;
            TextBox_Find.Visibility = Visibility.Visible;
            ID = false;
        }
        public int number;

        private void Button_Find_OK_Click(object sender, RoutedEventArgs e)
        {

            if (TextBox_Find.Text != "")
            {
                Button_Find_OK.IsEnabled = true;
            }
            this.Close();
        }

        private void TextBox_Find_TextChanged(object sender, TextChangedEventArgs e)
        {
            Button_Find_OK.IsEnabled = true;
        }
    }
}

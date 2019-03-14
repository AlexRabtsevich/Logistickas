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

namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для Update_To_BD.xaml
    /// </summary>
    public partial class Update_To_BD : Window
    {
        public Update_To_BD()
        {
            InitializeComponent();
            Button_Add.Background = Brushes.LightGray;
            Button_Reduce.Background = Brushes.LightGray;
            Button_Update.Background = Brushes.LightSeaGreen;
            Button_New_Add.Background = Brushes.LightGray;
            Button_Cancel.Background = Brushes.LightSeaGreen;

        }



        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            Button_Add.Background = Brushes.LightSeaGreen;
            Button_Reduce.Background = Brushes.LightGray;
            Button_New_Add.Background = Brushes.LightGray;
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
    }
}

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

namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для Make_Deal_Page.xaml
    /// </summary>
    public partial class Make_Deal_Page : UserControl
    {
        public static Driver driverTake;
        public Make_Deal_Page()
        {
                InitializeComponent();
                Button_Next.Background = Brushes.MediumSeaGreen;
                
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            GridMake.Children.Clear();
            GridMake.Children.Add(new Take_Driver_Page());
        }

    }
}

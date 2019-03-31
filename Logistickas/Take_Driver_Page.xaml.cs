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
    /// Логика взаимодействия для Take_Driver_Page.xaml
    /// </summary>
    public partial class Take_Driver_Page : UserControl
    {
        Driver_Pages driv;
        Make_Deal_Page Make_Deal_Page;
        public Take_Driver_Page()
        {
            InitializeComponent();

            driv = new Driver_Pages();

            TakeListDriver.ItemsSource = driv.drivers;
            Make_Deal_Page = new Make_Deal_Page();

            ButtonTakeDriverNext.IsEnabled = false;
        }

        private void TakeListDriver_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Make_Deal_Page.driverTake = (Driver)TakeListDriver.SelectedItems[0];

            if (Make_Deal_Page.driverTake != null)
           {
                ButtonTakeDriverNext.IsEnabled = true;
            }
        }


        private void ButtonTakeDriverNext_Click(object sender, RoutedEventArgs e)
        {

            GridDriver.Children.Clear();
            GridDriver.Children.Add(new TakePlacePage());
        }
    }
}

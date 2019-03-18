using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Driver_Pages.xaml
    /// </summary>
    public partial class Driver_Pages : UserControl
    {
        ObservableCollection<Driver> drivers;

        public Driver_Pages()
        {
            InitializeComponent();
            ButtonAdd_Driver.Background = Brushes.LightSeaGreen;
            ButtonFind_Driver.Background = Brushes.LightSeaGreen;
            ButtonUpdate_Driver.Background = Brushes.LightSeaGreen;
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            drivers = new ObservableCollection<Driver>();

            drivers.Add(new Driver("Alex", "Rab", "Alex", "DMw", "222", "22223", 33));
            drivers.Add(new Driver("dfdex", "Rab", "Alex", "DMw", "222", "22223", 33));

            drivers.Add(new Driver("Rrrx", "Rab", "Alex", "DMw", "222", "22223", 33));

            ListData.ItemsSource = drivers;
        }

        private void ListData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var selected = (Driver)ListData.SelectedItems[0];

            TextBox_Name.Text = selected.Name;
        }

        private void ButtonAdd_Driver_Click(object sender, RoutedEventArgs e)
        {
            try {
                drivers.Add(new Driver(TextBox_Name.Text, TextBox_LastName.Text, TextBox_SecondName.Text, TextBox_NameCar.Text, TextBox_Phone.Text, TextBox_NumberCar.Text, Convert.ToInt32(TextBox_Age.Text)));

                MessageBox.Show("Запись успешно добавлена", "Добавление записи", MessageBoxButton.OK);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ButtonFind_Driver_Click(object sender, RoutedEventArgs e)
        {   
            foreach (Driver item in drivers)
            {
                MessageBox.Show(item.Name);
            }

        }
    }
}

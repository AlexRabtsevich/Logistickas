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
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для Driver_Pages.xaml
    /// </summary>
    public partial class Driver_Pages : UserControl
    {
        ObservableCollection<Driver> drivers;
        private int number;
        private string DriverFile;

        public Driver_Pages()
        {
            InitializeComponent();
            ButtonAdd_Driver.Background = Brushes.LightSeaGreen;
            ButtonNewAdd_Driver.Background = Brushes.LightSeaGreen;
            ButtonUpdate_Driver.Background = Brushes.LightSeaGreen;
            IsReadOnlyTextBox();
            DriverFile = @"Driver\Driver.dat";
           LoadDriverCollection(DriverFile);
            
        }
        private void IsReadOnlyTextBox()
        {
            TextBox_Age.IsReadOnly = true;
            TextBox_Name.IsReadOnly = true;
            TextBox_LastName.IsReadOnly = true;
            TextBox_SecondName.IsReadOnly = true;
            TextBox_Phone.IsReadOnly = true;
            TextBox_NumberCar.IsReadOnly = true;
            TextBox_NameCar.IsReadOnly = true;

        }
        private void IsWriteOnlyTextBox()
        {

            TextBox_Age.IsReadOnly = false;
            TextBox_Name.IsReadOnly = false;
            TextBox_LastName.IsReadOnly = false;
            TextBox_SecondName.IsReadOnly = false;
            TextBox_Phone.IsReadOnly = false;
            TextBox_NumberCar.IsReadOnly = false;
            TextBox_NameCar.IsReadOnly = false;

        }
        private void IsClearOnlyTextBox()
        {
            TextBox_Age.Text = string.Empty;
            TextBox_Name.Text = string.Empty;
            TextBox_LastName.Text = string.Empty;
            TextBox_SecondName.Text = string.Empty;
            TextBox_NameCar.Text = string.Empty;
            TextBox_NumberCar.Text = string.Empty;
            TextBox_Phone.Text = string.Empty;

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            LoadDriverCollection(DriverFile);

            ListData.ItemsSource = drivers;
        }

        private void ListData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var selected = (Driver)ListData.SelectedItems[0];

            TextBox_Name.Text = selected.Name;
            TextBox_LastName.Text = selected.LastName;
            TextBox_SecondName.Text = selected.SecondName;
            TextBox_NameCar.Text = selected.Car;
            TextBox_NumberCar.Text = selected.NumberCar;
            TextBox_Age.Text = selected.Age;
            TextBox_Phone.Text = selected.NumberPhone;
            number =ListData.SelectedIndex;

        }

        private void ButtonAdd_Driver_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBox_LastName.Text != "" && TextBox_SecondName.Text != "" && TextBox_Age.Text != "" &&
                    TextBox_NameCar.Text != "" && TextBox_NumberCar.Text != "" && TextBox_Name.Text != "" && TextBox_Phone.Text != "")
                {
                    
                    drivers.Add(new Driver(TextBox_Name.Text, TextBox_LastName.Text, TextBox_SecondName.Text, TextBox_NameCar.Text, TextBox_Phone.Text, TextBox_NumberCar.Text, TextBox_Age.Text));

                    SaveDriverCollection(drivers, DriverFile);

                    MessageBox.Show("Запись успешно добавлена", "Добавление записи", MessageBoxButton.OK);
                    IsReadOnlyTextBox();
                }
                else
                {
                    MessageBox.Show("Запаолните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    IsReadOnlyTextBox();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void ButtonNewAdd_Driver_Click(object sender, RoutedEventArgs e)
        {
            IsClearOnlyTextBox();
            IsWriteOnlyTextBox();
            
        }

        private void ButtonUpdate_Driver_Click(object sender, RoutedEventArgs e)
        {
            IsWriteOnlyTextBox();
            
        }

        private void TextBox_Age_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                    e.Handled = false;
                    break;
                default:
                    e.Handled = true;
                    break;
            }

        }
        private void SaveDriverCollection(object collection, string filename)
        {
            BinaryFormatter binary = new BinaryFormatter();

            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binary.Serialize(stream, collection);
            
            }
        }
        private void LoadDriverCollection(string filename)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (Stream stream = File.OpenRead(filename))
                {
                    if (stream != null)
                    {
                        drivers = (ObservableCollection<Driver>)binaryFormatter.Deserialize(stream);
                    }
                    else
                    {
                        MessageBox.Show("Файл бызы данных водителей не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

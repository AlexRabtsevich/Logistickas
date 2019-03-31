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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для TakePlacePage.xaml
    /// </summary>
    public partial class TakePlacePage : UserControl
    {
        public ObservableCollection<PlaceTake> PlacesCollection;

        private string PlaceFile;

        public static PlaceTake Place;


        public TakePlacePage()
        {
            InitializeComponent();
            PlacesCollection = new ObservableCollection<PlaceTake>();
            PlaceFile = @"Place\Place.dat";

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
                TextDriver.Text += string.Format(" {0}, {1} , {2}", Make_Deal_Page.driverTake.Name, Make_Deal_Page.driverTake.SecondName, Make_Deal_Page.driverTake.LastName);

                LoadPlaceTakeCollection(PlaceFile);

                ListPlaceData.ItemsSource = PlacesCollection;

                Grid1.Height = 30;

                ButtonPlaceNext.IsEnabled = false;


        }

        private void ButtonPlaceBack_Click(object sender, RoutedEventArgs e)
        {
           GridTakePlace.Children.Clear();
           GridTakePlace.Children.Add(new Take_Driver_Page());
        }

        private void ButtonPlaceNext_Click(object sender, RoutedEventArgs e)
        {
            
                GridTakePlace.Children.Clear();
                GridTakePlace.Children.Add(new TakeOrderPage());
                
            
            
        }
        private void LoadPlaceTakeCollection(string filename)
        {
            try
            {

                BinaryFormatter binary = new BinaryFormatter();
                using (Stream stream = File.OpenRead(filename))
                {
                    if (stream != null)
                    {
                        PlacesCollection = (ObservableCollection<PlaceTake>)binary.Deserialize(stream);
                    }
                    else
                    {
                        MessageBox.Show("Файл с адрессами не найден!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ListPlaceData_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Place = (PlaceTake)ListPlaceData.SelectedItems[0];
            if (Place != null)
            {
                ButtonPlaceNext.IsEnabled = true;
            }
        }
        private void SavePlaceCollection(string filename,object place)
        {
            try
            {
                BinaryFormatter binary = new BinaryFormatter();

                using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binary.Serialize(stream, place);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonShowElement_Click(object sender, RoutedEventArgs e)
        {
            if (Grid1.Height == 30)
            {
                Grid1.Height = 200;
                ButtonShowElement.Content = "v";
                GridButtonNext.Height = 0;
                Grid1.Margin = new Thickness(0 ,0, 0 ,10);
            }
            else if(Grid1.Height == 200)
            {
                Grid1.Height = 30;
                ButtonShowElement.Content = "^";
                GridButtonNext.Height = 90;
                Grid1.Margin = new Thickness(0, 0, 0, 90);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextPlaceName.Text != "" && TextPlaceCity.Text != "" && TextPlaceStreet.Text != "" && TextPlaceHouse.Text != "" )
                {
                    PlacesCollection.Add(new PlaceTake(TextPlaceName.Text, TextPlaceCity.Text, TextPlaceStreet.Text, TextPlaceHouse.Text));
                    SavePlaceCollection(PlaceFile, PlacesCollection);
                }
                else
                {
                    MessageBox.Show("Поля не могут быть пустыми", "Заполните все поля", MessageBoxButton.OK);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}

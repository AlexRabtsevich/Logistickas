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
using GMap.NET.WindowsPresentation;
using GMap.NET.Internals;



namespace Logistickas
{
    /// <summary>
    /// Логика взаимодействия для MapsPage.xaml
    /// </summary>
    public partial class MapsPage : UserControl
    {
       
        public MapsPage()
        {
            InitializeComponent();
        }

        private void GMapcontrol_Loaded(object sender, RoutedEventArgs e)
        {
            LoadGMaps();           

        }
        private void LoadGMaps()
        {
            try
            {

                gMapcontrol.Bearing = 0;

                gMapcontrol.MinZoom = 6;
                gMapcontrol.MaxZoom = 14;

                gMapcontrol.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
                gMapcontrol.CanDragMap = false;

                gMapcontrol.UseLayoutRounding = true;

                gMapcontrol.Position = new GMap.NET.PointLatLng(53.8739662, 27.5834035);

                gMapcontrol.ShowTileGridLines = false;

                gMapcontrol.Zoom = 7;
                /// gMapcontrol.Dock = DockStyle.Fill;

                gMapcontrol.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
                GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

                GMapMarker[] marker =
                    { new GMapMarker(new GMap.NET.PointLatLng(53.1335905,25.9734896)),
                new GMapMarker(new GMap.NET.PointLatLng(53.9039895,27.5588672)),
                new GMapMarker(new GMap.NET.PointLatLng(55.1891458,30.1935142)),
                new GMapMarker(new GMap.NET.PointLatLng(53.9016537,30.3086986)),
                new GMapMarker(new GMap.NET.PointLatLng(54.3108698,26.8449953)),
                new GMapMarker(new GMap.NET.PointLatLng(52.093794,23.695953)),
                new GMapMarker(new GMap.NET.PointLatLng(53.6772566,23.818504)),
                new GMapMarker(new GMap.NET.PointLatLng(52.437874,30.9611475))
            };

                for (int i = 0; i < marker.Length; i++)
                {
                    marker[i].Shape = new Ellipse
                    {
                        Width = 15,
                        Height = 15,
                        Stroke = Brushes.Red,
                        StrokeThickness = 5
                    };
                    gMapcontrol.Markers.Add(marker[i]);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListViewStreet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewStreet.SelectedIndex;
            switch (index)
            {
                case 0:
                    gMapcontrol.Position = new GMap.NET.PointLatLng(53.1335905, 25.9734896);
                    gMapcontrol.Zoom = 14;
                    break;
                case 1:
                    gMapcontrol.Position = new GMap.NET.PointLatLng(53.9039895, 27.5588672);
                    gMapcontrol.Zoom = 14;
                    break;
                case 2:
                    gMapcontrol.Position = new GMap.NET.PointLatLng(55.1891458, 30.1935142);
                    gMapcontrol.Zoom = 14;
                    break;
                case 3:
                    gMapcontrol.Position = new GMap.NET.PointLatLng(53.9016537, 30.3086986);
                    gMapcontrol.Zoom = 14;
                    break;
                case 4:
                    gMapcontrol.Position = new GMap.NET.PointLatLng(54.3108698, 26.8449953);
                    gMapcontrol.Zoom = 14;
                    break;
                case 5:
                    gMapcontrol.Position = new GMap.NET.PointLatLng(52.093794, 23.695953);
                    gMapcontrol.Zoom = 14;
                    break;
                case 6:
                    gMapcontrol.Position = new GMap.NET.PointLatLng(53.6772566, 23.818504);
                    gMapcontrol.Zoom = 14;
                    break;
                case 7:
                    gMapcontrol.Position = new GMap.NET.PointLatLng(52.437874, 30.9611475);
                    gMapcontrol.Zoom = 14;
                    break;
            }

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Device.Location;
using System.Windows.Media;
using GMap.NET.MapProviders;

namespace OOP_lab2_Maps
{
    class Car : MapObject
    {
        public PointLatLng point;

        public Car(string title, PointLatLng point) : base(title)
        {
            this.point = point;
        }


        public override double GetDistance(PointLatLng point)
        {
            GeoCoordinate p1 = new GeoCoordinate(point.Lat, point.Lng);
            GeoCoordinate p2 = new GeoCoordinate(this.point.Lat, this.point.Lng);

            return p1.GetDistanceTo(p2);
        }

        public override PointLatLng GetFocus()
        {
            return point;
        }

        public override GMapMarker GetMarker()
        {

            GMapMarker marker= new GMapMarker(point)
            {
                Shape = new Image
                {
                    Width = 40, // ширина маркера
                    Height = 40, // высота маркера  
                    ToolTip = this.GetTitle(),
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Car.png")), // картинка
                    RenderTransform = new TranslateTransform { X = -20, Y = -20 } // картинка
                }
            };

           // marker_car.Position = point;
            return marker;

        }
        

    }
}

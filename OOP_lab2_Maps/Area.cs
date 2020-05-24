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
using GMap.NET.MapProviders;
using System.Windows.Shapes;
using System.Windows.Media;

namespace OOP_lab2_Maps
{
    class Area : MapObject
    {
        public List<PointLatLng> points;

        public Area(string title, List<PointLatLng> points) : base(title)
        {
            this.points = new List<PointLatLng>();
            foreach (PointLatLng z in points)
            {
                this.points.Add(z);
            }

        }


        public override double GetDistance(PointLatLng point)
        {
            var C = new Class1();
            double distance = C.GetMinDistance(points[0], points[1], point);
            for (int i = 1; i < points.Count; i++)
            {
                if (C.GetMinDistance(points[i], points[(i + 1) % points.Count], point) < distance)
                {
                    distance = C.GetMinDistance(points[i], points[(i + 1) % points.Count], point);
                }
            }
            return distance;
        }

        public override PointLatLng GetFocus()
        {
            return points[0];
        }

        public override GMapMarker GetMarker()
        {

            GMapMarker marker = new GMapPolygon(points)
            {
                Shape = new Path()
                {
                    Stroke = Brushes.DarkKhaki, // цвет обводки
                    Fill = Brushes.Aqua, // цвет заливки
                    Opacity = 0.5 // прозрачность 
                }
            };

            // marker_car.Position = point;
            return marker;

        }
    }
}

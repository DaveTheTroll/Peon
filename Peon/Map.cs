using System;
using System.Net;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using JollyGood;
using System.Collections.Generic;

namespace Peon.Maps
{
    // https://developers.google.com/maps/documentation/static-maps/

    public enum MapType
    {
        satellite,
        roadmap,
        hybrid,
        terrain
    }

    public enum MapFormat
    {
        png,
        png32,
        gif,
        jpg,
        [String("jpg-baseline")]
        jpg_baseline
    }

    public class Map
    {
        public Map(string centre, int width = 640, int height = 400, int zoom = 15)
        {
            Width = width;
            Height = height;
            Centre = centre;
            Zoom = zoom;
            Scale = 1;
            MapType = MapType.satellite;

            Features = new List<IFeature>();
            VisiblePlaces = new List<Place>();
        }
        public Map() : this("0,0")
        {
        }

        const string browserKey = "AIzaSyAz8mtQQhQTsw4jgDaXg6T3F2BqxErfnJw";

        [DefaultValue(640)]
        public int Width { get; set; }
        [DefaultValue(400)]
        public int Height { get; set; }
        [DefaultValue(15)]
        public int Zoom { get; set; }

        public string Centre { get; set; }
        public MapType MapType { get; set; }

        [DefaultValue(1)]
        public int Scale { get; set; }

        public MapFormat Format { get; set; }

        public List<Place> VisiblePlaces { get; private set; }

        public List<IFeature> Features { get; private set; }

        public Image Image { get; private set; }

        public void Generate()
        {
            string url = string.Format("http://maps.googleapis.com/maps/api/staticmap?center={3}&size={1}x{2}&maptype={4}&key={0}&scale={5}&format={6}",
                browserKey, Width / Scale, Height / Scale, Centre, MapType, Scale, StringAttribute.GetString(Format));

            if (VisiblePlaces.Count == 0)
                url += string.Format("&zoom:{0}", Zoom);

            foreach (IFeature marker in Features)
                url += "&" + marker.URLPart;

            foreach (Place place in VisiblePlaces)
                url += string.Format("&visible:{0}", place);

            using (WebClient client = new WebClient())
            {
                byte[] data = client.DownloadData(url);
                using (MemoryStream stream = new MemoryStream(data))
                {
                    Image = Image.FromStream(stream);
                }
            }
        }
    }

    public interface IFeature
    {
        string URLPart {get; }
    }

    public enum MarkerSize
    {
        notSet, tiny, mid, small
    }
    public enum FeatureColor
    {
        notSet, black, brown, green, purple, yellow, blue, gray, orange, red, white
    }

    // TODO: Make this Markers and replace Location with a List.
    // TODO: Add "icon" option
    public class Marker : IFeature
    {
        public Marker(Place location = null, FeatureColor color = FeatureColor.notSet, MarkerSize size = MarkerSize.notSet, char label = '\0')
        {
            this.Location = location;
            this.Size = size;
            this.Color = color;
            this.Label = label;
        }

        public MarkerSize Size { get; set; }
        public FeatureColor Color { get; set; }
        public char Label { get; set; }
        public Place Location { get; set; }

        public string URLPart
        {
            get
            {
                string urlPart = "markers=";
                if (Size != MarkerSize.notSet)
                    urlPart += string.Format("size:{0}|", Size);
                if (Color != FeatureColor.notSet)
                    urlPart += string.Format("color:{0}|", Color);
                if ((Label >= 'A' && Label <= 'Z') || (Label >= '0' && Label <= '9'))   // Upper case or numeric
                    urlPart += string.Format("label:{0}|", Label);
                urlPart += Location.ToString();

                return urlPart;
            }
        }
    }

    public class Path : IFeature
    {
        public Path(int weight = 5, FeatureColor color = FeatureColor.notSet, FeatureColor fillColor = FeatureColor.notSet, bool geodesic = false)
        {
            this.Weight = weight;
            this.Color = color;
            this.FillColor = fillColor;
            this.Geodesic = geodesic;

            this.Points = new List<Place>();
        }

        [DefaultValue(5)]
        public int Weight { get; set; }
        public FeatureColor Color { get; set; }
        public FeatureColor FillColor { get; set; }
        [DefaultValue(false)]
        public bool Geodesic { get; set; }

        public List<Place> Points { get; private set; }

        public string URLPart
        {
            get
            {
                string urlPart = "path=";
                if (Weight != 5)
                    urlPart += string.Format("weight:{0}|", Weight);
                if (Geodesic)
                    urlPart += "geodesic:true|";
                if (Color != FeatureColor.notSet)
                    urlPart += string.Format("color:{0}|", Color);
                if (FillColor != FeatureColor.notSet)
                    urlPart += string.Format("fillcolor:{0}|", FillColor);
                foreach(Place point in Points)
                {
                    urlPart += point.ToString() + "|";
                }

                return urlPart.Substring(0, urlPart.Length-1);
            }
        }
    }
}

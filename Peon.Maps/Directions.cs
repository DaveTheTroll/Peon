using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Peon.Maps
{
    // https://developers.google.com/maps/documentation/directions/intro

    public class GeocodedWaypoint
    {
        [JsonProperty("geocoder_status")]
        public string Status { get; set; }
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        public List<string> Types { get; set; }
    }

    public class TextValuePair
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public override string ToString() { return Text; }
    }

    public class Section
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TextValuePair Distance { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TextValuePair Duration { get; set; }
        [JsonProperty("end_location")]
        public LatLong EndLocation { get; set; }
        [JsonProperty("start_location")]
        public LatLong StartLocation { get; set; }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PolylineList : List<LatLong>
    {
        public double TotalLength
        {
            get
            {
                double totalLength = 0;
                for (int i = 0; i < Count-1; i++)
                    totalLength += LatLong.ApproxDistanceBetween(this[i], this[i+1]);
                return totalLength;
            }
        }

        // Returns the location of a point the specified fraction along the route.
        public LatLong ProportionalLocation(double fraction)
        {
            if (fraction < 0 || fraction > 1)
                throw new ArgumentException("Fraction out of bounds (0-1)", "fraction");

            double[] steps = new double[Count - 1];
            double totalLength = 0;
            for (int i = 0; i < Count - 1; i++)
            {
                steps[i] = LatLong.ApproxDistanceBetween(this[i], this[i+1]);
                totalLength += steps[i];
            }

            double length = totalLength * fraction;
            for (int i = 0; i < Count - 1; i++)
            {
                if (length < steps[i])
                {
                    double ratio = length / steps[i];
                    return new LatLong((1 - ratio) * this[i].Latitude + ratio * this[i + 1].Latitude,
                        (1 - ratio) * this[i].Longitude + ratio * this[i + 1].Longitude);
                }
                length -= steps[i];
            }

            return this[Count - 1];
        }
    }

    public class Polyline
    {
        public string Points { get; set; }

        // https://developers.google.com/maps/documentation/utilities/polylinealgorithm
        // http://stackoverflow.com/questions/15924834/decoding-polyline-with-new-google-maps-api
        public PolylineList GetList()
        {
            PolylineList list = new PolylineList();

            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(Points);
            int lat = 0;
            int lng = 0;
            int i = 0;
            while (i < bytes.Length)
            {
                lat += ExtractValue(bytes, ref i);
                lng += ExtractValue(bytes, ref i);
                list.Add(new LatLong(lat * 1.0e-5, lng * 1.0e-5));
            }

            return list;
        }

        static int ExtractValue(byte[] bytes, ref int i)
        {
            int b;
            int shift = 0;
            int result = 0;
            do
            {
                b = bytes[i] - 63;
                i++;
                result |= (b & 0x1f) << shift;
                shift += 5;
            } while (b >= 0x20);

            return (result & 0x01) != 0 ? ~(result >> 1) : (result >> 1);
        }
    }

    public class Step : Section
    {
        [JsonProperty("html_instructions")]
        public string Instructions { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Polyline Polyline { get; set; }
        [JsonProperty("travel_mode")]
        public string TravelMode { get; set; }
        public string Maneuver { get; set; }
    }

    public class Leg : Section
    {
        [JsonProperty("end_address")]
        public string EndAddress { get; set; }
        [JsonProperty("start_address")]
        public string StartAddress { get; set; }

        public List<Step> Steps { get; set; }
        [JsonProperty("via_waypoints")]
        public List<object> ViaWaypoint { get; set; }   // TODO
    }

    public class Route
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Rectangle Bounds { get; set; }
        public string Copyrights { get; set; }
        public List<Leg> Legs { get; set; }
        [JsonProperty("overview_polyline"), TypeConverter(typeof(ExpandableObjectConverter))]
        public Polyline OverviewPolyline { get; set; }
        public string Summary { get; set; }
        public List<string> Warnings { get; set; }
        [JsonProperty("waypoint_order")]
        public List<object> WaypointOrder { get; set; }   // TODO

        public override string ToString() { return Summary; }
    }

    public class DirectionsResponse
    {
        public static DirectionsResponse Get(DirectionsRequest request) { return GoogleAPI.Get<DirectionsResponse>(request); }
        public static DirectionsResponse Get(Place origin, Place destination) { return Get(new DirectionsRequest(origin, destination)); }
        public static DirectionsResponse Get(string origin, string destination) { return Get(new NamedPlace(origin), new NamedPlace(destination)); }

        [JsonProperty("geocoded_waypoints")]
        public List<GeocodedWaypoint> Waypoints { get; set; }
        public List<Route> Routes { get; set; }
        public string Status { get; set; }
    }

    public class DirectionsRequest : IGoogleAPIRequest
    {
        public DirectionsRequest(Place origin, Place destination)
        {
            this.Origin = origin;
            this.Destination = destination;
        }

        public Place Origin { get; set; }
        public Place Destination { get; set; }

        public string URL
        {
            get
            {
                return string.Format("https://maps.googleapis.com/maps/api/directions/json?origin={0}&destination={1}&key={2}", Origin, Destination, GoogleAPI.serverKey);
            }
        }
    }
}

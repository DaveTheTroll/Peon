using System;

namespace Peon.Maps
{
    // https://developers.google.com/maps/documentation/directions/intro

    public class DirectionsResponse
    {
        public static DirectionsResponse Get(DirectionsRequest request) { return GoogleAPI.Get<DirectionsResponse>(request); }
        public static DirectionsResponse Get(Place origin, Place destination) { return Get(new DirectionsRequest(origin, destination)); }
        public static DirectionsResponse Get(string origin, string destination) { return Get(new NamedPlace(origin), new NamedPlace(destination)); }
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

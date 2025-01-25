namespace RobotixJapanMVC.Models
{
    public class HomeViewModel
    {
        public string LocationName { get; set; } = "Fetching location...";
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Temperature { get; set; } = "-- °C";
        public string WindSpeed { get; set; } = "-- m/s";
        public string Precipitation { get; set; } = "-- mm";
        public string SensorStatus { get; set; } = "Loading...";
    }
}

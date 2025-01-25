namespace RobotixJapanBlazorWeb.Models
{
    public class NominatimResponse
    {
        public long PlaceId { get; set; }
        public string Licence { get; set; }
        public string OsmType { get; set; }
        public long OsmId { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public int PlaceRank { get; set; }
        public double Importance { get; set; }
        public string Addresstype { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public Address Address { get; set; }
        public List<string> BoundingBox { get; set; }
    }

    public class Address
    {
        public string Amenity { get; set; }
        public string Road { get; set; }
        public string Quarter { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ISO3166_2_lvl4 { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
    }
}

using Newtonsoft.Json;
using RobotixJapanBlazorWeb.Models;

namespace RobotixJapan.MVC.Services
{
    public class LocationApi
    {
        public static async Task<NominatimResponse?> GetLocationName(double latitude, double longitude)
        {
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(15);
                client.DefaultRequestHeaders.UserAgent.ParseAdd("RobotixJapan/1.0");

                var response = await client.GetAsync($"https://nominatim.openstreetmap.org/reverse?lat={latitude}&lon={longitude}&format=json");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<NominatimResponse>(content);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching location data: {ex.Message}");
                return null;
            }
        }
    }
}

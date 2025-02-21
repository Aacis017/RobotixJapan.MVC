using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotixJapan.MVC.Models;
using RobotixJapan.MVC.Services;
using RobotixJapanBlazorWeb.Services;
using RobotixJapanMVC.Models;

namespace RobotixJapanMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string SensorApiUrl = "http://192.168.4.1";
        private static GeolocationResult? _userGeolocation;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            if (_userGeolocation != null)
            {
                model.Latitude = _userGeolocation.Latitude;
                model.Longitude = _userGeolocation.Longitude;

                var locationDetails = await LocationApi.GetLocationName(model.Latitude, model.Longitude);

                if (locationDetails != null)
                {
                    model.LocationName = $"{locationDetails.Address?.City}, {locationDetails.Address?.Province}";
                }

                var weather = await ApiService.GetCurrentWeather(model.Latitude, model.Longitude);
                if (weather != null)
                {
                    model.Temperature = $"{weather.current.temp_c} �C";
                    model.WindSpeed = $"{weather.current.wind_mph * 0.44704:F2} m/s";
                    model.Precipitation = $"{weather.current.precip_mm} mm";
                }
            }
            else
            {
                model.LocationName = "Unable to fetch geolocation. Please enable location access.";
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult SetGeolocation([FromBody] GeolocationResult geolocation)
        {
            _userGeolocation = geolocation;
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> FetchSensorDataApi()
        {
            try
            {
                var status = await FetchSensorData();
                return Json(new { sensorStatus = status });
            }
            catch (Exception ex)
            {
                // Log the exception as needed
                return StatusCode(500, new { error = ex.Message });
            }
        }

        private async Task<string> FetchSensorData()
        {
            try
            {
                var response = await _httpClient.GetAsync(SensorApiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return $"Error: {response.StatusCode}";
                }

                var contentType = response.Content.Headers.ContentType?.MediaType;

                if (contentType != "application/json")
                {
                    // Log the response content for debugging
                    var content = await response.Content.ReadAsStringAsync();
                    return $"Unexpected content type: {contentType}. Response: {content}";
                }

                // Deserialize the JSON response
                var sensorData = await response.Content.ReadFromJsonAsync<SensorData>();

                if (sensorData == null || string.IsNullOrEmpty(sensorData.Sensor))
                {
                    return "No data available";
                }

                return sensorData.Sensor;
            }
            catch (HttpRequestException)
            {
                return "Can't connect to the API";
            }
            catch (JsonException ex)
            {
                return $"Invalid JSON: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error fetching data: {ex.Message}";
            }
        }



        public class SensorData
        {
            public string Sensor { get; set; }
        }

    }
}

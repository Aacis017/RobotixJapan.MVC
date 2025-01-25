//using Microsoft.AspNetCore.Mvc;

//namespace RobotixJapanBlazorWeb.Services
//{
//    [Route("api/arduino")]
//    [ApiController]
//    public class ArduinoApiController : ControllerBase
//    {
//        private readonly SerialPortService _serialPortService;

//        public ArduinoApiController()
//        {
//            _serialPortService = new SerialPortService("COM8", 9600);
//            Task.Delay(2000);        }

//        [HttpGet("water-status")]
//        public IActionResult GetWaterStatus()
//        {
//            var status = _serialPortService.GetWaterStatus();
//            return Ok(new {Status = status});
//        }
//    }
//}

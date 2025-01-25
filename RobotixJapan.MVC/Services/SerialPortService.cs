//using System.IO.Ports;

//namespace RobotixJapanBlazorWeb.Services
//{
//    public class SerialPortService : IDisposable
//    {
//        private readonly SerialPort _serialPort;

//        public SerialPortService(string portName, int budRate)
//        {
//            _serialPort = new SerialPort(portName, budRate)
//            {
//                ReadTimeout = 3000, // Adjust as needed
//                WriteTimeout = 3000
//            };
//            Task.Delay(1000);
//            _serialPort.Open();

//        }


//        public string GetWaterStatus()
//        {
//            try
//            {
//                string data =_serialPort.ReadLine(); // Reads Line From Arduino
//                _serialPort.Close();
//                return data;
//            }
//            catch (TimeoutException ex)
//            {
//                return "No Data";
//            }
//        }

//        public void Dispose()
//        {
//            if (_serialPort.IsOpen)
//            {
//                _serialPort.Close();
//            }
//        }
//    }
//}   
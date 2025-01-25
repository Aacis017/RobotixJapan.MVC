namespace RobotixJapanBlazorWeb.Models
{
    public class SolarPanelCleaner
    {
        public int BatteryLevel { get; set; }
        public bool IsCleaning { get; set; }

        //public Command StartCommand { get; set; }
        //public Command StopCommand { get; set; }
        public CleaningStatus CleaningStatus { get; set; }
        public WaterLevelStatus WaterLevelStatus { get; set; }

    }

    public enum CleaningStatus
    {

        Inactive,
        StandBy,
        Cleaning,
        Stopped,
        Error
    }
    public enum WaterLevelStatus
    {
        Full,
        Empty
    }
}

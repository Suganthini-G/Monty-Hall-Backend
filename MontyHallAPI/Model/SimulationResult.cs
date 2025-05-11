namespace MontyHallAPI.Model
{
    public class SimulationResult
    {
        public int Simulations { get; set; }
        public bool ChangedDoor { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public double WinPercentage { get; set; }
    }
}

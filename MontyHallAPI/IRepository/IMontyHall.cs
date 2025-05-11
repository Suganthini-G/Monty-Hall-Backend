using MontyHallAPI.Model;

namespace MontyHallAPI.IRepository
{
    public interface IMontyHall
    {
        SimulationResult Simulation(int simulations, bool changeDoor);
    }
}

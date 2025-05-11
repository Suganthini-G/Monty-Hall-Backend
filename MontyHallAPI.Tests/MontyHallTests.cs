using MontyHallAPI.Repository;
using Xunit;

namespace MontyHallAPI.Tests
{
    public class MontyHallTests
    {
        [Theory]
        [InlineData(1000, true)]
        [InlineData(1000, false)]
        public void Simulation_ShouldReturnCorrectSimulationCount(int simulations, bool changeDoor)
        {
            var montyHall = new MontyHall();

            var result = montyHall.Simulation(simulations, changeDoor);

            Assert.Equal(simulations, result.Simulations);
            Assert.Equal(simulations, result.Wins + result.Losses);
            Assert.Equal(changeDoor, result.ChangedDoor);
            Assert.InRange(result.WinPercentage, 0, 100);
        }

        [Fact]
        public void Simulation_WithZeroSimulations_ShouldReturnZeroStats()
        {
            var montyHall = new MontyHall();

            var result = montyHall.Simulation(0, true);

            Assert.Equal(0, result.Simulations);
            Assert.Equal(0, result.Wins);
            Assert.Equal(0, result.Losses);
            Assert.Equal(0, result.WinPercentage);
        }
    }
}

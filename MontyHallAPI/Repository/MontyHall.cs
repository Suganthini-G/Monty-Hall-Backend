using MontyHallAPI.IRepository;
using MontyHallAPI.Model;
using System;
using System.Collections.Generic;

namespace MontyHallAPI.Repository
{
    public class MontyHall : IMontyHall
    {
        public SimulationResult Simulation(int simulations, bool changeDoor)
        {
            try 
            { 
                int wins = 0;
                Random random = new Random();

                for (int i = 0; i < simulations; i++)
                {
                    int carPosition = random.Next(3);
                    int initialChoice = random.Next(3);

                    int revealedDoor = GetRevealedDoor(carPosition, initialChoice, random);

                    int finalChoice;
                    if (changeDoor)
                    {
                        finalChoice = 3 - initialChoice - revealedDoor;
                    }
                    else
                    {
                        finalChoice = initialChoice;
                    }

                    if (finalChoice == carPosition)
                    {
                        wins++;
                    }
                }

                return new SimulationResult
                {
                    Simulations = simulations,
                    ChangedDoor = changeDoor,
                    Wins = wins,
                    Losses = simulations - wins,
                    WinPercentage = simulations > 0 ? (double)wins / simulations * 100 : 0
                };
            }
            catch (Exception ex)
            {
                return new SimulationResult
                {
                    Simulations = simulations,
                    ChangedDoor = changeDoor,
                    Wins = 0,
                    Losses = 0,
                    WinPercentage = 0,
                };
            }
        }
        private int GetRevealedDoor(int carPosition, int playerChoice, Random random)
        {
            List<int> possibleDoors = new List<int>();

            for (int door = 0; door < 3; door++)
            {
                if (door != carPosition && door != playerChoice)
                {
                    possibleDoors.Add(door);
                }
            }

            if (possibleDoors.Count > 1)
            {
                return possibleDoors[random.Next(possibleDoors.Count)];
            }
            return possibleDoors[0];
        }
    }
}

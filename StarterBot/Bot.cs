using StarterBot.Entities;
using StarterBot.Enums;
using System;
using System.Linq;

namespace StarterBot
{
    public class Bot
    {
        private readonly GameState gameState;

        private readonly BuildingStats attackBuilding;
        private readonly BuildingStats defenseBuilding;
        private readonly BuildingStats energyBuilding;

        private readonly int mapWidth;
        private readonly int mapHeight;
        private readonly Player myPlayer;
        private readonly Random random;

        public Bot(GameState gameState)
        {
            this.gameState = gameState;
            this.mapHeight = gameState.GameDetails.MapHeight;
            this.mapWidth = gameState.GameDetails.MapWidth;

            this.attackBuilding = gameState.GameDetails.BuildingsStats[BuildingType.Attack];
            this.defenseBuilding = gameState.GameDetails.BuildingsStats[BuildingType.Defense];
            this.energyBuilding = gameState.GameDetails.BuildingsStats[BuildingType.Energy];

            this.random = new Random((int)DateTime.Now.Ticks);

            myPlayer = gameState.Players.Single(x => x.PlayerType == PlayerType.A);
        }

        public string Run()
        {
            if (myPlayer.Energy < defenseBuilding.Price || myPlayer.Energy < energyBuilding.Price || myPlayer.Energy < attackBuilding.Price)
            {
                for (var xAxis = 0; xAxis < (mapWidth / 2); xAxis++)
                {
                    for (var yAxis = 0; yAxis <= mapHeight;yAxis++)
                    {
                        if(xAxis % 2 == 0)
                        {
                        return $"{xAxis},{yAxis},{0}";
                        }
                        else
                        {
                        return $"{xAxis},{yAxis},{1}";
                        }
                    }
                }
            }
        }
    }
}
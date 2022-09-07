using System;
using WorldCupDomain.InModels;
using WorldCupDomain.OutModels;
using WorldCupLogicInterface.Interfaces;

namespace WorldCupLogic.Logics
{
    public class PlayerLogic : IPlayerLogic
    {
  
        public void DeletePlayer(string lastName)
        {
            Console.WriteLine("deleted player " + lastName);
        }

        public void AddPlayer(PlayerInModel somePlayer)
        {
            Console.WriteLine("added player " + somePlayer);
        }

        public PlayerOutModel GetPlayer(PlayerInModel somePlayer)
        {
            Console.WriteLine("fetching player " + somePlayer);
            return new PlayerOutModel()
            {
                Name = somePlayer.Name,
                LastName = somePlayer.LastName,
                Country = somePlayer.Country,
                Id = 0
            };
        }
    }
}

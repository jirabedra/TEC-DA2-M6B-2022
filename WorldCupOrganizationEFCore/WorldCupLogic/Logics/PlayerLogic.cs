using System;
using WorldCupOrganization.Interfaces.Contracts;

using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.Logics
{
    public class PlayerLogic : IPlayerLogic
    {
  
        public void DeletePlayer(string lastName)
        {
            Console.WriteLine("deleted player " + lastName);
        }

        public Player AddPlayer(Player somePlayer)
        {
            Console.WriteLine("added player " + somePlayer);
            return somePlayer;
        }

        public Player GetPlayer(Player somePlayer)
        {
            Console.WriteLine("fetching player " + somePlayer);
            return new Player()
            {
                Name = somePlayer.Name,
                LastName = somePlayer.LastName,
                Country = somePlayer.Country,
                Id = 0
            };
        }
    }
}

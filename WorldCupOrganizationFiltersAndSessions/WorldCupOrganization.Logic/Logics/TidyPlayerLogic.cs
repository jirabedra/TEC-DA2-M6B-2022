using System;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.Logic.Logics
{
    public class TidyPlayerLogic : IPlayerLogic
    {
        public Player AddPlayer(Player somePlayer)
        {
            Console.WriteLine("Added player named " + somePlayer.Name
                + " with last name " + somePlayer.LastName 
                + "and is from " + somePlayer.Country);
            return somePlayer;
        }
        public Player GetPlayer(Player somePlayer)
        {
            Console.WriteLine("Player named " + somePlayer.Name
                + " with last name " + somePlayer.LastName
                + "and is from " + somePlayer.Country);
            return new Player()
            {
                Name = somePlayer.Name,
                LastName = somePlayer.LastName,
                Country = somePlayer.Country,
                Id = 0
            };
        }
        public void DeletePlayer(string lastName)
        {
            Console.WriteLine("Deleted player with last name " + lastName);
        }
    }
}

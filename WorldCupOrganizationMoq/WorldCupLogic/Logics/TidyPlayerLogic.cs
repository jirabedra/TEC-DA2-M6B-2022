using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupDomain.InModels;
using WorldCupDomain.OutModels;
using WorldCupLogicInterface.Interfaces;

namespace WorldCupLogic.Logics
{
    public class TidyPlayerLogic : IPlayerLogic
    {
        public void AddPlayer(PlayerInModel somePlayer)
        {
            Console.WriteLine("Added player named " + somePlayer.Name
                + " with last name " + somePlayer.LastName 
                + "and is from " + somePlayer.Country);
        }
        public PlayerOutModel GetPlayer(PlayerInModel somePlayer)
        {
            Console.WriteLine("Player named " + somePlayer.Name
                + " with last name " + somePlayer.LastName
                + "and is from " + somePlayer.Country);
            return new PlayerOutModel()
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

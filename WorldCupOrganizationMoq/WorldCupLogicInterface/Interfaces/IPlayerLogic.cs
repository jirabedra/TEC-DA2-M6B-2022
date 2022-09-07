using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupDomain.InModels;
using WorldCupDomain.OutModels;

namespace WorldCupLogicInterface.Interfaces
{
    public interface IPlayerLogic
    {
        public void AddPlayer(PlayerInModel somePlayer);
        public PlayerOutModel GetPlayer(PlayerInModel somePlayer);
        public void DeletePlayer(string lastName);
    }
}

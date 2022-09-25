using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.Interfaces.Contracts
{
    public interface IPlayerLogic
    {
        public Player AddPlayer(Player somePlayer);
        public Player GetPlayer(Player somePlayer);
        public void DeletePlayer(string lastName);
    }
}

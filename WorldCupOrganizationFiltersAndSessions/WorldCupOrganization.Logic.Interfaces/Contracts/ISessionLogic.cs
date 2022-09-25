using System;

namespace WorldCupOrganization.Logic.Interfaces.Contracts
{
    public interface ISessionLogic
    {
        Guid Login(string mail, string password);
        bool IsValidToken(Guid aToken);
        int GetAdminIdFromToken(Guid aToken);
    }
}
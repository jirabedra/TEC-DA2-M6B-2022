using System;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.DataAccess.Interfaces.Contracts
{
    public interface ISessionRepository
    {
         SessionState Add(SessionState aSession);

         bool Exist(Func<SessionState, bool> func);

         SessionState Get(Func<SessionState, bool> func);  
    }
}
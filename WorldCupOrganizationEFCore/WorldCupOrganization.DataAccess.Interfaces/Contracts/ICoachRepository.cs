using System;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.DataAccess.Interfaces.Contracts
{
    public interface ICoachRepository
    {
        Coach AddCoach(Coach coach);
    }
}

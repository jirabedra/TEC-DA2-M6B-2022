using System;
using System.Collections.Generic;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.DataAccess.Interfaces.Contracts
{
    public interface ICoachRepository
    {
        Coach AddCoach(Coach coach);
        List<Coach> GetAllCoaches();
    }
}

﻿using System.Collections.Generic;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.Interfaces.Contracts
{
    public interface ICoachLogic
    {
        public Coach CreateCoach(Coach coach);
        public List<Coach> GetAllCoaches();
    }
}

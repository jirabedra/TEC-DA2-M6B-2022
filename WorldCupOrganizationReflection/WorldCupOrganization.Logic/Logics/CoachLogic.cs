using System;
using System.Collections.Generic;
using WorldCupOrganization.DataAccess.Interfaces.Contracts;
using WorldCupOrganization.DataAccess.Interfaces.Errors;
using WorldCupOrganization.Domain.Entities;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.Logic.Interfaces.Errors;

namespace WorldCupOrganization.Logic.Logics
{
    public class CoachLogic : ICoachLogic
    {
        private readonly ICoachRepository coachRepository;

        public CoachLogic(ICoachRepository coachRepository)
        {
            this.coachRepository = coachRepository;
        }

        public List<Coach> GetAllCoaches()
        {
            return coachRepository.GetAllCoaches();
        }

        public Coach CreateCoach(Coach coach)
        {
            try
            {
                return this.coachRepository.AddCoach(coach);
            }
            catch (QueryException ex)
            {
                throw new InterruptedActionException(ex);
            }
            catch (UnexpectedDataAccessException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

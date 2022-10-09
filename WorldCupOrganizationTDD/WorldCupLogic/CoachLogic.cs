using System;
using WorldCupDomain.InModels;

namespace WorldCupLogic
{
    public class CoachLogic
    {
        private ICoachRepository @object;

        public CoachLogic(ICoachRepository @object)
        {
            this.@object = @object;
        }

        public object CreateCoach(Coach expectedCoach)
        {
            throw new NotImplementedException();
        }
    }
}
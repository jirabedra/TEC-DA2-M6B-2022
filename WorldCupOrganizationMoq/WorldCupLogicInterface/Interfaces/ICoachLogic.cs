using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupDomain;

namespace WorldCupLogicInterface.Interfaces
{
    public interface ICoachLogic
    {
        public Coach CreateCoach(Coach coach);
    }
}

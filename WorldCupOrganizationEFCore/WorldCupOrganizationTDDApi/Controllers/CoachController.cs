using Microsoft.AspNetCore.Mvc;
using WorldCupDomain.InModels;
using WorldCupLogicInterface.Interfaces;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WorldCupApi.Controllers
{
    [Route("api/coaches")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private ICoachLogic coachLogic;

        public CoachController(ICoachLogic someCoachLogic)
        {
            coachLogic = someCoachLogic;
        }

   
        [HttpPost]
        public IActionResult AddCoach([FromBody] Coach aCoach)
        {
                coachLogic.CreateCoach(aCoach);
                return new OkObjectResult(aCoach);
        }

        
    }
}

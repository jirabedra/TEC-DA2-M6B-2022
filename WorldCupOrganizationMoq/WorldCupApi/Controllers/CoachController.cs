using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using WorldCupDomain.InModels;
using WorldCupLogic.Logics;
using WorldCupLogicInterface.Interfaces;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WorldCupApi.Controllers
{
    [Route("api/coachs")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private ICoachLogic coachLogic;

        public CoachController(ICoachLogic someCoachLogic)
        {
            coachLogic = someCoachLogic;
        }

   
        [HttpPost]
        public IActionResult AddPlayer([FromBody] Coach aCoach)
        {
                coachLogic.CreateCoach(aCoach);
                return OkObjectResult(aCoach);
        }

        
    }
}

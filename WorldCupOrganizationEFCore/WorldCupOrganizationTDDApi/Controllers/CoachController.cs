using Microsoft.AspNetCore.Mvc;
using WorldCupOrganization.Domain.Entities;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.WebApi.Models.InModels;
using WorldCupOrganization.WebApi.Models.OutModels;

namespace WorldCupOrganization.WebApi.Controllers
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
        public IActionResult AddCoach([FromBody] CoachInModel aCoach)
        {
                Coach result = coachLogic.CreateCoach(aCoach.ToEntity());
                return new OkObjectResult(new CoachOutModel(result));
        }

        
    }
}

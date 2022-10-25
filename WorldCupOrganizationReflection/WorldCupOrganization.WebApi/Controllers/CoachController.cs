using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WorldCupOrganization.Domain.Entities;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.Logic.Interfaces.Errors;
using WorldCupOrganization.WebApi.Filters;
using WorldCupOrganization.WebApi.Models.InModels;
using WorldCupOrganization.WebApi.Models.OutModels;

namespace WorldCupOrganization.WebApi.Controllers
{
    [Route("api/coaches")]
    [WebApiExceptionFilter]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private ICoachLogic coachLogic;

        public CoachController(ICoachLogic someCoachLogic)
        {
            coachLogic = someCoachLogic;
        }

        [HttpGet]
        public IActionResult GetAllCoaches()
        {
            return new OkObjectResult(coachLogic.GetAllCoaches());
        }

        [AuthenticationFilter]
        [HttpPost]
        public IActionResult AddCoach([FromBody] CoachInModel aCoach)
        {
            var adminId = this.HttpContext.Items["adminId"];
            

            Coach result = coachLogic.CreateCoach(aCoach.ToEntity());
            return new OkObjectResult(new CoachOutModel(result));
        }


    }
}

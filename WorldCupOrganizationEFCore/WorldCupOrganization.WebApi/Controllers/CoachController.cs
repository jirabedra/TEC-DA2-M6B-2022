using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WorldCupOrganization.Domain.Entities;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.Logic.Interfaces.Errors;
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
            try
            {
                Coach result = coachLogic.CreateCoach(aCoach.ToEntity());
                return new OkObjectResult(new CoachOutModel(result));
            }
            catch (InterruptedActionException iex)
            {
                return BadRequest(iex.Message);
            }
            catch (Exception iex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, iex.Message);
            }
        }


    }
}

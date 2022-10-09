using Microsoft.AspNetCore.Mvc;
using System;
using WorldCupOrganization.Domain.Entities;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.WebApi.Models.InModels;
using WorldCupOrganization.WebApi.Models.OutModels;

namespace WorldCupOrganization.WebApi.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private IPlayerLogic playerLogic;

        public PlayerController(IPlayerLogic somePlayerLogic)
        {
            playerLogic = somePlayerLogic;
        }

        // http://localhost:5152/api/players?name=Lionel&lastname=Messi&country=Argentina
        [HttpGet]
        public IActionResult GetPlayer([FromQuery] string name, [FromQuery] string lastName, 
            [FromQuery] string country)
        {
            try
            {
                PlayerInModel newPlayer = new PlayerInModel()
                {
                    Name = name,
                    LastName = lastName,
                    Country = country
                };
                Player player = playerLogic.GetPlayer(newPlayer.ToEntity());

                return new OkObjectResult(new PlayerOutModel(player));
            } catch ( Exception ex )
            {
                return BadRequest();
            }
        }


        /*
         *
         *{
"name" : "Lionel",
"lastname" : "Messi",
"country" : "Argentina"
}
        */
        [HttpPost]
        public IActionResult AddPlayer([FromBody] PlayerInModel player)
        {
            try
            {
                var result = playerLogic.AddPlayer(player.ToEntity());

                return new OkObjectResult(new PlayerOutModel(result));
            } catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpDelete("lastName")]
        public IActionResult DeletePlayer([FromRoute] string lastName)
        {
            try
            {
                playerLogic.DeletePlayer(lastName);
                return Ok("All good");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}

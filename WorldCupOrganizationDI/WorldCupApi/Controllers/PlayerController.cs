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
                var player = playerLogic.GetPlayer(new PlayerInModel()
                {
                    Name = name,
                    LastName = lastName,
                    Country = country
                });
                return new OkObjectResult(player);
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
                playerLogic.AddPlayer(player);
                return Ok();
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
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WorldCupOrganization.Logic.Interfaces.Contracts;
using WorldCupOrganization.WebApi.Filters;
using WorldCupOrganization.WebApi.Models.InModels;

namespace WorldCupOrganization.WebApi.Controllers
{
    [WebApiExceptionFilter]
    [ApiController]
    [Route("api/sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionLogic sessionLogic;

        public SessionController(ISessionLogic aSessionLogic)
        {
            sessionLogic = aSessionLogic;
        }

        [HttpPost]
        public IActionResult Login([FromBody] ModelLogin aModelLoginAdmin)
        {
            return Ok(sessionLogic.Login(aModelLoginAdmin.Mail, aModelLoginAdmin.Password));
        }
    }
}

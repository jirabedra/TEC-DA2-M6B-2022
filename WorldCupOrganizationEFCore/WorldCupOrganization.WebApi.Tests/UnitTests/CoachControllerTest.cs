using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WorldCupOrganization.Domain.Entities;
using WorldCupOrganization.Interfaces.Contracts;
using WorldCupOrganization.WebApi.Controllers;
using WorldCupOrganization.WebApi.Models.InModels;
using WorldCupOrganization.WebApi.Models.OutModels;

namespace Webapi.Tests.UnitTests
{
    [TestClass]
    public class CoachControllerTest
    {
        [TestMethod]
        public void PostCoachTest()
        {
            //Arrange
            Coach resultCoach = new Coach()
            {
                Id = 5,
                Name = "Diego Alonso"
            };
            CoachInModel infoCoach = new CoachInModel()
            {
                Name = "Diego Alonso"
            };
            CoachOutModel expectedCoach = new CoachOutModel(resultCoach);
            var aCoachLogicMock = new Mock<ICoachLogic>(MockBehavior.Strict);
            var controller = new CoachController(aCoachLogicMock.Object);
            aCoachLogicMock.Setup(m => m.CreateCoach(It.IsAny<Coach>())).Returns(Coach resultCoach = new Coach()
);

            //Act
            var resultCall = controller.AddCoach(infoCoach);

            aCoachLogicMock.VerifyAll();
            var result = resultCall as OkObjectResult;
            var resultObject = result.Value as CoachOutModel;
            //Assert
            Assert.AreEqual(expectedCoach, resultObject); //en realidad deberíamos redefinir el Equals
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WorldCupApi.Controllers;
using WorldCupDomain.InModels;
using WorldCupLogicInterface.Interfaces;

namespace Webapi.Tests.test
{
    [TestClass]
    public class CoachControllerTest
    {
        [TestMethod]
        public void PostCoachTest()
        {
            //Arrange
            Coach expectedCoach = new Coach()
            {
                Id = 5,
                Name = "Diego Alonso"
            };
            var aCoachLogicMock = new Mock<ICoachLogic>(MockBehavior.Strict);
            var controller = new CoachController(aCoachLogicMock.Object);
            //aCoachLogicMock.Setup(m => m.CreateCoach(It.IsAny<Coach>())).Returns(expectedCoach);

            //Act
            var resultCall = controller.AddCoach(expectedCoach);

            aCoachLogicMock.VerifyAll();
            var result = resultCall as OkObjectResult;
            var resultCoach = result.Value as Coach;
            //Assert
            Assert.AreEqual(expectedCoach.Name,resultCoach.Name); //en realidad deberíamos redefinir el Equals
        }
    }
}

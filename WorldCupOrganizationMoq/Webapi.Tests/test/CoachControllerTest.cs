using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Webapi.Tests.test
{
    [TestClass]
    public class CoachControllerTest
    {
        [TestMethod]
        public void PostCoachTest()
        {
            //AAA
            Coach expectedCoach = new Coach()
            {
                Id = 5,
                Name = "Pepito"
            };
            var aCoachLogicMock = new Mock<ICoachLogic>(MockBehavior.Strict);
            var controller = new CoachController(aCoachLogicMock.Object);
            aCoachLogicMock.Setup(m => m.CreateCoach(It.IsAny<Coach>())).Returns(expectedCoach);

            var resultCall = controller.PostCoach(expectedCoach);

            aCoachLogicMock.VerifyAll();
            var result = resultCall as OkObjectResult;
            var resultCoach = result.Value as Coach;
            Assert.AreEqual(expectedCoach.Name,resultCoach.Name);
        }
    }
}

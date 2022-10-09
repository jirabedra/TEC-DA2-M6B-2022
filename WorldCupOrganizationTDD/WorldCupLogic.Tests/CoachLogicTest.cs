using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WorldCupDomain.InModels;

namespace WorldCupLogic.Tests
{
    [TestClass]
    public class CoachLogicTest
    {
        [TestMethod]
        public void TestCreateCoachCorrectCase()
        {
            Coach expectedCoach = new Coach()
            {
                Id = 5,
                Name = "Diego Alonso"
            };

            var aCoachRepositoryMock = new Mock<ICoachRepository>(MockBehavior.Strict);
            aCoachRepositoryMock.Setup(m => m.CreateCoach(It.IsAny<Coach>())).Returns(expectedCoach);

            var aCoachLogic = new CoachLogic(aCoachRepositoryMock.Object);

            var result = aCoachLogic.CreateCoach(expectedCoach);

            aCoachRepositoryMock.VerifyAll();
            Assert.AreEqual(expectedCoach.Name, result.Name); //en realidad deberíamos redefinir el Equals
        }
    }
}

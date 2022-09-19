using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using WorldCupOrganization.DataAccess.Interfaces.Contracts;
using WorldCupOrganization.DataAccess.Interfaces.Errors;
using WorldCupOrganization.Domain.Entities;
using WorldCupOrganization.Logic.Interfaces.Errors;
using WorldCupOrganization.Logic.Logics;

namespace WorldCupOrganization.Logic.Tests.UnitTests
{
    [TestClass]
    public class CoachLogicTests
    {
        [TestMethod]
        public void TestAddCoachCorrect()
        {

            var newCoach = new Coach()
            {
                Name = "Carlos"
            };
            var expectedCoach = new Coach()
            {
                Id = 1,
                Name = "Carlos"
            };

            var coachRepository = new Mock<ICoachRepository>(MockBehavior.Strict);
            coachRepository.Setup(x => x.AddCoach(It.IsAny<Coach>())).Returns(expectedCoach);
            var coachLogic = new CoachLogic(coachRepository.Object);

            var result = coachLogic.CreateCoach(newCoach);

            coachRepository.VerifyAll();
            Assert.AreEqual(result, expectedCoach);
        }

        [TestMethod]
        public void TestAddCoachWithDataAccessException()
        {

            var newCoach = new Coach()
            {
                Name = "Carlos"
            };
            var expectedCoach = new Coach()
            {
                Id = 1,
                Name = "Carlos"
            };

            var coachRepository = new Mock<ICoachRepository>(MockBehavior.Strict);
            coachRepository.Setup(x => x.AddCoach(It.IsAny<Coach>())).Throws(new QueryException(new Exception()));
            var coachLogic = new CoachLogic(coachRepository.Object);

            //Act & Assert
            Assert.ThrowsException<InterruptedActionException>(() => coachLogic.CreateCoach(newCoach));
            coachRepository.VerifyAll();
        }

        [TestMethod]
        public void TestAddCoachWithDataAccessUnexpectedException()
        {

            var newCoach = new Coach()
            {
                Name = "Carlos"
            };
            var expectedCoach = new Coach()
            {
                Id = 1,
                Name = "Carlos"
            };

            var coachRepository = new Mock<ICoachRepository>(MockBehavior.Strict);
            coachRepository.Setup(x => x.AddCoach(It.IsAny<Coach>())).Throws(new UnexpectedDataAccessException(new Exception()));
            var coachLogic = new CoachLogic(coachRepository.Object);

            //Act & Assert
            Assert.ThrowsException<Exception>(() => coachLogic.CreateCoach(newCoach));
            coachRepository.VerifyAll();
        }
    }
}

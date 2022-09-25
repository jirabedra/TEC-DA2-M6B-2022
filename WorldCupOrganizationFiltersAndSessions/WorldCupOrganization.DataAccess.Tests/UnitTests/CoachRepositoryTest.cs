using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldCupOrganization.DataAccess.Context;
using WorldCupOrganization.DataAccess.Repositories;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.DataAccess.Tests.UnitTests
{
    [TestClass]
    public class CoachRepositoryTest
    {
        [TestMethod]
        public void TestAddAdminCorrect()
        {
            var context = GetMemoryContext("MemoryTestAddAdminDB");
            Coach aCoach = new Coach()
            {
                Id = 1,
                Name = "anAdmin",
            };
            CoachRepository coachRepository = new CoachRepository(context);

            coachRepository.AddCoach(aCoach);

            //TODO: Ver video 
            Assert.AreEqual(aCoach, context.Coaches.FirstOrDefault(a => a.Id == 1));
        }

        private WorldCupOrganizationContext GetMemoryContext(string nameBd)
        {
            var builder = new DbContextOptionsBuilder<WorldCupOrganizationContext>();
            return new WorldCupOrganizationContext(GetMemoryConfig(builder, nameBd));
        }

        private DbContextOptions GetMemoryConfig(DbContextOptionsBuilder builder, string nameBd)
        {
            builder.UseInMemoryDatabase(nameBd);
            return builder.Options;
        }
    }
}

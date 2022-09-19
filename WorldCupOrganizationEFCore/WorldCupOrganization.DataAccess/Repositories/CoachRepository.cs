using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WorldCupOrganization.DataAccess.Interfaces.Contracts;
using WorldCupOrganization.DataAccess.Interfaces.Errors;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.DataAccess.Repositories
{
    public class CoachRepository : ICoachRepository
    {
        private readonly DbContext Context;

        public CoachRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public Coach AddCoach(Coach coach)
        {
            try
            {
                Context.Set<Coach>().Add(coach);
                Context.SaveChanges();
                return coach;
            }
            catch (SqlException s)
            {
                throw new QueryException(s);
            }
            catch (Exception e)
            {
                throw new UnexpectedDataAccessException(e);
            }
        }
    }
}

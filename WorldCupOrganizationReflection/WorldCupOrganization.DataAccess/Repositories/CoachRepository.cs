using System;
using System.Collections.Generic;
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

        public List<Coach> GetAllCoaches()
        {
            return new List<Coach>()
            {
                new Coach
                {
                    Id = 1,
                    Name = "Juan"
                },
                new Coach
                {
                    Id = 2,
                    Name = "Santi"

                },
                new Coach
                {
                    Id = 3,
                    Name = "Paula"
                }
            };
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

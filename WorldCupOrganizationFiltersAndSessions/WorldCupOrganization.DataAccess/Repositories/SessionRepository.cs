using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WorldCupOrganization.DataAccess.Interfaces.Contracts;
using WorldCupOrganization.DataAccess.Interfaces.Errors;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.DataAccess.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly DbContext Context;

        public SessionRepository(DbContext dbContext)
        {
            Context = dbContext;
        }

        public SessionState Add(SessionState aSession)
        {
            try
            {
                Context.Set<SessionState>().Add(aSession);
                Context.SaveChanges();
                return aSession;
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

        public bool Exist(Func<SessionState, bool> func)
        {
            try
            {
                return Context.Set<SessionState>().Where(func).Any();
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

        public SessionState Get(Func<SessionState, bool> func)
        {
            try
            {
                return Context.Set<SessionState>().FirstOrDefault(func);
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

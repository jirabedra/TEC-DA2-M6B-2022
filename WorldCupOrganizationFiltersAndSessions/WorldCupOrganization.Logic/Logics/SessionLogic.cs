using System;
using WorldCupOrganization.DataAccess.Interfaces.Contracts;
using WorldCupOrganization.DataAccess.Interfaces.Errors;
using WorldCupOrganization.Domain.Entities;
using WorldCupOrganization.Logic.Interfaces;
using WorldCupOrganization.Logic.Interfaces.Contracts;
using WorldCupOrganization.Logic.Interfaces.Errors;

namespace WorldCupOrganization.Logic.Logics
{
    public class SessionLogic : ISessionLogic
    {
        private readonly ISessionRepository sessionRepository;

        public SessionLogic(ISessionRepository aSessionRepository)
        {
             sessionRepository =aSessionRepository;
        }

        public int GetAdminIdFromToken(Guid aToken)
        {
            try
            {
                if (sessionRepository.Exist(TokenPredicate(aToken)))
                {
                    throw new NotExistElementException("No existe el token");
                }
                var session = sessionRepository.Get(TokenPredicate(aToken));
                return session.AnAdmin.Id;
            }
            catch (QueryException q)
            {
                throw new InterruptedActionException(q);
            }
            catch (UnexpectedDataAccessException u)
            {
                throw new InterruptedActionException(u);
            }
        }

        public bool IsValidToken(Guid aToken)
        {
            try
            {
                return sessionRepository.Exist(TokenPredicate(aToken));
            }
            catch (QueryException q)
            {
                throw new InterruptedActionException(q);
            }
            catch (UnexpectedDataAccessException u)
            {
                throw new InterruptedActionException(u);
            }
        }


        public Guid Login(string mail, string password)
        {
            try
            {
                SessionState aSession;
                
                if (sessionRepository.Exist(ExistAdmin(mail,password)))
                {

                    aSession = sessionRepository.Get(RelatedTokenPredicate(mail));
                }
                else if (sessionRepository.Exist(RelatedTokenPredicate(mail)))
                {
                    throw new NotExistElementException("Wrong password or mail");
                }
                else
                {
                    aSession = new SessionState()
                    {
                        Token = Guid.NewGuid(),
                        AnAdmin = new Admin()
                        {
                            Mail = mail,
                            Password = password
                        }
                    };
                    sessionRepository.Add(aSession);
                }
                return aSession.Token;
            }
            catch (QueryException q)
            {
                throw new InterruptedActionException(q);
            }
            catch (UnexpectedDataAccessException u)
            {
                throw new InterruptedActionException(u);
            }
        }


        private Func<SessionState, bool> ExistAdmin(string mail, string password)
        {
            return s => s.AnAdmin.Mail == mail && s.AnAdmin.Password == password;
        }

        private Func<SessionState, bool> RelatedTokenPredicate(string mail)
        {
            return s => s.AnAdmin.Mail == mail;
        }

        private Func<SessionState, bool> TokenPredicate(Guid aToken)
        {
            return s => s.Token == aToken;
        }

    }
}

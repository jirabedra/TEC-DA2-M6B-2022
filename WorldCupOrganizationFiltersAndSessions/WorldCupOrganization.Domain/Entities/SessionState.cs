using System;

namespace WorldCupOrganization.Domain.Entities
{
    public class SessionState
    {
        public SessionState()
        {
        }
        public int Id { get; set; }
        public Guid Token { get; set; }
        public Admin AnAdmin { get; set; }
    }
}
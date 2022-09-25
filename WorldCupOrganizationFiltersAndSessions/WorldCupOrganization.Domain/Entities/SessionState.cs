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
        public virtual Admin AnAdmin { get; set; }
    }
}
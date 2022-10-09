namespace WorldCupOrganization.Domain.Entities
{
    public class Admin
    {
        public Admin()
        {
        }

        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
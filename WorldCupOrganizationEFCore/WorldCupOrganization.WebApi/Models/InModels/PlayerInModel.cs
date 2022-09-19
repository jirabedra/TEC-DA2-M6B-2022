using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.WebApi.Models.InModels
{
    public class PlayerInModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

        public Player ToEntity()
        {
            return new Player()
            {
                Name = this.Name,
                LastName = this.LastName,
                Country = this.Country
            };
        }
    }
}

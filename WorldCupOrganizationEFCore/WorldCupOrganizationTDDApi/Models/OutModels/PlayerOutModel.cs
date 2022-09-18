using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.WebApi.Models.OutModels
{
    public class PlayerOutModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }

        public PlayerOutModel(Player player)
        {
            this.Id = player.Id;
            this.Name = player.Name;
            this.LastName = player.LastName;
            this.Country = player.Country;
        }
    }
}

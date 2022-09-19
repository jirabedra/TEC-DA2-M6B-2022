using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.WebApi.Models.InModels
{
    public class CoachInModel
    {
        public string Name { get; set; }

        public Coach ToEntity()
        {
            return new Coach()
            {
                Name = Name
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupOrganization.Domain.Entities
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            bool result = obj is Coach;
            if (result)
            {
                //Esto ayuda a ver en que linea dio distinto el equals :)
                var coach = obj as Coach;
                result = Id == coach.Id;
                result = result && Name.Equals(coach.Name);
            }
            return result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }
}

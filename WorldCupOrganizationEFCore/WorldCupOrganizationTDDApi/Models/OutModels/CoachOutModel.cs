using WorldCupOrganization.Domain.Entities;

namespace WorldCupOrganization.WebApi.Models.OutModels
{
    public class CoachOutModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CoachOutModel(Coach aCoach)
        {
            this.Id = aCoach.Id;
            this.Name = aCoach.Name;
        }

        public override bool Equals(object obj)
        {
            bool result = obj is CoachOutModel;
            if (result)
            {
                //Esto ayuda a ver en que linea dio distinto el equals :)
                var coach = obj as CoachOutModel;
                result = Id == coach.Id;
                result = result && Name.Equals(coach.Name);
            }
            return result;
        }

    }
}

using System.ComponentModel.DataAnnotations;

namespace ApplicantsFromProject.Models
{
    public class Governorate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ApplicantsFrom>? ApplicantsFroms { get; set; }

    }
}

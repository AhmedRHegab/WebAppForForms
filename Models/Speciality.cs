using ApplicantsFromProject.Models;
using System.ComponentModel.DataAnnotations;

namespace NewFormsProject.Models
{
    public class Speciality
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ApplicantsFrom>? ApplicantsFroms { get; set; }
    }
}

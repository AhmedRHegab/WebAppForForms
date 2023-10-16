

using NewFormsProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ApplicantsFromProject.Models
{
    public class ApplicantsFrom
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Governorate")]
        public int GovernorateId { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }
        [ForeignKey("University")]
        public int UniversityId { get; set; }

        public string Name_En { get; set; }
        public string Mobile { get; set; }
        [AllowNull]
        public string? Github_Link { get; set; }
        [AllowNull]
        public string? LinkedIn_Link { get; set; }
        public bool ITI_Graduate { get; set; }
        [AllowNull]
        public string? year_Of_Graduation { get; set; }
        public University? University { get; set; }
        public Governorate? Governorate { get; set; }
        public Faculty? Faculty { get; set; }
        public string Graduation_Year { get; set; }
        [AllowNull]
        public string? Current_Company { get; set; }
        [AllowNull]
        public string? Current_Salary { get; set; }
        public string Expected_Salary { get; set; }
        public DateTime Availability_Date { get; set; }
        public bool Interested_Working_In_Cairo { get; set; }
        public bool Mobile_Apps_Experience { get; set; }
        public bool E_Commerce_Apps_Experience { get; set; }
        [AllowNull]
        public string? CV { get; set; }
        [NotMapped]
        [AcceptPdf(ErrorMessage = "Only PDF files are allowed.")]
        public IFormFile CVFile { get; set; }

        [ForeignKey("Speciality")]
        public int SpecialityId { get; set; }
        public Speciality? Speciality { get; set; }



    }


    public class AcceptPdfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;

            if (file != null)
            {
                if (file.ContentType != "application/pdf")
                {
                    return new ValidationResult("Only PDF files are allowed.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

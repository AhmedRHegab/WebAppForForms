namespace ApplicantsFromProject.Models
{
    public class ApplicantsFormViewModel
    {
        public string Name_En { get; set; }
        public string Mobile { get; set; }
        public string Github_Link { get; set; }
        public string LinkedIn_Link { get; set; }
        public bool ITI_Graduate { get; set; }
        public string Year_Of_Graduation { get; set; }
        public string University { get; set; }
        public string Governorate { get; set; }
        public string Graduation_Year { get; set; }
        public string Current_Company { get; set; }
        public string Current_Salary { get; set; }
        public string Expected_Salary { get; set; }
        public DateTime Availability_Date { get; set; }
        public bool Interested_Working_In_Cairo { get; set; }
        public bool Mobile_Apps_Experience { get; set; }
        public bool E_Commerce_Apps_Experience { get; set; }
        public IFormFile CV { get; set; }
        public string Speciality { get; set; }
    }
}

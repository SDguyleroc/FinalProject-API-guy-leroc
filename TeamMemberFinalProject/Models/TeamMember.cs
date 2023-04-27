using Microsoft.EntityFrameworkCore;


namespace FinalProject.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CollegeProgram { get; set; }
        public string YearInProgram { get; set; }
        
    }
}

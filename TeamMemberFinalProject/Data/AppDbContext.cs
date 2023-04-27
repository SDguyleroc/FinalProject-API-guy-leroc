using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace TeamMemberFinalProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set;}
        public DbSet<FavoriteBreakFast> FavoriteBreakFasts { get;set; }
        public DbSet<Address> Address { get; set; }
       
    }
}

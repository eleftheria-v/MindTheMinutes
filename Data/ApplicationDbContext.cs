using Meeting_Minutes.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting_Minutes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RiskLevel> RiskLevels { get; set; }
        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<MeetingParticipant> MeetingsParticipants { get; set; }
        public DbSet<MeetingItem> MeetingItems { get; set; }
        public DbSet<ListValue> ListValues { get; set; }
        public DbSet<ListType> ListTypes { get; set; }
    
        public DbSet<FollowUp> FollowUps { get; set; }
        //public DbSet<ErrorViewModel> ErrorViewModels { get; set; }



    }
}

using CollegeMath.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollegeMath.Infra.Context
{
    public class CollegeMathContext : IdentityDbContext<ApplicationUser>
    {
        public CollegeMathContext(DbContextOptions<CollegeMathContext> options) : base(options)
        {

        }
        //public DbSet<User> Usuarios { get; set; }

        public DbSet<Content> Contents { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Alternative> Alternatives { get; set; }

        public DbSet<ImageQuestion> ImageQuestion { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<UserQuestionHistory> UserQuestionHistory { get; set; }

        public DbSet<Solution> Solutions { get; set; }

        public DbSet<ImageSolution> ImageSolution { get; set; }
    }
}

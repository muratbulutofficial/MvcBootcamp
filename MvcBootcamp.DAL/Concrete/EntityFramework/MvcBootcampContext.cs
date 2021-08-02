using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Concrete.EntityFramework
{
    public class MvcBootcampContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Headline> Headlines { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Skill> Skills { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(c => c.Nickname).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Author>().Property(c => c.Image).HasMaxLength(100).IsOptional();
            modelBuilder.Entity<Author>().Property(c => c.EMail).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Author>().Property(c => c.Password).HasMaxLength(300).IsRequired();
            modelBuilder.Entity<Author>().Property(c => c.PasswordSalt).HasMaxLength(150).IsOptional();
            modelBuilder.Entity<Author>().Property(c => c.About).HasMaxLength(200).IsOptional();
            modelBuilder.Entity<Author>().Property(c => c.IpAddress).HasMaxLength(15).IsOptional();
            modelBuilder.Entity<Author>().Property(c => c.LastLoginDate).IsOptional();
            modelBuilder.Entity<Author>().Property(c => c.RegisterDate).IsOptional();
            modelBuilder.Entity<Author>().Property(c => c.IsActive).IsOptional();

            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.SeoUrl).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Description).HasMaxLength(100).IsOptional();

            modelBuilder.Entity<Content>().Property(c => c.Text).HasMaxLength(5000).IsRequired();

            modelBuilder.Entity<Headline>().Property(c => c.Text).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Headline>().Property(c => c.SeoUrl).HasMaxLength(300).IsRequired();

            modelBuilder.Entity<UserLevel>().Property(c => c.LevelName).HasMaxLength(10).IsRequired();

            modelBuilder.Entity<Message>().Property(c => c.Name).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Message>().Property(c => c.Surname).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Message>().Property(c => c.EMail).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Message>().Property(c => c.Subject).HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Message>().Property(c => c.Text).HasMaxLength(500).IsRequired();

            modelBuilder.Entity<Skill>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Skill>().Property(c => c.PerValue).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Skill>().Property(c => c.Value).HasMaxLength(50).IsRequired();
            
            

        }
    }
}

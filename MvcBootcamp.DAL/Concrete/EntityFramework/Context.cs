using MvcBootcamp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcBootcamp.DAL.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Headline> Headlines { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(c => c.Nickname).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Author>().Property(c => c.Image).HasMaxLength(100).IsOptional();
            modelBuilder.Entity<Author>().Property(c => c.EMail).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Author>().Property(c => c.Password).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Category>().Property(c => c.Description).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<ContactForm>().Property(c => c.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ContactForm>().Property(c => c.EMail).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<ContactForm>().Property(c => c.Subject).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ContactForm>().Property(c => c.Message).HasMaxLength(300).IsRequired();

            modelBuilder.Entity<Content>().Property(c => c.Text).HasMaxLength(500).IsRequired();

            modelBuilder.Entity<Headline>().Property(c => c.Text).HasMaxLength(100).IsRequired();
        }
    }
}

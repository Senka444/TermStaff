using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TermStaff.Models
{
    public partial class DB : DbContext
    {
        private static DB _instance;
        public static DB Instance
        {
            get { return _instance ?? (_instance = new DB()); }
        }

        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Departamen> Departamen { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamen>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Departamen)
                .HasForeignKey(e => e.IdDepartament);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Application)
                .WithOptional(e => e.Group)
                .HasForeignKey(e => e.IdGroup);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.IdRole);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Application)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.IdStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Unit)
                .HasForeignKey(e => e.IdUnit);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Group)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.IdPos);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Group1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.IdSotr);
        }
    }
}

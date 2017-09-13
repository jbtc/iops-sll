using System.Data.Entity;
using iOps.Core.Model;

namespace iOps.Data
{
    public class Db : DbContext
    {
        public Db() : base("iopsContext")
        {
            try
            {
                Database.SetInitializer<Db>(null);
                Database.Connection.Open();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Organizations_ContactInformation> Organizations_ContactInformations { get; set; }
        public DbSet<Salutation> Salutations { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<SecurityGroup> SecurityGroups { get; set; }
        public DbSet<SecurityRole> SecurityRoles { get; set; }
        public DbSet<SecurityTask> SecurityTasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Users_ContactInformation> Users_ContactInformations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /* Setup for ControlField-XML Parsing into ControlData object */
            modelBuilder.Entity<Country>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<Country>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<Feedback>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<Feedback>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<History>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<History>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<Organization>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<Organization>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<Organizations_ContactInformation>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<Organizations_ContactInformation>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<Salutation>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<Salutation>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<Screen>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<Screen>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<SecurityGroup>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<SecurityGroup>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<SecurityRole>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<SecurityRole>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<SecurityTask>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<SecurityTask>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<User>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<User>().Ignore(c => c.ControlFields);
            modelBuilder.Entity<Users_ContactInformation>().Property(c => c.ControlField).HasColumnType("xml");
            modelBuilder.Entity<Users_ContactInformation>().Ignore(c => c.ControlFields);

			// Organization->Organizations_ContactInformation(1-n)
			modelBuilder.Entity<Organizations_ContactInformation>().HasRequired<Organization>(s => s.Organization)
            .WithMany(s => s.Organizations_ContactInformation).HasForeignKey(s => s.OrganizationID);

			// Country-Organizations_ContactInformation(1-n)
			modelBuilder.Entity<Organizations_ContactInformation>().HasRequired<Country>(s => s.Country)
            .WithMany(s => s.Organizations_ContactInformation).HasForeignKey(s => s.CountryID);

			// Organization-User(n-n)
            modelBuilder.Entity<Organization>().HasMany(r => r.Users).WithMany(o => o.Organizations).Map(f =>
            {
                f.ToTable("OrganizationsXrefUsers");
                f.MapLeftKey("OrganizationID");
                f.MapRightKey("UserID");
            });

			// Salutation-User(1-n)
			modelBuilder.Entity<User>().HasRequired<Salutation>(s => s.Salutation)
            .WithMany(s => s.Users).HasForeignKey(s => s.SalutationID);

			// User-Users_ContactInformation(1-n)
			modelBuilder.Entity<Users_ContactInformation>().HasRequired<User>(s => s.User)
            .WithMany(s => s.Users_ContactInformation).HasForeignKey(s => s.UserID);

			// Country-Users_ContactInformation(1-n)
			modelBuilder.Entity<Users_ContactInformation>().HasRequired<Country>(s => s.Country)
            .WithMany(s => s.Users_ContactInformation).HasForeignKey(s => s.CountryID);

            // User-SecurityGroups(n-n)
            modelBuilder.Entity<User>().HasMany(r => r.SecurityGroups).WithMany(o => o.Users).Map(f =>
            {
                f.ToTable("UsersXrefSecurityGroups");
                f.MapLeftKey("UserId");
                f.MapRightKey("SecurityGroupId");
            });

            // User-SecurityRoles(n-n)
            modelBuilder.Entity<User>().HasMany(r => r.SecurityRoles).WithMany(o => o.Users).Map(f =>
            {
                f.ToTable("UsersXrefSecurityRoles");
                f.MapLeftKey("UserId");
                f.MapRightKey("SecurityRoleId");
            });

            // User-SecurityTasks(n-n)
            modelBuilder.Entity<User>().HasMany(r => r.SecurityTasks).WithMany(o => o.Users).Map(f =>
            {
                f.ToTable("UsersXrefSecurityTasks");
                f.MapLeftKey("UserId");
                f.MapRightKey("SecurityTaskId");
            });


            // SecurityGroups-SecurityRoles(n-n)
            modelBuilder.Entity<SecurityGroup>().HasMany(r => r.SecurityRoles).WithMany(o => o.SecurityGroups).Map(f =>
            {
                f.ToTable("SecurityGroupsXrefSecurityRoles");
                f.MapLeftKey("SecurityGroupID");
                f.MapRightKey("SecurityRoleId");
            });

            // SecurityGroups-SecurityTasks(n-n)
            modelBuilder.Entity<SecurityGroup>().HasMany(r => r.SecurityTasks).WithMany(o => o.SecurityGroups).Map(f =>
            {
                f.ToTable("SecurityGroupsXrefSecurityTasks");
                f.MapLeftKey("SecurityGroupID");
                f.MapRightKey("SecurityTaskID");
            });

            // SecurityRoles-SecurityTasks(n-n)
            modelBuilder.Entity<SecurityRole>().HasMany(r => r.SecurityTasks).WithMany(o => o.SecurityRoles).Map(f =>
            {
                f.ToTable("SecurityRolesXrefSecurityTasks");
                f.MapLeftKey("SecurityRoleID");
                f.MapRightKey("SecurityTaskID");
            });

            /*User-Screen(n-n) (Bridge Table) */
            modelBuilder.Entity<UsersXrefScreen>()
                .HasKey(l => new { l.UserID, l.ScreenID });
            modelBuilder.Entity<User>().HasMany(r => r.UsersXrefScreens);
            modelBuilder.Entity<Screen>().HasMany(r => r.UsersXrefScreens);

            base.OnModelCreating(modelBuilder);
        }
    }
}
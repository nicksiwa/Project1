using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCInBuiltFeatures.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<MVCInBuiltFeatures.Models.Medicine> Medicines { get; set; }

        public System.Data.Entity.DbSet<MVCInBuiltFeatures.Models.Appointment> Appointments { get; set; }

        public System.Data.Entity.DbSet<MVCInBuiltFeatures.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<MVCInBuiltFeatures.Models.SResult> SResults { get; set; }
    }
}
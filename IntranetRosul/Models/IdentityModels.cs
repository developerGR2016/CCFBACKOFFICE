using System.Collections;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IntranetRosul.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {


        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public int cod_empleado { get; set; }
        public virtual Sistema Sistemas { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here

            return userIdentity;
        }

      
    }

  
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
     
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
     
        public System.Data.Entity.DbSet<IntranetRosul.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.permiso> permisoes { get; set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.Sistema> Sistemas { get; set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.ARole> ARoles { get; set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.AsignarPermiso> AsignarPermisoes { get; set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.AsignarSistemaUsuario> AsignarSistemaUsuarios { get; set; }
        public IEnumerable ApplicationUsers { get; internal set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.Menu> Menus { get; set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.Opcion> Opcions { get; set; }

      
        public System.Data.Entity.DbSet<IntranetRosul.Models.NotificacionPago> NotificacionPagoes { get; set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.AsignarRolSistema> AsignarRolSistemas { get; set; }

        public System.Data.Entity.DbSet<IntranetRosul.Models.notificacionRetencion> notificacionRetencions { get; set; }
    }
}
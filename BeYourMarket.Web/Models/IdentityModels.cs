using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using BeYourMarket.Model.Models;

namespace BeYourMarket.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        // Properties                        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string RegisterIP { get; set; }
        public DateTime LastAccessDate { get; set; }
        public string LastAccessIP { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool Disabled { get; set; }
        public bool AcceptEmail { get; set; }
        public string Gender { get; set; }
        public int LeadSourceID { get; set; }
        public double Rating { get; set; }
        public int id_TipoCadastro { get; set; }
        public int id_UF { get; set; }
        public int id_Cidade { get; set; }
        public int? Id_UBankDetails { get; set; }
        public string Logradouro_Cidade { get; set; }
        public string Bairro_Cidade { get; set; }
        public string Cep_Bairro_Cidade { get; set; }

        [NotMapped]
        public bool RoleAdministrator { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}".Trim(), FirstName, LastName);
            }
        }

        [NotMapped]
        public string RatingClass
        {
            get
            {
                return "s" + Math.Round(Rating * 2);
            }
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
    }
}
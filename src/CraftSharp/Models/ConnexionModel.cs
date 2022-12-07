using System.ComponentModel.DataAnnotations;

namespace CraftSharp.Models
{
    public class ConnexionModel
    {
        [Required(ErrorMessage = "Le pseudo est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le pseudo est trop long")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le mot de passe est trop long")]
        public string? Password { get; set; }
    }
}

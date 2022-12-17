using System.ComponentModel.DataAnnotations;

namespace CraftSharp.Models
{
    public class ConnexionModel
    {
        [Required(ErrorMessage = "Le pseudo est obligatoire.")]
        [MinLength(4, ErrorMessage = "Le pseudo est trop court")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [MinLength(4, ErrorMessage = "Le mot de passe est trop court")]
        public string? Password { get; set; }
    }
}

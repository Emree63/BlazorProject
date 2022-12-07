using System.ComponentModel.DataAnnotations;

namespace CraftSharp.Models
{
    public class InscriptionModel
    {

        [Required(ErrorMessage = "Le pseudo est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le pseudo est trop long")]
        public string? Pseudo { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères.")]
        [RegularExpression(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$", ErrorMessage = "Le format de l'email n'est pas correcte.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le mot de passe est trop long")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Vous devez confirmer votre mot de passe")]
        [StringLength(50, ErrorMessage = "Le pseudo est trop long")]
        public string? ConfirmPasswd { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CraftSharp.Models
{
    public class InscriptionModel
    {

        [Required(ErrorMessage = "Le pseudo est obligatoire.")]
        [MinLength(4, ErrorMessage = "Le pseudo est trop court")]
        [MaxLength(50, ErrorMessage = "Le pseudo est trop long")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [MinLength(4, ErrorMessage = "Le mot de passe est trop court")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Vous devez confirmer votre mot de passe")]
        [Compare(nameof(Password), ErrorMessage = "Les mot de passe ne correspondent pas!")]
        public string? PasswordConfirm { get; set; }
    }
}
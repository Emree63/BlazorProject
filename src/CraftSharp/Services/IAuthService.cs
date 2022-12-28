using CraftSharp.Models;

namespace CraftSharp.Services
{
    public interface IAuthService
    {
        AppUser GetCurrentUser(string userName);

        CurrentUser GetUser(string userName);

        void Login(ConnexionModel loginRequest);

        void Register(InscriptionModel registerRequest);
    }
}

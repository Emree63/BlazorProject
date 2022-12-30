using CraftSharp.Models;

namespace CraftSharp.Services
{
    public interface IAuthService
    {
        CurrentUser GetUser(string userName);
        void Login(ConnexionModel loginRequest);
        void Register(InscriptionModel registerRequest);
    }
}

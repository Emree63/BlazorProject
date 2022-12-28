using CraftSharp.Models;
using System.Linq;
using System.Security.Claims;

namespace CraftSharp.Services
{
    public class AuthService : IAuthService
    {
        private static readonly List<AppUser> CurrentUser;

        static AuthService()
        {
            CurrentUser = new List<AppUser>
        {
            new AppUser { UserName = "Admin", Password = "123456", Roles = new List<UserRoles> { UserRoles.Admin }, numberOfKeys=999 }
        };
        }
        public AppUser GetCurrentUser(string userName)
        {
            var user = CurrentUser.FirstOrDefault(w => w.UserName == userName);

            if (user == null)
            {
                throw new Exception("User name or password invalid !");
            }

            return user;
        }


        public CurrentUser GetUser(string userName)
        {
            var user = CurrentUser.FirstOrDefault(w => w.UserName == userName);

            if (user == null)
            {
                throw new Exception("User name or password invalid !");
            }

            var claims = new List<Claim>();
            claims.AddRange(user.Roles.Select(s => new Claim(ClaimTypes.Role, s.ToString())));

            return new CurrentUser
            {
                IsAuthenticated = true,
                UserName = user.UserName,
                NumberOfKeys = user.numberOfKeys,
                Inventory = user.inventory,
                Claims = claims.ToDictionary(c => c.Type, c => c.Value)
            };
        }

        public void Login(ConnexionModel loginRequest)
        {
            var user = CurrentUser.FirstOrDefault(w => w.UserName == loginRequest.UserName && w.Password == loginRequest.Password);

            if (user == null)
            {
                throw new Exception("User name or password invalid !");
            }
        }

        public void Register(InscriptionModel registerRequest)
        {
            CurrentUser.Add(new AppUser { UserName = registerRequest.UserName, Password = registerRequest.Password, Roles = new List<UserRoles> { UserRoles.User } });
        }
    }
}

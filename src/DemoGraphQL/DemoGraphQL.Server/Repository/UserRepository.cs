namespace DemoGraphQL.Server.Repository
{
    using DemoGraphQL.Server.Contracts;
    using DemoGraphQL.Server.Entities;
    using DemoGraphQL.Server.Entities.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User GetById(Guid id) => _context.Users.SingleOrDefault(o => o.Id.Equals(id));

        public User UpdateUser(User dbUser, User user)
        {
            dbUser.Username = user.Username;
            dbUser.numberOfKeys = user.numberOfKeys;
            dbUser.role = user.role;
            dbUser.inventory = user.inventory;

            _context.SaveChanges();

            return dbUser;
        }
    }
}
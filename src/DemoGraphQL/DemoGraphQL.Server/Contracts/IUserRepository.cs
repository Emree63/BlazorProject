namespace DemoGraphQL.Server.Contracts
{
    using DemoGraphQL.Server.Entities;
    using System;
    using System.Collections.Generic;

    public interface IUserRepository
    {
        User CreateUser(User user);

        void DeleteUser(User user);

        IEnumerable<User> GetAll();

        User GetById(Guid id);

        User UpdateUser(User dbUser, User user);
    }
}
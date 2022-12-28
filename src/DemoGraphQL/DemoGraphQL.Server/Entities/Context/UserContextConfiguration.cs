namespace DemoGraphQL.Server.Entities.Context
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class UserContextConfiguration : IEntityTypeConfiguration<User>
    {
        private Guid[] _ids;

        public UserContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
              .HasData(
                new User
                {
                    Id = _ids[0],
                    Username = "Armure",
                    Password="12345",
                    role = UserRoles.Admin,
                    inventory = null
                },
                new User
                {
                    Id = _ids[1],
                    Username = "Rayhan",
                    Password = "123456",
                    role = UserRoles.User,
                    inventory = null
                }
            ); ; ;
        }
    }
}
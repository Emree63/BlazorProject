namespace DemoGraphQL.Server.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        public string Password { get; set; }

        public int numberOfKeys { get; set; }
        public UserRoles role { get; set; }

        public List<Item> inventory { get; set; }
    }
}
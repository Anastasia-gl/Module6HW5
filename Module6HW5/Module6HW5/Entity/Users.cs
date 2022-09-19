using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module6HW5.Entity
{
    public class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public RoleUsers RoleUsers { get; set; }
    }
}

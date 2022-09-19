using System.ComponentModel.DataAnnotations;

namespace Module6HW5.Entity
{
    public class RoleUsers
    {

        public int RoleId { get; set; }

        public string Name{ get; set; }

        public List<Users> Users { get; set; }
    }
}

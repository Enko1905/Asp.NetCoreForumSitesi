using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public int Gender { get; set; }

        public List<Topic> Topic { get; set; }
        public List<Post> Posts { get; set; }
        public List<Reply> Reply { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Post
    {
        /*Mesajlar Tablosu*/
        [Key]
        public int PostID { get; set; }

        public int TopicID { get; set; }
        public Topic Topic { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public string PostContent { get; set; }

        public IList<Reply> Reply { get; set; } 
        public DateTime PostDate { get; set; }

      
    }
}

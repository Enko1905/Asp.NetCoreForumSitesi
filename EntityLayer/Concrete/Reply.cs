using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Reply
    {
        /*Yanıtlar Tablosu*/
        [Key]
        public int ReplyID { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
        public string ReplyContent { get; set; }
        public DateTime ReplyDate { get; set; }
        public Reply()
        {
            ReplyDate = DateTime.Now;
        }
    }
}

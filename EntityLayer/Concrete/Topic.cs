using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Topic
    {
        /*Konular Tablosu */
        [Key]
        public int TopicID { get; set; }
        public string TopicTitle { get; set; }



        [ForeignKey(nameof(CategoryID))]
        public int CategoryID { get; set; }
        public Category Category { get; set; }


       [ForeignKey(nameof(AppUserId))]
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int TopicVotes { get; set; }
        public int TopicView { get; set; } = 0;
        public int TopicStatus { get; set; } = 0;
        public DateTime TopicsDate { get; set; }
        public List<Post> Posts { get; set; }   
        public Topic()
        {
            TopicsDate = DateTime.Now;
        }

    }
}

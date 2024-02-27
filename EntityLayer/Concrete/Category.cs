using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        /*Kategori Tablosu*/
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Topic> Topic { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class DefaultField
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; set; }
        //public string Topic { get; set; }
    }
}

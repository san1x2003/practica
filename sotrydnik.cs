using EfCoreTest1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest1
{
    public class sotrydnik

    {
        [Key]
        public int id_sotrydnik { get; set; }

        public string full_name { get; set; }

        public string email { get; set; }

        public int identificator { get; set; }

        public int id_post { get; set; }



    }
    
}

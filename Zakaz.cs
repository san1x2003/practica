using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest1
{
        public class Zakaz
        {
            [Key]
            public int id_klient { get; set; }

            public int id_post { get; set; }

            public int id_sklada { get; set; }

            public int id_sotrydnik { get; set; }
         
            public int id_product { get; set; }

            public int id_zakaza { get; set; }

            public int number_contract { get; set; }

            public DateTime date_of_execution { get; set; }

            public string adress { get; set; }


     
    }


}


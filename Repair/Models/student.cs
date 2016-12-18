using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repair.Models
{
    public class student
    {
        [Key]
        public int ID { get; set; }
       
        public string studentid { get; set; }
   
        public string password { get; set; }

        public string fname { get; set; }

        public string lname { get; set; }

        public string faculty { get; set; }

        public string branch { get; set; }

        public string year { get; set; }


        public string roomno { get; set; }

        public string tell { get; set; }

        public string permiss { get; set; }
    }
}
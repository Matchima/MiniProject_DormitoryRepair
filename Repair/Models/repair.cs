using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repair.Models
{
    public class repair
    {
        [Key]
        public int ID { get; set; }
        public string jobname { get; set; }
        public string descript { get; set; }
        public DateTime datetime { get; set; }
        public string status { get; set; }
       
        public string studentid { get; set; }
        public string roomno { get; set; }
        public string choich { get; set; }
    }
}
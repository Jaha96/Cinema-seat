using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EntertainmentWorldTicket.Models
{
    public class BranchViewModel
    {
        public int B_ID { get; set; }
        public string B_Name { get; set; }
        public string B_Address { get; set; }
        public string B_DetailInfo { get; set; }
        public int O_ID { get; set; }
        public string B_Picture { get; set; }
        [Required(ErrorMessage = "Please Select Image file")]
        public HttpPostedFileBase PhotoFile1 { get; set; }
    }
}
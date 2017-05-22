using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EntertainmentWorldTicket.Models
{
    public class PerformanceViewModel
    {
        public int P_ID { get; set; }
        public string P_Name { get; set; }
        public string P_Trailer { get; set; }
        [Required(ErrorMessage = "Please Select Video file")]
        public HttpPostedFileBase VideoFile { get; set; }
        public string P_Poster { get; set; }
        [Required(ErrorMessage = "Please Select Image file")]
        public HttpPostedFileBase PhotoFile { get; set; }
        public string P_Author { get; set; }
        public string P_Genre { get; set; }
        public string P_Actors { get; set; }
        //public string P_startday { get; set; }
        public System.DateTime P_StartDay { get; set; }
        public int P_Hour { get; set; }
        public string P_DetailInfo { get; set; }
    }
}
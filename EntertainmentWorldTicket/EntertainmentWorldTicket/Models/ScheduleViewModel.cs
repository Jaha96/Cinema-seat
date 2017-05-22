using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntertainmentWorldTicket.Models
{
    public class ScheduleViewModel
    {
        public int Sc_ID { get; set; }
        public int Sc_Price { get; set; }
        public int Sc_Day { get; set; }
        public System.DateTime Sc_StartDate { get; set; }
        public System.TimeSpan Sc_StartHour { get; set; }
        public int H_ID { get; set; }
        public int P_ID { get; set; }
    }
}
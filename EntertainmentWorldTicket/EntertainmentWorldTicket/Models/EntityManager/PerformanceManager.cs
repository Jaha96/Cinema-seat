using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntertainmentWorldTicket.Models.EntityManager
{
    public class PerformanceManager
    {
        public string AddUserAccount(PerformanceViewModel Performance)
        {
            using (TicketEntities db = new TicketEntities())//baazin ner
            {
                try
                {
                    Performance performance = new Performance();
                    performance.P_ID = Performance.P_ID;
                    performance.P_Name = Performance.P_Name;
                    performance.P_Trailer = Performance.P_Trailer;
                    performance.P_Poster = Performance.P_Poster;
                    performance.P_Author = Performance.P_Author;
                    performance.P_Genre = Performance.P_Genre;
                    performance.P_Actors = Performance.P_Actors;
                    performance.P_StartDay = Performance.P_StartDay;
                    performance.P_Hour = Performance.P_Hour;
                    performance.P_DetailInfo = Performance.P_DetailInfo;
                    db.Performances.Add(performance);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return "1";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntertainmentWorldTicket.Models.EntityManager
{
    public class ScheduleManager
    {
        public string AddUserAccount(ScheduleViewModel Schedule)
        {
            using (TicketEntities db = new TicketEntities())//baazin ner
            {
                try
                {
                    Schedule schedule = new Schedule();
                    schedule.Sc_ID = Schedule.Sc_ID;
                    schedule.Sc_Price = Schedule.Sc_Price;
                    schedule.Sc_Day = Schedule.Sc_Day;
                    schedule.Sc_StartDate = Schedule.Sc_StartDate;
                    schedule.Sc_StartHour = Schedule.Sc_StartHour;
                    schedule.H_ID = Schedule.H_ID;
                    schedule.P_ID = Schedule.P_ID;
                    db.Schedules.Add(schedule);
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
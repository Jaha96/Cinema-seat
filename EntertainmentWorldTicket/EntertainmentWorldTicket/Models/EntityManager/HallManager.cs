using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntertainmentWorldTicket.Models.EntityManager
{
    public class HallManager
    {
        public string AddUserAccount(HallViewModel Hall)
        {
            using (TicketEntities db = new TicketEntities())//baazin ner
            {
                try
                {
                    Hall hall = new Hall();
                    hall.H_ID = Hall.H_ID;
                    hall.H_Name = Hall.H_Name;
                    hall.H_SeatNumbers = Hall.H_SeatNumbers;
                    hall.B_ID = Hall.B_ID;
                    db.Halls.Add(hall);
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
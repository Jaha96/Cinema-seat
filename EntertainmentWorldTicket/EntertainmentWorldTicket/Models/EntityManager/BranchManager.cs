using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntertainmentWorldTicket.Models.EntityManager
{
    public class BranchManager
    {
        public string AddUserAccount(BranchViewModel Branch)
        {
            using (TicketEntities db = new TicketEntities())//baazin ner
            {
                try
                {
                    Branch branch = new Branch();
                    branch.B_ID = Branch.B_ID;
                    branch.B_Name = Branch.B_Name;
                    branch.B_Address = Branch.B_Address;
                    branch.B_DetailInfo = Branch.B_DetailInfo;
                    branch.O_ID = Branch.O_ID;
                    branch.B_Picture = Branch.B_Picture;
                    db.Branches.Add(branch);
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
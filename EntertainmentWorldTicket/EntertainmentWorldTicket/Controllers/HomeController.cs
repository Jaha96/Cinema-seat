using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using EntertainmentWorldTicket.Models;

namespace EntertainmentWorldTicket.Controllers
{
    public class HomeController : Controller
    {
        TicketEntities db = new TicketEntities();

        public static List<SelectListItem> items1 = new List<SelectListItem>();
        public static List<SelectListItem> items2 = new List<SelectListItem>();
        public static List<SelectListItem> items3 = new List<SelectListItem>();
        public static SelectListItem[] getOrganization()
        {
            TicketEntities db1 = new TicketEntities();
            items1.Clear();
            foreach (Organization org in db1.Organizations)
            {
                items1.Add(new SelectListItem
                {
                    Text = org.O_Name.ToString(),
                    Value = org.O_ID.ToString()
                });
            }
            return items1.ToArray();
        }
        public ActionResult Index()
        {
            return View(db.Performances.ToList());
        }
        public ActionResult Performance()
        {
            return View(db.Performances.ToList());
        }
        public ActionResult DetailsPerformance(int id)
        {
            Performance per = db.Performances.Find(id);
            if (per == null)
            {
                return HttpNotFound();
            }
            return View(per);
        }
        public ActionResult Organization()
        {
            return View(db.Organizations.ToList());
        }
        public ActionResult DetailsOrganization(int? id)
        {
            if (id != null)
            {
                return View(db.Branches.Where(b => b.O_ID == id).ToList());
            }
            else
                return View(db.Branches.ToList());
        }
        public static SelectListItem[] getBranch()
        {
            TicketEntities db1 = new TicketEntities();
            items2.Clear();
            foreach (Branch org in db1.Branches)
            {
                items2.Add(new SelectListItem
                {
                    Text = org.B_Name.ToString(),
                    Value = org.B_ID.ToString()
                });
            }
            return items2.ToArray();
        }
        public static SelectListItem[] getSchedule()
        {
            TicketEntities db1 = new TicketEntities();
            items3.Clear();
            string weekName=null;
            foreach (Schedule org in db1.Schedules)
            {
                    
                switch(org.Sc_Day){
                    case 1: weekName = "Даваа"; break;
                    case 2: weekName = "Даваа"; break;
                    case 3: weekName = "Даваа"; break;
                    case 4: weekName = "Даваа"; break;
                    case 5: weekName = "Даваа"; break;
                    default: weekName = "Хоосон"; break;
                    }
                items3.Add(new SelectListItem
                {
                    Text = org.Sc_StartDate.ToString("yyyy-MM-dd") + " " + weekName,
                    Value = org.Sc_ID.ToString()
                });
            }
            return items3.ToArray();
        }
        public ActionResult step1()
        {
            return View(db.Branches.ToList());
        }

        public ActionResult step2(int? id)
        {
            string weekName = null;
            var query=from b in db.Branches
                join h in db.Halls on b.B_ID equals h.B_ID
                join s in db.Schedules on h.H_ID equals s.H_ID
                where b.B_ID==id
                select new  {s.Sc_ID,s.Sc_Day,s.Sc_StartDate, s.Sc_StartHour};
            items3.Clear();
                    foreach (var v in query)
                {
                    switch (v.Sc_Day)
                    {
                        case 1: weekName = "Даваа"; break;
                        case 2: weekName = "Мягмар"; break;
                        case 3: weekName = "Лхагва"; break;
                        case 4: weekName = "Пүрэв"; break;
                        case 5: weekName = "Баасан"; break;
                        case 6: weekName = "Бямба"; break;
                        case 7: weekName = "Ням"; break;
                        default: weekName = "Хоосон"; break;
                    }
                    items3.Add(new SelectListItem
                    {
                        Text = v.Sc_StartDate.ToString("yyyy-MM-dd") + "-" + weekName+"--"+v.Sc_StartHour,
                        Value = v.Sc_ID.ToString()
                    });
        
    }
            ViewBag.ScheduleList = items3.ToArray();
            
            return View();
    }
        public ActionResult TicketOrder()
        {
            //OrgaBranVM orgVM = new OrgaBranVM();
           // db.Organizations.Where(org => org.O_ID == null).ToList().Select(menu => new SelectListItem
            //orgVM.MenuLevel1 = db.Organizations.Where(menu => menu.Or_ID != null).ToList().
            //Select(menu => new SelectListItem
            //{
            //    Value = menu.Or_ID.ToString(),
            //    Text = menu.Or_Name
            //}).ToList();
            //orgVM.MenuLevel1.Insert(0, new SelectListItem
            //{
            //    Value = "-1",
            //    Text = "Please select a Menu"
            //});
            //orgVM.MenuLevel2 = new List<SelectListItem>();

            //List<SelectListItem> dept = new List<SelectListItem>();
            //var query = from u in db.Organizations select u;
            //if (query.Count() > 0)
            //{
            //    foreach (var v in query)
            //    {
            //        dept.Add(new SelectListItem { Text = v.Or_Name, Value = v.Or_ID.ToString() });
            //    }
            //}
            //ViewBag.Departments = dept;
            //return View("TicketOrder");
            ViewBag.StateList = db.Organizations;
            var model = new OrgaBranVM();
            return View(model);
        }
        [HttpPost]
        public ActionResult TicketOrder(Organization model)
        {
            if (ModelState.IsValid)
            {
                // code to save record  and redirect to listing page
            }
            ViewBag.StateList = db.Organizations;
            return View(model);
        }
        [HttpGet]
        public ActionResult FillCity(int state)
        {
            var cities = db.Branches.Where(c => c.B_ID == state);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SeatShow() {
            return View();
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        //public JsonResult LoadPhysiansByDepartment(string deptId)
        //{
        //    //Your Code For Getting Physicans Goes Here
        //    var phyList = this.GetPhysicans(Convert.ToInt32(deptId));


        //    var phyData = classesList.Select(m => new SelectListItem()
        //    {
        //        Text = m.phyName,
        //        Value = m.phyId.ToString(),
        //    });
        //    return Json(phyData, JsonRequestBehavior.AllowGet);
        //}


        //[HttpGet]
        //public ActionResult filterCatLevel2(int id)
        //{
        //    return Json(this.db.Branches.Where(c=>c.O_ID==id).ToList
        //        ().Select(c => new SelectListItem
        //        {
        //            Value = c.B_ID.ToString(),
        //            Text = c.B_Name
        //        }).ToList(), JsonRequestBehavior.AllowGet);
        //}
        [HttpPost]
        public ActionResult Login()
        {
            string name = Request.Form["email"];
            string password = Request.Form["password"];
          //  string remember = Request.Form["remember_me"];

            var useer = db.Users.Where(o => o.Us_Email == name);
            useer = useer.Where(o => o.Us_Password == password);
            if (useer.ToList().Count != 0)
            {
                FormsAuthentication.SetAuthCookie(useer.First().Us_Email, false);

                var authTicket = new FormsAuthenticationTicket(1, useer.First().Us_Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, useer.First().Us_Password);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
            }
            return RedirectToAction("index","Manager");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }
    }
}
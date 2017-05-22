using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntertainmentWorldTicket.Models.EntityManager;
using EntertainmentWorldTicket.Models;
using System.IO;

namespace EntertainmentWorldTicket.Controllers
{
    public class ManagerController : Controller
    {
        TicketEntities db = new TicketEntities();
          public static List<SelectListItem> items1 = new List<SelectListItem>();
          public static List<SelectListItem> items2 = new List<SelectListItem>();
          public static List<SelectListItem> items3 = new List<SelectListItem>();
          public static List<SelectListItem> items4 = new List<SelectListItem>();
          public static SelectListItem[] getOrganization()
          {
              TicketEntities db1 = new TicketEntities();
              items1.Clear();
              foreach (Organization org in db1.Organizations) { 
                items1.Add(new SelectListItem { 

                    Text = org.O_Name.ToString(),
                    Value = org.O_ID.ToString() 
                });
              }
              return items1.ToArray();
          }
        //
        // GET: /Dashboard/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BranchRegister()
        {

            ViewBag.OrganizationList = getOrganization();
            return View();
        }
        [HttpPost]
        public ActionResult BranchRegister(BranchViewModel BM)
        {
            if (BM.PhotoFile1.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }
            if (!(BM.PhotoFile1.ContentType == "image/jpeg" || BM.PhotoFile1.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }
            else
            {
                var fileName = Path.GetFileName(BM.PhotoFile1.FileName);
                var path = Path.Combine(Server.MapPath("~/images/Poster/"), fileName);
                BM.PhotoFile1.SaveAs(path);
                var pathName = "~/images/Poster/" + Path.GetFileName(BM.PhotoFile1.FileName);
                BM.B_Picture = pathName;
            }
            BranchManager branM = new BranchManager();
            string ret = branM.AddUserAccount(BM);
            if (ret == "1")
            {
                ViewBag.Message = "Амжилттай нэмэгдлээ";
            }
            else
            {
                ViewBag.ErrorMessage = "Алдаа гарлаа" + "\n" + ret;
            }
           ViewBag.OrganizationList = getOrganization();
           return View();
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
        public ActionResult HallRegister()
        {
            ViewBag.BranchList = getBranch();
            return View();
        }
        [HttpPost]
        public ActionResult HallRegister(HallViewModel HM)
        {
            HallManager hallM = new HallManager();
            string ret = hallM.AddUserAccount(HM);
            if (ret == "1")
            {
                ViewBag.Message = "Амжилттай нэмэгдлээ";
            }
            else
            {
                ViewBag.ErrorMessage = "Алдаа гарлаа" + "\n" + ret;
            }
            ViewBag.BranchList = getBranch();
            return View();
        }
        public ActionResult PerformanceRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PerformanceRegister(PerformanceViewModel PM)
        {
            if (PM.PhotoFile.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }
            if (!(PM.PhotoFile.ContentType == "image/jpeg" || PM.PhotoFile.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }
            else
            {
                var fileName = Path.GetFileName(PM.PhotoFile.FileName);
                var path = Path.Combine(Server.MapPath("~/images/Poster/"), fileName);
                PM.PhotoFile.SaveAs(path);
                var pathName = "~/images/Poster/" + Path.GetFileName(PM.PhotoFile.FileName);
                PM.P_Poster = pathName;
            }
            if (PM.VideoFile.ContentType == "video/mp4") {
                var VideoPath = Path.GetFileName(PM.VideoFile.FileName);
                var pathVideo = Path.Combine(Server.MapPath("~/images/Trailer/"),VideoPath);
                PM.VideoFile.SaveAs(pathVideo);
                var PathName = "~/images/Trailer/" + Path.GetFileName(PM.VideoFile.FileName);
                PM.P_Trailer = PathName;
            }
            PerformanceManager perM = new PerformanceManager();
            string ret = perM.AddUserAccount(PM);
            if (ret == "1")
            {
                ViewBag.Message = "Амжилттай нэмэгдлээ";
            }
            else
            {
                ViewBag.ErrorMessage = "Алдаа гарлаа" + "\n" + ret;
            }
            return View();
        }
        public static SelectListItem[] getHall()
        {
            TicketEntities db1 = new TicketEntities();
            items3.Clear();
            foreach (Hall org in db1.Halls)
            {
                items3.Add(new SelectListItem
                {
                    Text = org.H_Name.ToString(),
                    Value = org.H_ID.ToString()
                });
            }
            return items3.ToArray();
        }
        public static SelectListItem[] getPerformance()
        {
            TicketEntities db1 = new TicketEntities();
            items4.Clear();
            foreach (Performance org in db1.Performances)
            {
                items4.Add(new SelectListItem
                {
                    Text = org.P_Name.ToString(),
                    Value = org.P_ID.ToString()
                });
            }
            return items4.ToArray();
        }
        public ActionResult ScheduleRegister()
        {
            ViewBag.HallList = getHall();
            ViewBag.PerformanceList = getPerformance();
            return View();
        }
        [HttpPost]
        public ActionResult ScheduleRegister(ScheduleViewModel SM)
        {
            ScheduleManager scheduleM = new ScheduleManager();
            string ret = scheduleM.AddUserAccount(SM);
            if (ret == "1")
            {
                ViewBag.Message = "Амжилттай нэмэгдлээ";
            }
            else
            {
                ViewBag.ErrorMessage = "Алдаа гарлаа" + "\n" + ret;
            }
            ViewBag.HallList = getHall();
            ViewBag.PerformanceList = getPerformance();
            return View();
        }
        public ActionResult BranchList()
        {
            return View(db.Branches.ToList());
        }
        public ActionResult DeleteBranch(int id)
        {
            Branch branch = db.Branches.Find(id);
            //attach object in the entity set

            db.Branches.Remove(branch);

            //save changes
            db.SaveChanges();
            return RedirectToAction("BranchList");
        }
        public ActionResult DetailBranch(string id = null)
        {

            Branch bran = db.Branches.Find(Convert.ToInt32(id));
            if (bran == null)
            {
                return HttpNotFound();
            }
            return View(bran);
        }
        public ActionResult UpdateBranch(int id)
        {
            Branch br = db.Branches.Find(id);
            BranchViewModel BM = new BranchViewModel();
            BM.B_ID = br.B_ID;
            BM.B_Name = br.B_Name;
            BM.B_Address = br.B_Address;
            BM.B_DetailInfo = br.B_DetailInfo;
            BM.O_ID = br.O_ID;
            BM.B_Picture = br.B_Picture;

            ViewBag.OrganizationList = getOrganization();
            return View("BranchRegister",BM);
        }
        [HttpPost]
        public ActionResult UpdateBranch(BranchViewModel BranM)
        {
            var empQuery = from emp in db.Branches
                           where emp.B_ID == BranM.B_ID
                           select emp;
            Branch objEmp = empQuery.Single();
            if (BranM.PhotoFile1.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }
            if (!(BranM.PhotoFile1.ContentType == "image/jpeg" || BranM.PhotoFile1.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }
            else
            {
                var fileName = Path.GetFileName(BranM.PhotoFile1.FileName);
                var path = Path.Combine(Server.MapPath("~/images/Poster/"), fileName);
                BranM.PhotoFile1.SaveAs(path);
                var pathName = "~/images/Poster/" + Path.GetFileName(BranM.PhotoFile1.FileName);
                BranM.B_Picture = pathName;
            }
            objEmp.B_Name = BranM.B_Name;
            objEmp.B_Address = BranM.B_Address;
            objEmp.B_DetailInfo = BranM.B_DetailInfo;
            objEmp.O_ID = BranM.O_ID;
            objEmp.B_Picture = BranM.B_Picture;
            db.SaveChanges();

            return RedirectToAction("BranchList");
        }
        public ActionResult HallList()
        {
            return View(db.Halls.ToList());
        }

        public ActionResult DeleteHall(int id)
        {
            Hall hall = db.Halls.Find(id);
            //attach object in the entity set

            db.Halls.Remove(hall);

            //save changes
            db.SaveChanges();
            return RedirectToAction("HallList");
        }
        public ActionResult OrganizationList()
        {
            return View(db.Organizations.ToList());
        }
        public ActionResult DetailOrganization(string id = null)
        {

            Organization organ = db.Organizations.Find(Convert.ToInt32(id));
            if (organ == null)
            {
                return HttpNotFound();
            }
            return View(organ);
        }
        public ActionResult PerformanceList()
        {
            return View(db.Performances.ToList());
        }
        public ActionResult DetailPerformance(string id = null)
        {

            Performance perfor = db.Performances.Find(Convert.ToInt32(id));
            if (perfor == null)
            {
                return HttpNotFound();
            }
            return View(perfor);
        }
        public ActionResult DeletePerformance(int id)
        {
            Performance perfor = db.Performances.Find(id);
            //attach object in the entity set

            db.Performances.Remove(perfor);

            //save changes
            db.SaveChanges();
            return RedirectToAction("PerformanceList");
        }
        public ActionResult ScheduleList()
        {
            return View(db.Schedules.ToList());
        }
        public ActionResult DeleteSchedule(int id)
        {
            Schedule scheule = db.Schedules.Find(id);
            //attach object in the entity set

            db.Schedules.Remove(scheule);

            //save changes
            db.SaveChanges();
            return RedirectToAction("ScheduleList");
        }
	}
}
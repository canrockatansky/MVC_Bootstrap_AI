using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bau302ToDoList.Models;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;

namespace Bau302ToDoList.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ToDoItems
        public async Task<ActionResult> Index()
        {
            var toDoItems = db.ToDoItems.Include(t => t.Category).Include(t => t.Customer).Include(t => t.Department).Include(t => t.Manager).Include(t => t.Organizator).Include(t => t.Side);
            return View(await toDoItems.ToListAsync());
        }

        // GET: ToDoItems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = await db.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoItem);
        }

        // GET: ToDoItems/Create
        public ActionResult Create()
        {
            var toDoItem = new ToDoItem();
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name");
            ViewBag.ManagerID = new SelectList(db.Contacts, "ID", "FirstName");
            ViewBag.OrganizatorID = new SelectList(db.Contacts, "ID", "FirstName");
            ViewBag.SideID = new SelectList(db.Sides, "ID", "Name");
            return View(toDoItem);
        }

        // POST: ToDoItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,Description,Status,CategoryID,Attachment,DepartmentID,SideID,CustomerID,ManagerID,OrganizatorID,MeetingDate,PlannedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MaillingSubject,PosterSubject,PosterCount,ELearning,TypesOfScans,AsoCountInScans,TypesOfOrganization,AsoCountInOrganization,TypesOfVaccinationOrganization,AsoCountInVaccinationOrganization,AmoutOfCompensationForPoster,CorporateProductivityReport,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                toDoItem.CreateDate = DateTime.Now;
                toDoItem.CreatedBy = "Unknow";
                toDoItem.UpdateDate = DateTime.Now;
                toDoItem.UpdatedBy = "Unknow";
                db.ToDoItems.Add(toDoItem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", toDoItem.CategoryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", toDoItem.CustomerID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", toDoItem.DepartmentID);
            ViewBag.ManagerID = new SelectList(db.Contacts, "ID", "FirstName", toDoItem.ManagerID);
            ViewBag.OrganizatorID = new SelectList(db.Contacts, "ID", "FirstName", toDoItem.OrganizatorID);
            ViewBag.SideID = new SelectList(db.Sides, "ID", "Name", toDoItem.SideID);
            return View(toDoItem);
        }

        // GET: ToDoItems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = await db.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", toDoItem.CategoryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", toDoItem.CustomerID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", toDoItem.DepartmentID);
            ViewBag.ManagerID = new SelectList(db.Contacts, "ID", "FirstName", toDoItem.ManagerID);
            ViewBag.OrganizatorID = new SelectList(db.Contacts, "ID", "FirstName", toDoItem.OrganizatorID);
            ViewBag.SideID = new SelectList(db.Sides, "ID", "Name", toDoItem.SideID);
            return View(toDoItem);
        }

        // POST: ToDoItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,Description,Status,CategoryID,Attachment,DepartmentID,SideID,CustomerID,ManagerID,OrganizatorID,MeetingDate,PlannedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MaillingSubject,PosterSubject,PosterCount,ELearning,TypesOfScans,AsoCountInScans,TypesOfOrganization,AsoCountInOrganization,TypesOfVaccinationOrganization,AsoCountInVaccinationOrganization,AmoutOfCompensationForPoster,CorporateProductivityReport,CreateDate,CreatedBy,UpdateDate,UpdatedBy")] ToDoItem toDoItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", toDoItem.CategoryID);
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", toDoItem.CustomerID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "ID", "Name", toDoItem.DepartmentID);
            ViewBag.ManagerID = new SelectList(db.Contacts, "ID", "FirstName", toDoItem.ManagerID);
            ViewBag.OrganizatorID = new SelectList(db.Contacts, "ID", "FirstName", toDoItem.OrganizatorID);
            ViewBag.SideID = new SelectList(db.Sides, "ID", "Name", toDoItem.SideID);
            return View(toDoItem);
        }

        // GET: ToDoItems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoItem toDoItem = await db.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return HttpNotFound();
            }
            return View(toDoItem);
        }

        // POST: ToDoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ToDoItem toDoItem = await db.ToDoItems.FindAsync(id);
            db.ToDoItems.Remove(toDoItem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public void ExportToExcel()
        {
            var grid = new GridView();
            grid.DataSource = from todoitems in db.ToDoItems.ToList()
                              select new
                              {
                                  Baslik = todoitems.Title,
                                  Aciklama = todoitems.Description,
                                  Kategori = todoitems.Category.Name,
                                  DosyaEki = todoitems.Attachment,
                                  Departman = todoitems.Department.Name,
                                  Taraf = todoitems.Side.Name,
                                  Müsteri = todoitems.Customer.Name,
                                  Yonetici = todoitems.Manager.FirstName,
                                  Organizator = todoitems.Organizator.FirstName,
                                  Durum = todoitems.Status,
                                  ToplantiTarihi = todoitems.MeetingDate,
                                  PlanlananTarih = todoitems.PlannedDate,
                                  BitirilmeTarihi = todoitems.FinishDate,
                                  RevizeTarihi = todoitems.ReviseDate,
                                  GorusmeKonusu = todoitems.ConversationSubject,
                                  DestekleyenFirma = todoitems.SupporterCompany,
                                  DestekleyenHekim = todoitems.SupporterDoctor,
                                  GorusmeKatilimciSayisi = todoitems.ConversationAttendeeCount,
                                  PlanlananOrganizasyonTarihi = todoitems.ScheduledOrganizationDate,
                                  MailKonuları = todoitems.MaillingSubject,
                                  AfisKonusu = todoitems.PosterSubject,
                                  AfisSayisi = todoitems.PosterCount,
                                  Elearning = todoitems.ELearning,
                                  YapilanTaramalarınTurleri = todoitems.TypesOfScans,
                                  YapilanTaramalardakiAsoSayisi = todoitems.AsoCountInScans,
                                  OrganizasyonTurleri = todoitems.TypesOfOrganization,
                                  OrganizasyondakiAsoSayisi = todoitems.AsoCountInOrganization,
                                  AsıOrganizasyonTurleri = todoitems.TypesOfVaccinationOrganization,
                                  AsıOrganizasyonundakiAsoSayisi = todoitems.AsoCountInVaccinationOrganization,
                                  AfisicinTazminatMiktari = todoitems.AmoutOfCompensationForPoster,
                                  KurumsalVerimlilikRaporu = todoitems.CorporateProductivityReport,
                                  Olusturulmatarihi = todoitems.CreateDate,
                                  OlusturanKullanici = todoitems.CreatedBy,
                                  GuncellenmeTarihi = todoitems.UpdateDate,
                                  GuncelleyenKullanici = todoitems.UpdatedBy
                              };
            grid.DataBind();
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=yapilacaklar.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            System.IO.StringWriter sw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

            grid.RenderControl(hw);

            Response.Write(sw.ToString());
            Response.End();
        }
        public void ExportToCsv()
        {
            StringWriter sw = new StringWriter();
            Response.ClearContent();
            sw.WriteLine("Baslik,Aciklama,Kategori,DosyaEki,Departman,Taraf,Müsteri,Yonetici,Organizator,Durum,ToplantiTarihi,PlanlananTarih,BitirilmeTarihi,RevizeTarihi,GorusmeKonusu,DestekleyenFirma,DestekleyenHekim,GorusmeKatilimciSayisi,PlanlananOrganizasyonTarihi,MailKonuları,AfisKonusu,AfisSayisi,Elearning,YapilanTaramalarınTurleri,YapilanTaramalardakiAsoSayisi,OrganizasyonTurleri,OrganizasyondakiAsoSayisi,AsıOrganizasyonTurleri,AsıOrganizasyonundakiAsoSayisi,AfisicinTazminatMiktari,KurumsalVerimlilikRaporu,Olusturulmatarihi,OlusturanKullanici,GuncellenmeTarihi,GuncelleyenKullanici");
            Response.AddHeader("content-disposition", "attachment;filename=yapilacaklar.csv");
            Response.ContentType = "text/csv";
            var todoitem = db.ToDoItems.ToList();
            foreach (var todoitems in todoitem)
            {
                sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34}",

                    todoitems.Title,
                    todoitems.Description,
                    todoitems.Category.Name,
                    todoitems.Attachment,
                    todoitems.Department.Name,
                    todoitems.Side.Name,
                    todoitems.Customer.Name,
                    todoitems.Manager.FirstName,
                    todoitems.Organizator.FirstName,
                    todoitems.Status,
                    todoitems.MeetingDate,
                    todoitems.PlannedDate,
                    todoitems.FinishDate,
                    todoitems.ReviseDate,
                    todoitems.ConversationSubject,
                    todoitems.SupporterCompany,
                    todoitems.SupporterDoctor,
                    todoitems.ConversationAttendeeCount,
                    todoitems.ScheduledOrganizationDate,
                    todoitems.MaillingSubject,
                    todoitems.PosterSubject,
                    todoitems.PosterCount,
                    todoitems.ELearning,
                    todoitems.TypesOfScans,
                    todoitems.AsoCountInScans,
                    todoitems.TypesOfOrganization,
                    todoitems.AsoCountInOrganization,
                    todoitems.TypesOfVaccinationOrganization,
                    todoitems.AsoCountInVaccinationOrganization,
                    todoitems.AmoutOfCompensationForPoster,
                    todoitems.CorporateProductivityReport,
                    todoitems.CreateDate,
                    todoitems.CreatedBy,
                    todoitems.UpdateDate,
                    todoitems.UpdatedBy
                    )
                    );
            }
            Response.Write(sw.ToString());
            Response.End();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

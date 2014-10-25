using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Repository.Repository;
using Repository;

namespace WebNarudzba.Controllers
{
    public class DobavljacController : Controller
    {
        private WebNarudzbaContext db = new WebNarudzbaContext();

        //private GenericRepository<Dobavljac> genericRepository = new GenericRepository<Dobavljac>(new WebNarudzbaContext());
        //private UnitOfWork unitOfWork = new UnitOfWork(); 

        //Constructor injection
        private readonly IUnitOfWork unitOfWork;

        public DobavljacController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Dobavljac
        public async Task<ActionResult> Index()
        {
            //return View(await genericRepository.GetAll()); umjesto direktnog pristupa genericrepository-u, sada ide preko unitofwork
            return View(await unitOfWork.Dobavljac.GetAll());

        }

        // GET: Dobavljac/Details/5
        public async Task<ActionResult> Details(int id)
        {

            Dobavljac dobavljac = await unitOfWork.Dobavljac.GetByIdAsync(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // GET: Dobavljac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dobavljac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Naziv,Adresa,Telefon")] Dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Dobavljac.InsertAsync(dobavljac);
                return RedirectToAction("Index");
            }

            return View(dobavljac);
        }

        // GET: Dobavljac/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Dobavljac dobavljac = await unitOfWork.Dobavljac.GetByIdAsync(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // POST: Dobavljac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Naziv,Adresa,Telefon")] Dobavljac dobavljac)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Dobavljac.UpdateAsync(dobavljac);
                return RedirectToAction("Index");
            }
            return View(dobavljac);
        }

        // GET: Dobavljac/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            Dobavljac dobavljac = await unitOfWork.Dobavljac.GetByIdAsync(id);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljac);
        }

        // POST: Dobavljac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dobavljac dobavljac = await unitOfWork.Dobavljac.GetByIdAsync(id);
            await unitOfWork.Dobavljac.DeleteAsync(dobavljac);
            return RedirectToAction("Index");
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

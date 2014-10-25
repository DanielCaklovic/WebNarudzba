using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Model;
using Repository.Repository;
using Repository;

namespace WebNarudzba.Controllers
{
    public class ProizvodController : Controller
    {
        private WebNarudzbaContext db = new WebNarudzbaContext();

        // private GenericRepository<Proizvod> genericRepository = new GenericRepository<Proizvod>(new WebNarudzbaContext());
        //  private UnitOfWork unitOfWork = new UnitOfWork();

        //Constructor injection
        private readonly IUnitOfWork unitOfWork;

        public ProizvodController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: Proizvod
        public async Task<ActionResult> Index()
        {
            //var proizvod = db.Proizvod.Include(p => p.Dobavljac);

            //return View(await proizvod.ToListAsync());
            return View(await unitOfWork.Proizvod.GetAll());
        }

        // GET: Proizvod/Details/5
        public async Task<ActionResult> Details(int id)
        {

            Proizvod proizvod = await unitOfWork.Proizvod.GetByIdAsync(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // GET: Proizvod/Create
        public ActionResult Create()
        {
            ViewBag.Dobavljac_ID = new SelectList(db.Dobavljac, "ID", "Naziv");
            return View();
        }

        // POST: Proizvod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Naziv,Cijena,Dobavljac_ID")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Proizvod.InsertAsync(proizvod);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Dobavljac_ID = new SelectList(db.Dobavljac, "ID", "Naziv", proizvod.Dobavljac_ID);
            return View(proizvod);
        }

        // GET: Proizvod/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Proizvod proizvod = await unitOfWork.Proizvod.GetByIdAsync(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dobavljac_ID = new SelectList(db.Dobavljac, "ID", "Naziv", proizvod.Dobavljac_ID);
            return View(proizvod);
        }

        // POST: Proizvod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Naziv,Cijena,Dobavljac_ID")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Proizvod.UpdateAsync(proizvod);

                return RedirectToAction("Index");
            }
            ViewBag.Dobavljac_ID = new SelectList(db.Dobavljac, "ID", "Naziv", proizvod.Dobavljac_ID);
            return View(proizvod);
        }

        // GET: Proizvod/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            Proizvod proizvod = await unitOfWork.Proizvod.GetByIdAsync(id);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: Proizvod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Proizvod proizvod = await unitOfWork.Proizvod.GetByIdAsync(id);
            await unitOfWork.Proizvod.DeleteAsync(proizvod);

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

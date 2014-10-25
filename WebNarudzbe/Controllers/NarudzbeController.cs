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
    public class NarudzbeController : Controller
    {
        private WebNarudzbaContext db = new WebNarudzbaContext();

        // private NarudzbeRepository narudzbeRepository = new NarudzbeRepository(new WebNarudzbaContext());
        // private UnitOfWork unitOfWork = new UnitOfWork();


        //Constructor injection
        private readonly IUnitOfWork unitOfWork;

        public NarudzbeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: Narudzbe
        public async Task<ActionResult> Index()
        {
            return View(await unitOfWork.Narudzbe.GetNarudzbeAsync());
        }

        // GET: Narudzbe/Details/5
        public async Task<ActionResult> Details(int narudzbeID, int proizvodID, int kupacID)
        {

            Narudzbe narudzbe = await unitOfWork.Narudzbe.GetNarudzbeByIdAsync(narudzbeID, proizvodID, kupacID);
            if (narudzbe == null)
            {
                return HttpNotFound();
            }
            return View(narudzbe);
        }

        // GET: Narudzbe/Create
        public ActionResult Create()
        {
            ViewBag.KupacID = new SelectList(db.Kupac, "ID", "Ime");
            ViewBag.ProizvodID = new SelectList(db.Proizvod, "ID", "Naziv");
            return View();
        }

        // POST: Narudzbe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "NarudzbeID,ProizvodID,KupacID")] Narudzbe narudzbe)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Narudzbe.InsertNarudzbeAsync(narudzbe);
                return RedirectToAction("Index");
            }

            ViewBag.KupacID = new SelectList(db.Kupac, "ID", "Ime", narudzbe.KupacID);
            ViewBag.ProizvodID = new SelectList(db.Proizvod, "ID", "Naziv", narudzbe.ProizvodID);
            return View(narudzbe);
        }

        // GET: Narudzbe/Edit/5
        public async Task<ActionResult> Edit(int narudzbeID, int proizvodID, int kupacID)
        {

            Narudzbe narudzbe = await unitOfWork.Narudzbe.GetNarudzbeByIdAsync(narudzbeID, proizvodID, kupacID);
            if (narudzbe == null)
            {
                return HttpNotFound();
            }
            ViewBag.KupacID = new SelectList(db.Kupac, "ID", "Ime", narudzbe.KupacID);
            ViewBag.ProizvodID = new SelectList(db.Proizvod, "ID", "Naziv", narudzbe.ProizvodID);
            return View(narudzbe);
        }

        // POST: Narudzbe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NarudzbeID,ProizvodID,KupacID")] Narudzbe narudzbe)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Narudzbe.UpdateNarudzbeAsync(narudzbe);
                return RedirectToAction("Index");
            }
            ViewBag.KupacID = new SelectList(db.Kupac, "ID", "Ime", narudzbe.KupacID);
            ViewBag.ProizvodID = new SelectList(db.Proizvod, "ID", "Naziv", narudzbe.ProizvodID);
            return View(narudzbe);
        }

        // GET: Narudzbe/Delete/5
        public async Task<ActionResult> Delete(int narudzbeID, int proizvodID, int kupacID)
        {

            Narudzbe narudzbe = await unitOfWork.Narudzbe.GetNarudzbeByIdAsync(narudzbeID, proizvodID, kupacID);
            if (narudzbe == null)
            {
                return HttpNotFound();
            }
            return View(narudzbe);
        }

        // POST: Narudzbe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int narudzbeID, int proizvodID, int kupacID)
        {

            await unitOfWork.Narudzbe.DeleteNarudzbeAsync(narudzbeID, proizvodID, kupacID);
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

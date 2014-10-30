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
using WebNarudzbe.Models;
using AutoMapper;

namespace WebNarudzba.Controllers
{
    public class NarudzbeController : Controller
    {
        private WebNarudzbaContext db = new WebNarudzbaContext();

        ///<remarks>
        /// Bez UoW - private GenericRepository<Kupac> genericRepository = new GenericRepository<Kupac>(new WebNarudzbaContext());
        /// Hardcoding - private UnitOfWork unitOfWork = new UnitOfWork(); 
        /// </remarks>



        ///<remarks>
        ///Constructor injection
        /// </remarks>
        private readonly IUnitOfWork unitOfWork;

        public NarudzbeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: Narudzbe
        public async Task<ActionResult> Index()
        {
            IList<Narudzbe> narudzbe = await unitOfWork.Narudzbe.GetNarudzbeAsync();
            IList<NarudzbeDTO> narudzbeViewModel = Mapper.Map<IList<Narudzbe>, IList<NarudzbeDTO>>(narudzbe);
            return View(narudzbeViewModel);
        }

        // GET: Narudzbe/Details/5
        public async Task<ActionResult> Details(int narudzbeID, int proizvodID, int kupacID)
        {

            Narudzbe narudzbe = await unitOfWork.Narudzbe.GetNarudzbeByIdAsync(narudzbeID, proizvodID, kupacID);
            NarudzbeDTO narudzbeViewModel = Mapper.Map<Narudzbe, NarudzbeDTO>(narudzbe);
            if (narudzbe == null)
            {
                return HttpNotFound();
            }
            ViewBag.KupacID = new SelectList(db.Kupac, "ID", "Ime");
            ViewBag.ProizvodID = new SelectList(db.Proizvod, "ID", "Naziv");
            
            return View(narudzbeViewModel);
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
        public async Task<ActionResult> Create([Bind(Include = "NarudzbeID,ProizvodID,KupacID")] NarudzbeDTO narudzbe)
        {
            if (ModelState.IsValid)
            {
                Narudzbe narudzbeViewModel = Mapper.Map<NarudzbeDTO, Narudzbe>(narudzbe);
                await unitOfWork.Narudzbe.InsertNarudzbeAsync(narudzbeViewModel);
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
            NarudzbeDTO narudzbeViewModel = Mapper.Map<Narudzbe, NarudzbeDTO>(narudzbe);
            if (narudzbe == null)
            {
                return HttpNotFound();
            }
            ViewBag.KupacID = new SelectList(db.Kupac, "ID", "Ime", narudzbeViewModel.KupacID);
            ViewBag.ProizvodID = new SelectList(db.Proizvod, "ID", "Naziv", narudzbeViewModel.ProizvodID);
            return View(narudzbeViewModel);
        }

        // POST: Narudzbe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "NarudzbeID,ProizvodID,KupacID")] NarudzbeDTO narudzbe)
        {
            if (ModelState.IsValid)
            {
                Narudzbe narudzbeViewModel = Mapper.Map<NarudzbeDTO, Narudzbe>(narudzbe);
                await unitOfWork.Narudzbe.UpdateNarudzbeAsync(narudzbeViewModel);
                return RedirectToAction("Index");
            }
            ViewBag.KupacID = new SelectList(db.Kupac, "ID", "Ime", narudzbe.KupacID);
            ViewBag.ProizvodID = new SelectList(db.Proizvod, "ID", "Naziv", narudzbe.ProizvodID);
            return View(narudzbe);
        }

        // GET: Narudzbe/Delete/5
        public async Task<ActionResult> Delete(int narudzbeID, int proizvodID, int kupacID)
        {

            await unitOfWork.Narudzbe.DeleteNarudzbeAsync(narudzbeID, proizvodID, kupacID);
            return RedirectToAction("Index");
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
                unitOfWork.Narudzbe.Dispose();
            }
            base.Dispose(disposing);
        }

    
    }
}

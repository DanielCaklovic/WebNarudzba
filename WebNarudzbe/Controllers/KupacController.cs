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
using Repository.Interface;

namespace WebNarudzba.Controllers
{
    public class KupacController : Controller
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
        private readonly IKupacRepository kupacRepository;

        public KupacController(IUnitOfWork unitOfWork,IKupacRepository kupacRepository)
        {
            this.unitOfWork = unitOfWork;
            this.kupacRepository = kupacRepository;
        }

        // GET: Kupac
        public async Task<ActionResult> Index()
        {
            IList<Kupac> kupac = await kupacRepository.GetKupciAsync();
            IList<KupacDTO> kupacViewModel = Mapper.Map<IList<Kupac>, IList<KupacDTO>>(kupac);
            return View(kupacViewModel);
        }

        // GET: Kupac/Details/5
        public async Task<ActionResult> Details(int id)
        {

            Kupac kupac = await kupacRepository.GetKupacByIdAsync(id);
            KupacDTO kupacViewModel = Mapper.Map<Kupac, KupacDTO>(kupac);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupacViewModel);
        }

        // GET: Kupac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kupac/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Ime,Prezime,Adresa,Telefon")] KupacDTO kupac)
        {
            if (ModelState.IsValid)
            {
                Kupac kupacViewModel = Mapper.Map<KupacDTO, Kupac>(kupac);
                await kupacRepository.InsertKupacAsync(kupacViewModel);
                await unitOfWork.Kupac.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(kupac);
        }

        // GET: Kupac/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Kupac kupac = await kupacRepository.GetKupacByIdAsync(id);
            KupacDTO kupacViewModel = Mapper.Map<Kupac, KupacDTO>(kupac);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupacViewModel);
        }

        // POST: Kupac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Ime,Prezime,Adresa,Telefon")] KupacDTO kupac)
        {
            if (ModelState.IsValid)
            {
                Kupac kupacViewModel = Mapper.Map<KupacDTO, Kupac>(kupac);
                await kupacRepository.UpdateKupacAsync(kupacViewModel);
                await unitOfWork.Kupac.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(kupac);
        }

        // GET: Kupac/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            await kupacRepository.DeleteKupacAsync(id);
            return RedirectToAction("Index");
        }

        // POST: Kupac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await kupacRepository.DeleteKupacAsync(id);
            await unitOfWork.Kupac.SaveAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                kupacRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

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
using AutoMapper;
using WebNarudzbe.Mappings;
using WebNarudzbe.Models;

namespace WebNarudzba.Controllers
{
    public class ProizvodController : Controller
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

        public ProizvodController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: Proizvod
        public async Task<ActionResult> Index()
        {
            ///<c>
            ///var proizvod = db.Proizvod.Include(p => p.Dobavljac);
            ///return View(await proizvod.ToListAsync());
            ///</c>

            IList<Proizvod> proizvod = await unitOfWork.Proizvod.GetAll();
            IList<ProizvodDTO> proizvodViewModel = Mapper.Map<IList<Proizvod>, IList<ProizvodDTO>>(proizvod);
            return View(proizvodViewModel);
        }

        // GET: Proizvod/Details/5
        public async Task<ActionResult> Details(int id)
        {

            Proizvod proizvod = await unitOfWork.Proizvod.GetByIdAsync(id);
            ProizvodDTO proizvodViewModel = Mapper.Map<Proizvod, ProizvodDTO>(proizvod);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dobavljac_ID = new SelectList(db.Dobavljac, "ID", "Naziv", proizvod.Dobavljac_ID);
            return View(proizvodViewModel);
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
        public async Task<ActionResult> Create([Bind(Include = "ID,Naziv,Cijena,Dobavljac_ID")] ProizvodDTO proizvod)
        {
            if (ModelState.IsValid)
            {
                Proizvod proizvodViewModel = Mapper.Map<ProizvodDTO, Proizvod>(proizvod);
                await unitOfWork.Proizvod.InsertAsync(proizvodViewModel);
                return RedirectToAction("Index");
            }

            ViewBag.Dobavljac_ID = new SelectList(db.Dobavljac, "ID", "Naziv", proizvod.Dobavljac_ID);
            return View(proizvod);
        }

        // GET: Proizvod/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Proizvod proizvod = await unitOfWork.Proizvod.GetByIdAsync(id);
            ProizvodDTO proizvodViewModel = Mapper.Map<Proizvod, ProizvodDTO>(proizvod);
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dobavljac_ID = new SelectList(db.Dobavljac, "ID", "Naziv", proizvod.Dobavljac_ID);
            return View(proizvodViewModel);
        }

        // POST: Proizvod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Naziv,Cijena,Dobavljac_ID")] ProizvodDTO proizvod)
        {
            if (ModelState.IsValid)
            {
                
                Proizvod proizvodViewModel = Mapper.Map<ProizvodDTO, Proizvod>(proizvod);
                await unitOfWork.Proizvod.UpdateAsync(proizvodViewModel);
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
                unitOfWork.Proizvod.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

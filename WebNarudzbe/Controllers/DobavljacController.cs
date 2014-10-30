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
using AutoMapper;
using WebNarudzbe.Models;

namespace WebNarudzba.Controllers
{
    public class DobavljacController : Controller
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

        public DobavljacController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Dobavljac
        public async Task<ActionResult> Index()
        {
            #region
            ///<remarks>
            ///return View(await genericRepository.GetAll()); umjesto direktnog pristupa genericrepository-u, sada ide preko unitofwork
            ///GET: Mapping iz DAL.modela u serviceLayer.model.dobavljacDTO viewmodel
            ///POST: Mapping iz dobavljacDTO viewmodela u DAL.model
            ///</remarks>

            ///<example>
            ///Automapper radi upravo ovo:
            ///Dobavljac dobavljac = await unitOfWork.Dobavljac.GetAll();
            ///Dobavljac dobavljacDTO = new Dobavljac()
            ///{
            ///     adresa = dobavljac.adresa,
            ///     naziv = dobavljac.naziv,
            ///     telefon = dobavljac.telefon
            ///};     
            ///View(dobavljacDTO);
            ///</example>
            #endregion            

            IList<Dobavljac> dobavljac = await unitOfWork.Dobavljac.GetAll();
            IList<DobavljacDTO> dobavljacViewModel = Mapper.Map<IList<Dobavljac>,IList<DobavljacDTO>>(dobavljac);

            return View(dobavljacViewModel);

        }

        // GET: Dobavljac/Details/5
        public async Task<ActionResult> Details(int id)
        {

            Dobavljac dobavljac = await unitOfWork.Dobavljac.GetByIdAsync(id);
            DobavljacDTO dobavljacViewModel = Mapper.Map<Dobavljac, DobavljacDTO>(dobavljac);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljacViewModel);
        }

        //// GET: Partial - Dobavljac/Details/5
        //public async Task<ActionResult> PartialEdit(int id)
        //{
        //    Dobavljac dobavljac = await unitOfWork.Dobavljac.GetByIdAsync(id);
        //    DobavljacDTO dobavljacViewModel = Mapper.Map<Dobavljac, DobavljacDTO>(dobavljac);
        //    if (dobavljac == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return PartialView("PartialEdit", dobavljacViewModel);
        //}


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
        public async Task<ActionResult> Create([Bind(Include = "ID,Naziv,Adresa,Telefon")] DobavljacDTO dobavljac)
        {

            if (ModelState.IsValid)
            {
                Dobavljac dobavljacViewModel = Mapper.Map<DobavljacDTO, Dobavljac>(dobavljac);
                await unitOfWork.Dobavljac.InsertAsync(dobavljacViewModel);
                return RedirectToAction("Index");
            }

            return View(dobavljac);
        }

        // GET: Dobavljac/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Dobavljac dobavljac = await unitOfWork.Dobavljac.GetByIdAsync(id);
            DobavljacDTO dobavljacViewModel = Mapper.Map<Dobavljac, DobavljacDTO>(dobavljac);
            if (dobavljac == null)
            {
                return HttpNotFound();
            }
            return View(dobavljacViewModel);
        }

        // POST: Dobavljac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Naziv,Adresa,Telefon")] DobavljacDTO dobavljac)
        {
            if (ModelState.IsValid)
            {
                Dobavljac dobavljacViewModel = Mapper.Map<DobavljacDTO, Dobavljac>(dobavljac);
                await unitOfWork.Dobavljac.UpdateAsync(dobavljacViewModel);
                return RedirectToAction("Index");
            }
            return View(dobavljac);
        }

        // GET: Dobavljac/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Dobavljac dobavljac = await unitOfWork.Dobavljac.GetByIdAsync(id);
            await unitOfWork.Dobavljac.DeleteAsync(dobavljac);
            return RedirectToAction("Index");
        
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
                unitOfWork.Dobavljac.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

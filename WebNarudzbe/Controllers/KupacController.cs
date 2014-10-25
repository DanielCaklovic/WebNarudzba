﻿using System;
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
    public class KupacController : Controller
    {
        private WebNarudzbaContext db = new WebNarudzbaContext();

        // private GenericRepository<Kupac> genericRepository = new GenericRepository<Kupac>(new WebNarudzbaContext());
        //private UnitOfWork unitOfWork = new UnitOfWork();

        //Constructor injection
        private readonly IUnitOfWork unitOfWork;

        public KupacController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Kupac
        public async Task<ActionResult> Index()
        {
            return View(await unitOfWork.Kupac.GetAll());
        }

        // GET: Kupac/Details/5
        public async Task<ActionResult> Details(int id)
        {

            Kupac kupac = await unitOfWork.Kupac.GetByIdAsync(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupac);
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
        public async Task<ActionResult> Create([Bind(Include = "ID,Ime,Prezime,Adresa,Telefon")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Kupac.InsertAsync(kupac);
                return RedirectToAction("Index");
            }

            return View(kupac);
        }

        // GET: Kupac/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            Kupac kupac = await unitOfWork.Kupac.GetByIdAsync(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupac);
        }

        // POST: Kupac/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Ime,Prezime,Adresa,Telefon")] Kupac kupac)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Kupac.UpdateAsync(kupac);
                return RedirectToAction("Index");
            }
            return View(kupac);
        }

        // GET: Kupac/Delete/5
        public async Task<ActionResult> Delete(int id)
        {

            Kupac kupac = await unitOfWork.Kupac.GetByIdAsync(id);
            if (kupac == null)
            {
                return HttpNotFound();
            }
            return View(kupac);
        }

        // POST: Kupac/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kupac kupac = await unitOfWork.Kupac.GetByIdAsync(id);
            await unitOfWork.Kupac.DeleteAsync(kupac);
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
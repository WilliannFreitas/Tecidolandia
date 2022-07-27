using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tecidolandia.Context;
using Tecidolandia.Models.Entities;

namespace Tecidolandia
{
    public class VendedoresController : Controller
    {
        private TecidolandiaContext db = new TecidolandiaContext();

        // GET: Vendedores
        public ActionResult Index()
        {
            return View(db.Vendedores.ToList());
        }

        // GET: Vendedores/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedores.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // GET: Vendedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendedores/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVendedor,Nome,DtNasc")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Vendedores.Add(vendedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendedor);
        }

        // GET: Vendedores/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedores.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedores/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVendedor,Nome,DtNasc")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendedor);
        }

        // GET: Vendedores/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vendedor vendedor = db.Vendedores.Find(id);
            if (vendedor == null)
            {
                return HttpNotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Vendedor vendedor = db.Vendedores.Find(id);
            db.Vendedores.Remove(vendedor);
            db.SaveChanges();
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

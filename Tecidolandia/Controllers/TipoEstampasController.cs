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
    [Authorize]
    public class TipoEstampasController : Controller
    {
        private TecidolandiaContext db = new TecidolandiaContext();

        // GET: TipoEstampas
        public ActionResult Index()
        {
            return View(db.TipoEstampas.ToList());
        }

        // GET: TipoEstampas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEstampa tipoEstampa = db.TipoEstampas.Find(id);
            if (tipoEstampa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEstampa);
        }

        // GET: TipoEstampas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEstampas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoEstampa,Nome,Descricao,VlMetro")] TipoEstampa tipoEstampa)
        {
            if (ModelState.IsValid)
            {
                db.TipoEstampas.Add(tipoEstampa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEstampa);
        }

        // GET: TipoEstampas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEstampa tipoEstampa = db.TipoEstampas.Find(id);
            if (tipoEstampa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEstampa);
        }

        // POST: TipoEstampas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoEstampa,Nome,Descricao,VlMetro")] TipoEstampa tipoEstampa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEstampa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEstampa);
        }

        // GET: TipoEstampas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEstampa tipoEstampa = db.TipoEstampas.Find(id);
            if (tipoEstampa == null)
            {
                return HttpNotFound();
            }
            return View(tipoEstampa);
        }

        // POST: TipoEstampas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TipoEstampa tipoEstampa = db.TipoEstampas.Find(id);
            db.TipoEstampas.Remove(tipoEstampa);
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

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
    public class TelefonesController : Controller
    {
        private TecidolandiaContext db = new TecidolandiaContext();

        // GET: Telefones
        public ActionResult Index()
        {
            var telefones = db.Telefones.Include(t => t.Cliente).Include(t => t.Vendedor);
            return View(telefones.ToList());
        }

        // GET: Telefones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefones.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // GET: Telefones/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto");
            ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome");
            return View();
        }

        // POST: Telefones/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTelefone,Ddd,NuTelefone,IdCliente,IdVendedor,Ativo")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Telefones.Add(telefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto", telefone.IdCliente);
            ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome", telefone.IdVendedor);
            return View(telefone);
        }

        // GET: Telefones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefones.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto", telefone.IdCliente);
            ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome", telefone.IdVendedor);
            return View(telefone);
        }

        // POST: Telefones/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTelefone,Ddd,NuTelefone,IdCliente,IdVendedor,Ativo")] Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto", telefone.IdCliente);
            ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome", telefone.IdVendedor);
            return View(telefone);
        }

        // GET: Telefones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefone telefone = db.Telefones.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        // POST: Telefones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefone telefone = db.Telefones.Find(id);
            db.Telefones.Remove(telefone);
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

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
    public class bkpVendasController : Controller
    {
        private TecidolandiaContext db = new TecidolandiaContext();

        // GET: Vendas
        public ActionResult Index()
        {
            var vendas = db.Vendas.Include(v => v.Clientes).Include(v => v.Status).Include(v => v.Vendedores);
            return View(vendas.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto");
            ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "NmStatus");
            ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome");
            return View();
        }

        // POST: Vendas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVenda,DtRegistro,IdCliente,IdVendedor,IdStatus,VlTotal")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Vendas.Add(venda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto", venda.IdCliente);
            ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "NmStatus", venda.IdStatus);
            ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome", venda.IdVendedor);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto", venda.IdCliente);
            ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "NmStatus", venda.IdStatus);
            ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome", venda.IdVendedor);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVenda,DtRegistro,IdCliente,IdVendedor,IdStatus,VlTotal")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto", venda.IdCliente);
            ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "NmStatus", venda.IdStatus);
            ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome", venda.IdVendedor);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = db.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Venda venda = db.Vendas.Find(id);
            db.Vendas.Remove(venda);
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

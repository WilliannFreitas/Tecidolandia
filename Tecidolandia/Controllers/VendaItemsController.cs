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
using Tecidolandia.Models.ViewEntities;

namespace Tecidolandia
{
    public class VendaItemsController : Controller
    {
        private TecidolandiaContext db = new TecidolandiaContext();
        private OrdemDeVendaViewModel vmOrdemDeVendaViewModel = new OrdemDeVendaViewModel();
        // GET: VendaItems
        public ActionResult Index()
        {
            var vendaItems = db.VendaItems.Include(v => v.Produtos).Include(v => v.Vendas);
            return View(vendaItems.ToList());
        }

        // GET: VendaItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaItem vendaItem = db.VendaItems.Find(id);
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            return View(vendaItem);
        }

        // GET: VendaItems/Create
        public ActionResult Create()
        {
            ViewBag.IdProduto = new SelectList(db.Produtos, "IdProduto", "Nome");
            ViewBag.IdVenda = new SelectList(db.Vendas, "IdVenda", "IdVenda");
            return View();
        }

        // POST: VendaItems/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVendaItem,IdProduto,IdVenda,Quantidade,VlTotal")] VendaItem vendaItem)
        {
            if (ModelState.IsValid)
            {
                db.VendaItems.Add(vendaItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProduto = new SelectList(db.Produtos, "IdProduto", "Nome", vendaItem.IdProduto);
            ViewBag.IdVenda = new SelectList(db.Vendas, "IdVenda", "IdVenda", vendaItem.IdVenda);
            return View(vendaItem);
        }

        // GET: VendaItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaItem vendaItem = db.VendaItems.Find(id);
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProduto = new SelectList(db.Produtos, "IdProduto", "Nome", vendaItem.IdProduto);
            ViewBag.IdVenda = new SelectList(db.Vendas, "IdVenda", "IdVenda", vendaItem.IdVenda);
            return View(vendaItem);
        }

        // POST: VendaItems/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVendaItem,IdProduto,IdVenda,Quantidade,VlTotal")] VendaItem vendaItem)
        {
            var vendaController = new VendasController();
            if (ModelState.IsValid)
            {
                db.Entry(vendaItem).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("CriarOuEditarOrdemDeVenda", "Vendas", new { id = vendaItem.IdVenda });
        }

        // GET: VendaItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaItem vendaItem = db.VendaItems.Find(id);
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            return View(vendaItem);
        }

        // POST: VendaItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendaItem vendaItem = db.VendaItems.Find(id);
            db.VendaItems.Remove(vendaItem);
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

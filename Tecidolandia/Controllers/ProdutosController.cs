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
    public class ProdutosController : Controller
    {
        private TecidolandiaContext db = new TecidolandiaContext();

        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.TipoEstampas);
            return View(produtos.ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoEstampa = new SelectList(db.TipoEstampas, "IdTipoEstampa", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduto,Nome,Descricao,Largura,Altura,IdTipoEstampa")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.DtRegistro = DateTime.Now;
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoEstampa = new SelectList(db.TipoEstampas, "IdTipoEstampa", "Nome", produto.IdTipoEstampa);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoEstampa = new SelectList(db.TipoEstampas, "IdTipoEstampa", "Nome", produto.IdTipoEstampa);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduto,Nome,Descricao,Largura,Altura,IdTipoEstampa")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.DtRegistro = DateTime.Now;
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoEstampa = new SelectList(db.TipoEstampas, "IdTipoEstampa", "Nome", produto.IdTipoEstampa);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
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

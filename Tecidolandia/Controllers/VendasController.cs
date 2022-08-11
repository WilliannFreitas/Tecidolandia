using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tecidolandia.Context;
using Tecidolandia.Extensions;
using Tecidolandia.Models.Entities;
using Tecidolandia.Models.ViewEntities;

namespace Tecidolandia
{
    public class VendasController : Controller
    {
        private TecidolandiaContext db = new TecidolandiaContext();

        #region TecidolandiaIndex
        // GET: Vendas
        public ActionResult Index()
        {
            var vendas = db.Vendas.Include(v => v.Clientes).Include(v => v.Status).Include(v => v.Vendedores);
            return View(vendas.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Criar/Editar
        public ActionResult CriarOuEditarOrdemDeVenda(long? idVenda)
        {

            var vm = new OrdemDeVendaViewModel();

            if (idVenda > 0)
                vm = this.Edit(idVenda);
            else
                vm = this.Create();


            return View("CriarOuEditarOrdemDeVenda", vm);
        }

        // GET: Vendas/Create
        private OrdemDeVendaViewModel Create()
        {
            var vm = new OrdemDeVendaViewModel();
            vm.VendedorList = db.Vendedores.ToList();
            vm.ClienteList = db.Clientes.ToList();
            vm.StatusList = db.Status.ToList();


            ViewBag.HasQuerysTicket = 1;

            return vm;
        }


        // GET: Vendas/Edit/5
        private OrdemDeVendaViewModel Edit(long? id)
        {
            var vm = new OrdemDeVendaViewModel();

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Venda venda = db.Vendas.Find(id);
            //if (venda == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "NmCompleto", venda.IdCliente);
            //ViewBag.IdStatus = new SelectList(db.Status, "IdStatus", "NmStatus", venda.IdStatus);
            //ViewBag.IdVendedor = new SelectList(db.Vendedores, "IdVendedor", "Nome", venda.IdVendedor);

            return vm;

            //return View(venda);
        }

        #endregion

        #region SalvarOrdem
        [HttpPost]
        public JsonResult SalvarVenda(Venda venda)
        {

            try
            {
                if (venda.IdVenda == 0 || venda.IdVenda == null)
                {
                    venda.DtRegistro = DateTime.Now;
                    db.Vendas.Add(venda);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(venda).State = EntityState.Modified;
                    db.SaveChanges();
                }

                var vm = new OrdemDeVendaViewModel();
                vm.Venda = venda;

                var partial = PartialView("_IdVenda", vm).RenderToString();

                //VerifyIfCreateDirectory(ticket.IdTicket.ToString(), "Logs");

                return Json(new { status = "OK", description = "Venda gerada com Sucesso!", partialView = partial }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                ViewBag.MsgErroVenda = "Ocorreu um erro! " + ex.Message.ToString();

                //VerifyIfCreateDirectory(ticket.IdTicket.ToString(), "Logs");
                return Json(new { status = "NOK", description = "Erro ao Salvar - Exception: " + ex.Message.ToString() + " | InnerException" + ex.InnerException.InnerException.ToString() + " | StackTrace" + ex.StackTrace.ToString(), IdTicket = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}

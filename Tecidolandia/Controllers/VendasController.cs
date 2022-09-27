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
        private OrdemDeVendaViewModel vm = new OrdemDeVendaViewModel();

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
        //[HttpGet]
        public ActionResult CriarOuEditarOrdemDeVenda(long? idVenda)
        {
            if (idVenda > 0)
                vm = this.Edit(idVenda);
            else
                vm = this.Create();

            return View("CriarOuEditarOrdemDeVenda", vm);
        }

        // GET: Vendas/Create
        private OrdemDeVendaViewModel Create()
        {
            var statusAtivos = db.Status.Where(a => a.StatusVenda == true).ToList();

            vm.VendedorList = db.Vendedores.ToList();
            vm.ClienteList = db.Clientes.ToList();
            vm.StatusList = statusAtivos;
            vm.ProdutoList = db.Produtos.Include(p => p.TipoEstampas).ToList();
            vm.VendaItemValor = new List<VendaItemValor>();

            return vm;
        }

        // GET: Vendas/Edit/5
        private OrdemDeVendaViewModel Edit(long? id)
        {
            //criar edição.
            return vm;
        }

        #endregion

        #region Salvar Venda
        [HttpPost]
        public JsonResult SalvarEditarVenda(Venda venda)
        {
            try
            {
                if (venda.IdVenda == 0)
                {
                    var vendaStatus = db.Status.Where(a => a.NmStatus.ToUpper() == "VENDA INICIADA").FirstOrDefault();
                    venda.IdStatus = vendaStatus.IdStatus;

                    venda.DtRegistro = DateTime.Now;
                    db.Vendas.Add(venda);
                    db.SaveChanges();
                }
                else
                {
                    var vendaStatus = db.Vendas.Where(a => a.IdVenda == venda.IdVenda).FirstOrDefault();
                    vendaStatus.IdStatus = venda.IdStatus;

                    db.Entry(vendaStatus).State = EntityState.Modified;
                    db.SaveChanges();
                }

                vm.Venda = venda;

                var partial = PartialView("_IdVenda", vm).RenderToString();
                return Json(new { status = "OK", description = "Venda gerada com Sucesso!", partialView = partial }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.MsgErroVenda = "Ocorreu um erro! " + ex.Message.ToString();
                return Json(new { status = "NOK", description = "Erro ao Salvar - Exception: " + ex.Message.ToString() + " | InnerException" + ex.InnerException.InnerException.ToString() + " | StackTrace" + ex.StackTrace.ToString(), IdTicket = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Mostrar Detalhes do Clientes
        [HttpPost]
        public JsonResult MostrarDetalhesCliente(long idCliente)
        {
            try
            {
                vm.ClienteSelecionado = db.Clientes.Where(b => b.IdCliente == idCliente).FirstOrDefault();
                var partial = PartialView("_PartialDetalhesCliente", vm).RenderToString();
                return Json(new { status = "OK", description = "Sucesso!", partialView = partial }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.MsgErroVenda = "Ocorreu um erro! " + ex.Message.ToString();
                return Json(new { status = "NOK", description = "Erro ao Salvar - Exception: " + ex.Message.ToString() + " | InnerException" + ex.InnerException.InnerException.ToString() + " | StackTrace" + ex.StackTrace.ToString(), IdTicket = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region SalvarItemVenda \ ListaVenda
        [HttpPost]
        public JsonResult SalvarItemVenda(VendaItem itemVenda)
        {
            try
            {
                var produtoList = db.Produtos.Where(b => b.IdProduto == itemVenda.IdProduto).Include(p => p.TipoEstampas).FirstOrDefault();
                itemVenda.VlTotal = (itemVenda.Quantidade * produtoList.TipoEstampas.VlMetro);

                if (itemVenda.IdVendaItem == 0)
                {
                    db.VendaItems.Add(itemVenda);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(itemVenda).State = EntityState.Modified;
                    db.SaveChanges();
                }

                var vendaItemList = db.VendaItems.Where(b => b.IdVenda == itemVenda.IdVenda).Include(p => p.Produtos).ToList();
                var venda = db.Vendas.Where(b => b.IdVenda == itemVenda.IdVenda).FirstOrDefault();

                double valorTotal = 0;
                vm.VendaItemValor = new List<VendaItemValor>();

                foreach (VendaItem item in vendaItemList)
                {
                    var auxVendaItemValor = new VendaItemValor();
                    auxVendaItemValor.IdProduto = item.IdProduto;
                    auxVendaItemValor.IdVenda = item.IdVenda;
                    auxVendaItemValor.IdVendaItem = item.IdVendaItem;
                    auxVendaItemValor.Quantidade = item.Quantidade;
                    auxVendaItemValor.Vendas = item.Vendas;
                    auxVendaItemValor.VlTotal = item.VlTotal;
                    auxVendaItemValor.ValorUnitario = db.Produtos.Where(b => b.IdProduto == item.IdProduto).Include(p => p.TipoEstampas).FirstOrDefault().TipoEstampas.VlMetro;
                    auxVendaItemValor.Produtos = item.Produtos;

                    vm.VendaItemValor.Add(auxVendaItemValor);
                    valorTotal += auxVendaItemValor.VlTotal;
                }

                venda.VlTotal = valorTotal;

                db.Entry(venda).State = EntityState.Modified;
                db.SaveChanges();

                vm.Venda = venda;

                var partial = PartialView("_PartialItemVenda", vm).RenderToString();

                return Json(new { status = "OK", description = "Venda gerada com Sucesso!", partialView = partial }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.MsgErroVenda = "Ocorreu um erro! " + ex.Message.ToString();
                return Json(new { status = "NOK", description = "Erro ao Salvar - Exception: " + ex.Message.ToString() + " | InnerException" + ex.InnerException.InnerException.ToString() + " | StackTrace" + ex.StackTrace.ToString(), IdTicket = 0 }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}

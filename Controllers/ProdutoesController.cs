using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vxdlite.Models;

namespace vxdlite.Controllers
{
    public class ProdutoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produtoes
        public ActionResult Index()
        {
            var produtoes = db.Produtoes.Include(p => p.Categoria).Include(p => p.Fabricante);
            return View(produtoes.ToList());
        }

        // GET: Produtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtoes/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "CategoriaNome");
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "FabricanteID", "FabricanteNome");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,ProdutoNome,ProdutoVisivel,Descricao,ImagemPath,PrecoUnitario,Estoque,CategoriaID,FabricanteID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "CategoriaNome", produto.CategoriaID);
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "FabricanteID", "FabricanteNome", produto.FabricanteID);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "CategoriaNome", produto.CategoriaID);
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "FabricanteID", "FabricanteNome", produto.FabricanteID);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,ProdutoNome,ProdutoVisivel,Descricao,ImagemPath,PrecoUnitario,Estoque,CategoriaID,FabricanteID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "CategoriaNome", produto.CategoriaID);
            ViewBag.FabricanteID = new SelectList(db.Fabricantes, "FabricanteID", "FabricanteNome", produto.FabricanteID);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
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

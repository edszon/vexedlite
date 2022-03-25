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
    public class ProdutoCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProdutoComments
        public ActionResult Index()
        {
            var produtoComments = db.ProdutoComments.Include(p => p.Produto);
            return View(produtoComments.ToList());
        }

        // GET: ProdutoComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoComment produtoComment = db.ProdutoComments.Find(id);
            if (produtoComment == null)
            {
                return HttpNotFound();
            }
            return View(produtoComment);
        }

        // GET: ProdutoComments/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoID = new SelectList(db.Produtoes, "ProdutoID", "ProdutoNome");
            return View();
        }

        // POST: ProdutoComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Comments,ThisDateTime,ProdutoID,Rating")] ProdutoComment produtoComment)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoComments.Add(produtoComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoID = new SelectList(db.Produtoes, "ProdutoID", "ProdutoNome", produtoComment.ProdutoID);
            return View(produtoComment);
        }

        // GET: ProdutoComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoComment produtoComment = db.ProdutoComments.Find(id);
            if (produtoComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoID = new SelectList(db.Produtoes, "ProdutoID", "ProdutoNome", produtoComment.ProdutoID);
            return View(produtoComment);
        }

        // POST: ProdutoComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Comments,ThisDateTime,ProdutoID,Rating")] ProdutoComment produtoComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoID = new SelectList(db.Produtoes, "ProdutoID", "ProdutoNome", produtoComment.ProdutoID);
            return View(produtoComment);
        }

        // GET: ProdutoComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoComment produtoComment = db.ProdutoComments.Find(id);
            if (produtoComment == null)
            {
                return HttpNotFound();
            }
            return View(produtoComment);
        }

        // POST: ProdutoComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoComment produtoComment = db.ProdutoComments.Find(id);
            db.ProdutoComments.Remove(produtoComment);
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

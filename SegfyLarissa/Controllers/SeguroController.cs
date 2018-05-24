using SegfyLarissa.Context;
using SegfyLarissa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SegfyLarissa.Controllers
{
    public class SeguroController : Controller
    {
        SeguroContext db = new SeguroContext();
        // GET: Seguro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Seguro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Seguro seguro = db.Seguros.Find(id);

            if (seguro == null)
                return HttpNotFound();

            return View(seguro);
        }

        // GET: Seguro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seguro/Create
        [HttpPost]
        public ActionResult Create(Seguro seguro)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    string msgErro = seguro.ValidaObjetoSegurado(seguro.ObjSegurado);
                    if (!String.IsNullOrEmpty(msgErro))
                        return RedirectToAction("ErrorObject", new { msg = msgErro });
                    else
                    {
                        if (!Util.ValidaCPF(seguro.DocCliente) && !Util.ValidaCNPJ(seguro.DocCliente))
                        {
                            return RedirectToAction("ErrorObject", new { msg = "CPF ou CNPJ inválido para Doc. do cliente." });
                        }
                            
                    }

                    db.Seguros.Add(seguro);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(seguro);

            }
            catch
            {
                return View();
            }
        }

        // GET: Seguro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Seguro seguro = db.Seguros.Find(id);

            if (seguro == null)
                return HttpNotFound();

            return View(seguro);
        }

        // POST: Seguro/Edit/5
        [HttpPost]
        public ActionResult Edit(Seguro seguro)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    string msgErro = seguro.ValidaObjetoSegurado(seguro.ObjSegurado);
                    if (!String.IsNullOrEmpty(msgErro))
                        return RedirectToAction("ErrorObject", new { msg = msgErro });
                    else
                    {
                        if (!Util.ValidaCPF(seguro.DocCliente) && !Util.ValidaCNPJ(seguro.DocCliente))
                        {
                            return RedirectToAction("ErrorObject", new { msg = "CPF ou CNPJ inválido para Doc. do cliente." });
                        }

                    }

                    db.Entry(seguro).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(seguro);
            }
            catch
            {
                return View();
            }
        }

        // GET: Seguro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Seguro seguro = db.Seguros.Find(id);
            if (seguro == null)
                return HttpNotFound();

            return View(seguro);
        }

        // POST: Seguro/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Seguro seg)
        {
            try
            {
                // TODO: Add delete logic here
                Seguro seguro = new Seguro();
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                    seguro = db.Seguros.Find(id);
                    if (seguro == null)
                        return HttpNotFound();

                    db.Seguros.Remove(seguro);
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ShowAll()
        {
            return View(db.Seguros.ToList());
        }

        // GET: Seguro/EditFromMenu/5
        public ActionResult EditFromMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditFromMenu(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Seguro seguro = new Seguro();
                seguro = db.Seguros.Find(id);
                if (seguro == null)
                    return RedirectToAction("Error");
                return RedirectToAction("Edit", new { id = id});

            }
            catch
            {
                return View();
            }
        }

        // GET: Seguro/DeleteFromMenu/5
        public ActionResult DeleteFromMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteFromMenu(int? id)
        {
            try
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                Seguro seguro = new Seguro();
                seguro = db.Seguros.Find(id);
                if (seguro == null)
                    return RedirectToAction("Error");
                return RedirectToAction("Delete", new { id = id });

            }
            catch
            {
                return View();
            }
        }

        // GET: Seguro/FindAuto/5
        public ActionResult FindAuto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindAuto(Seguro seg)
        {
            try
            {
                var seguro = db.Seguros.Where(s => s.ObjSegurado == seg.ObjSegurado && s.Tipo == 0).FirstOrDefault();

                if (seguro == null)
                    return RedirectToAction("Error");

                return RedirectToAction("Details", new { id = seguro.ID});
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult ErrorObject(string msg)
        {
            ViewBag.ErrorMessage = msg;
            return View();
        }
    }
}

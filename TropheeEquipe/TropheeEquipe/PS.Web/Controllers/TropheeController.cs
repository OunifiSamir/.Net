using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Domain;
using PS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class TropheeController : Controller
    {
        ITropheeService ts;
        IEquipeService es; 
        // GET: TropheeController
        public TropheeController (ITropheeService ts, IEquipeService es)
        {
            this.ts = ts;
            this.es = es;
        }
        public ActionResult Index()
        {
            return View(ts.GetMany());
        }

        // GET: TropheeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TropheeController/Create
        public ActionResult Create()
        {
            ViewBag.EquipeId = new SelectList(es.GetMany(), "EquipeId", "NomEquipe");
            return View();
        }

        // POST: TropheeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trophee tr)
        {
            ts.Add(tr);
            ts.Commit();
            return RedirectToAction("Index");

        }

        // GET: TropheeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TropheeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TropheeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TropheeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

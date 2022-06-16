using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PS.Domain;
using PS.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class EquipeController : Controller
    {
        IEquipeService es;
        // GET: EquipeController
        public EquipeController(IEquipeService es)
        {
            this.es = es;
        }
        public ActionResult Index(String SearchString)
        {
            if (SearchString != null)
                return View(es.GetMany(e => e.NomEquipe.Contains(SearchString)));

            else
                return View(es.GetMany());
        }

        // GET: EquipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipe client, IFormFile file)
        {
            client.Logo = file.FileName;
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
               file.FileName);
                using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            es.Add(client);
            es.Commit();
            return RedirectToAction("Index");
        }

        // GET: EquipeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipeController/Edit/5
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

        // GET: EquipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipeController/Delete/5
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

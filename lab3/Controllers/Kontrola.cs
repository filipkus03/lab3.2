using lab3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class Kontrola : Controller
    {
        private static IList<kontrola> Lista = new List<kontrola>()
        {
            new kontrola() {Id = 1, Name = "Lot AirCraft", Description = "Tanie Loty", FomTo = "From Cracow To Parise", DateTime = "2024/04/12 12,16" }
        };

        // GET: Kontrola
        public ActionResult Index()
        {
            return View(Lista);
        }

        // GET: Kontrola/Details/5
        public ActionResult Details(int id)
        {
            return View(Lista.FirstOrDefault(x=>x.Id==id));
        }

        // GET: Kontrola/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kontrola/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kontrola lista)
        {
            lista.Id = Lista.Count + 1;
            Lista.Add(lista);
            return RedirectToAction();
        }

        // GET: Kontrola/Edit/5
        public ActionResult Edit(int id)
        {
            var modelToEdit = Lista.FirstOrDefault(x => x.Id == id);
            return View(modelToEdit);

        }

        // POST: Kontrola/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, kontrola editedModel)
        {
            try
            {
                var modelToEdit = Lista.FirstOrDefault(x => x.Id == id);

                if (modelToEdit != null)
                {
                    // Update properties of the existing model
                    modelToEdit.Name = editedModel.Name;
                    modelToEdit.Description = editedModel.Description;
                    // Update other properties as needed

                    return RedirectToAction(nameof(Index));
                }

                return NotFound(); // Handle the case where the item with the specified id is not found
            }
            catch
            {
                return View();
            }
        }

        // GET: Kontrola/Delete/5
        public ActionResult Delete(int id)
        {
            var modelToDelete = Lista.FirstOrDefault(x => x.Id == id);
            return View(modelToDelete);
        }

        // POST: Kontrola/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var modelToDelete = Lista.FirstOrDefault(x => x.Id == id);

                if (modelToDelete != null)
                {
                    Lista.Remove(modelToDelete);
                    return RedirectToAction(nameof(Index));
                }

                return NotFound(); // Handle the case where the item with the specified id is not found
            }
            catch
            {
                return View();
            }
        }
    }
}

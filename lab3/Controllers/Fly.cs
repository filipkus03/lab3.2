using lab3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class Fly : Controller
    {
        private static readonly IList<fly> flies = new List<fly>
        {
            new fly() {Id = 1,Name = "Lot",Description = "Lot jak lot", From = "Cracow", To = "Niewiem", Pilot = "Jurek"}
        };
        // GET: Fly
        public ActionResult Index()
        {
            return View(flies);
        }

        // GET: Fly/Details/5
        public ActionResult Details(int id)
        {
            return View(flies.FirstOrDefault(x => x.Id == id));
        }

        // GET: Fly/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fly/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(fly lista)
        {
            lista.Id = flies.Count + 1;
            flies.Add(lista);
            return RedirectToAction();
        }

        // GET: Fly/Edit/5
        public ActionResult Edit(int id)
        {
            var modelToEdit = flies.FirstOrDefault(x => x.Id == id);
            return View(modelToEdit);

        }

        // POST: Fly/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, kontrola editedModel)
        {
            try
            {
                var modelToEdit = flies.FirstOrDefault(x => x.Id == id);

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

        // GET: Fly/Delete/5
        public ActionResult Delete(int id)
        {
            var modelToDelete = flies.FirstOrDefault(x => x.Id == id);
            return View(modelToDelete);
        }

        // POST: Fly/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var modelToDelete = flies.FirstOrDefault(x => x.Id == id);

                if (modelToDelete != null)
                {
                    flies.Remove(modelToDelete);
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

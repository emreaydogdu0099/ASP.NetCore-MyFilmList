using Microsoft.AspNetCore.Mvc;
using MyFilmListWeb.Data;
using MyFilmListWeb.Models;

namespace MyFilmListWeb.Controllers
{
    public class FilmController : Controller
    {
        private readonly ApplicationDbContext _db;

        public FilmController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Film> objCategoryList = _db.Films;
            return View(objCategoryList);
        }
        //GET
        public IActionResult Add()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Film obj)
        {
            if (obj.Name == obj.IMDBRating.ToString())
            {
                ModelState.AddModelError("Name","The IMDBRating cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Films.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Film added succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            var filmFromDb = _db.Films.Find(id);
            //var filmFromDbFirst = _db.Films.FirstOrDefault(x => x.Id == id);
            //var filmFromDbSingle = _db.Films.SingleOrDefault(x => x.Id == id);

            if (filmFromDb == null)
            {
                return NotFound();
            }

            return View(filmFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Film obj)
        {
            if (obj.Name == obj.IMDBRating.ToString())
            {
                ModelState.AddModelError("Name", "The IMDBRating cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Films.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Film updated succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var filmFromDb = _db.Films.Find(id);
            //var filmFromDbFirst = _db.Films.FirstOrDefault(x => x.Id == id);
            //var filmFromDbSingle = _db.Films.SingleOrDefault(x => x.Id == id);

            if (filmFromDb == null)
            {
                return NotFound();
            }

            return View(filmFromDb);
        }
        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var filmFromDb = _db.Films.Find(id);
            //var filmFromDbFirst = _db.Films.FirstOrDefault(x => x.Id == id);
            //var filmFromDbSingle = _db.Films.SingleOrDefault(x => x.Id == id);

            if (filmFromDb == null)
            {
                return NotFound();
            }

            _db.Films.Remove(filmFromDb);
                _db.SaveChanges();
            TempData["success"] = "Film deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}

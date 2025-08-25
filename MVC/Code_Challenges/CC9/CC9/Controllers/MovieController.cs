using System.Web.Mvc;
using CC9.Models;
using CC9.Repository;

namespace CC9.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repo = new MovieRepository();

        public ActionResult Index() => View(repo.GetAll());

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id) => View(repo.GetById(id));

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                repo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = repo.GetByYear(year);
            return View(movies);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = repo.GetByDirector(directorName);
            return View(movies);
        }
    }
}

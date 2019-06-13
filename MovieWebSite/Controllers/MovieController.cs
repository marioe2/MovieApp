using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWebSite.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                return View(ctx.GetMovies(0, 100));
            }
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                MovieBLL U = ctx.FindMovieByID(id);
                if (U == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(U);
                }

            }
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MovieBLL m)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {

                    ctx.CreateMovie(m.Title, m.Length, m.Rating, m.Description, m.Trailer, m.CategoryID);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                MovieBLL U = ctx.FindMovieByID(id);
                if (U == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(U);
                }

            }
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieBLL m)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.JustUpdateMovie(id, m.Title, m.Length, m.Rating, m.Description, m.Trailer, m.CategoryID);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                MovieBLL U = ctx.FindMovieByID(id);
                if (U == null)
                {
                    return View("ItemNotFound");
                }
                else
                {
                    return View(U);
                }

            }
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.DeleteMovie(id);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }
    }
}

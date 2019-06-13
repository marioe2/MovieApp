using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieWebSite.Controllers
{
    public class MovieUserController : Controller
    {
        // GET: MovieUser
        public ActionResult Index()
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                
                return View(ctx.GetMovieUsers(0, 100));
            }
        }

        // GET: MovieUser/Details/5
        public ActionResult Details(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                MovieUserBLL U = ctx.FindMovieUserByID(id);
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

        // GET: MovieUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieUser/Create
        [HttpPost]
        public ActionResult Create(MovieUserBLL u)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.CreateMovieUser(u.MovieID, u.UserID, u.Date);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: MovieUser/Edit/5
        public ActionResult Edit(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                MovieUserBLL U = ctx.FindMovieUserByID(id);
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

        // POST: MovieUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieUserBLL u)
        {
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.JustUpdateMovieUser(id, u.MovieID, u.UserID, u.Date);
                    return RedirectToAction("Index");
                }
            }
            catch ( Exception ex)
            {
                return View("Error", ex);
            }
        }

        // GET: MovieUser/Delete/5
        public ActionResult Delete(int id)
        {
            using (ContextBLL ctx = new ContextBLL())
            {
                MovieUserBLL U = ctx.FindMovieUserByID(id);
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

        // POST: MovieUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (ContextBLL ctx = new ContextBLL())
                {
                    ctx.DeleteMovieUser(id);
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

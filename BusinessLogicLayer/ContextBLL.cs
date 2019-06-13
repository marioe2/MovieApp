using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class ContextBLL : IDisposable
    {
        private ContextDAL ctx = new ContextDAL();
        public void Dispose()
        {
            ctx.Dispose();
        }
        public ContextBLL()
        {
            ctx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FlixOnTheNet;Integrated Security=True";
        }

        #region Roles

        public int CreateRole(string Role)
        {
            return ctx.CreateRole(Role);
        }

        public void DeleteRole(int RoleID)
        {
            ctx.DeleteRole(RoleID);
        }

        public void JustUpdateRole(int RoleID, string NewRole)
        {
            ctx.JustUpdateRole(RoleID, NewRole);
        }

        public int SafeUpdateRole(int RoleID, string OldRole, string NewRole)
        {
            return ctx.SafeUpdateRole(RoleID, OldRole, NewRole);
        }

        public RoleBLL FindRoleByID(int RoleID)
        {
            RoleBLL rv = null;
            RoleDAL dal = ctx.FindRoleByID(RoleID);
            if (dal != null)
            {
                rv = new RoleBLL(dal);
            }

            return rv;
        }

        public List<RoleBLL> GetRoles(int skip, int take)
        {
            List<RoleBLL> rv = new List<RoleBLL>();
            List<RoleDAL> dalitems = ctx.GetRoles(skip, take);
            foreach (RoleDAL dal in dalitems)
            {
                rv.Add(new RoleBLL(dal));
            }
            return rv;
        }


        #endregion
        #region Categories
        public int CreateCategory(string Category)
        {
            return ctx.CreateCategory(Category);
        }

        public void DeleteCategory(int CategoryID)
        {
            ctx.DeleteCategory(CategoryID);
        }

        public void JustUpdateCategory(int CategoryID, string NewCategory)
        {
            ctx.JustUpdateCategory(CategoryID, NewCategory);
        }

        public int SafeUpdateCategory(int CategoryID, string OldCategory, string NewCategory)
        {
            return ctx.SafeUpdateCategory(CategoryID, OldCategory, NewCategory);
        }

        public CategoryBLL FindCategoryByID(int CategoryID)
        {
            CategoryBLL rv = null;
            CategoryDAL dal = ctx.FindCategoryByID(CategoryID);
            if (dal != null)
            {
                rv = new CategoryBLL(dal);
            }

            return rv;
        }

        public List<CategoryBLL> GetCategories(int skip, int take)
        {
            List<CategoryBLL> rv = new List<CategoryBLL>();
            List<CategoryDAL> dalitems = ctx.GetCategories(skip, take);
            foreach (CategoryDAL dal in dalitems)
            {
                rv.Add(new CategoryBLL(dal));
            }
            return rv;
        }

        #endregion
        #region Users
        public int CreateUser(string UserName, string Email, string Password, int RoleID)
        {
            return ctx.CreateUser(UserName, Email, Password, RoleID);
        }

        public void DeleteUser(int UserID)
        {
            ctx.DeleteUser(UserID);
        }

        public void JustUpdateUser(int UserID, string NewUserName, string NewEmail, string NewPassword, int NewRoleID)
        {
            ctx.JustUpdateUser(UserID, NewUserName, NewEmail, NewPassword, NewRoleID);
        }

        public int SafeUpdateUser(int UserID, string NewUserName, string NewEmail, string NewPassword, int NewRoleID,
                                              string OldUserName, string OldEmail, string OldPassword, int OldRoleID)
        {
            return ctx.SafeUpdateUser(UserID, NewUserName, NewEmail, NewPassword, NewRoleID, OldUserName, OldEmail, OldPassword, OldRoleID);
        }

        public UserBLL FindUserByID(int UserID)
        {
            UserBLL rv = null;
            UserDAL dal = ctx.FindUserByID(UserID);
            if (dal != null)
            {
                rv = new UserBLL(dal);
            }
            return rv;
        }
        public UserBLL FindUserByEmail(string Email)
        {
            UserBLL rv = null;
            UserDAL dal = ctx.FindUserByEmail(Email);
            if (dal != null)
            {
                rv = new UserBLL(dal);
            }
            return rv;
        }
        public UserBLL FindUserByUserName(string UserName)
        {
            UserBLL rv = null;
            UserDAL dal = ctx.FindUserByUserName(UserName);
            if (dal != null)
            {
                rv = new UserBLL(dal);
            }
            return rv;
        }
        public List<UserBLL> GetUsers(int skip, int take)
        {
            List<UserBLL> rv = new List<UserBLL>();
            List<UserDAL> dalitems = ctx.GetUsers(skip, take);
            foreach (UserDAL dal in dalitems)
            {
                rv.Add(new UserBLL(dal));
            }
            return rv;
        }

        #endregion
        #region Movies
        public int CreateMovie(string Title, int Length, string Rating, string Description, string Trailer, int CategoryID)
        {
            return ctx.CreateMovie(Title, Length, Rating, Description, Trailer, CategoryID);
        }
        public void DeleteMovie(int MovieID)
        {
            ctx.DeleteMovie(MovieID);
        }
        public void JustUpdateMovie(int MovieID, string NewTitle, int NewLength, string NewRating, string NewDescription, string NewTrailer, int NewCategoryID)
        {
            ctx.JustUpdateMovie(MovieID, NewTitle, NewLength, NewRating, NewDescription, NewTrailer, NewCategoryID);
        }
        public int SafeUpdateMovie(int MovieID, string NewTitle, int NewLength, string NewRating, string NewDescription, string NewTrailer, int NewCategoryID,
                                                string OldTitle, int OldLength, string OldRating, string OldDescription, string OldTrailer, int OldCategoryID)
        {
            return ctx.SafeUpdateMovie(MovieID, NewTitle, NewLength, NewRating, NewDescription, NewTrailer, NewCategoryID, OldTitle, OldLength, OldRating, OldDescription, OldTrailer, OldCategoryID);
        }
        public MovieBLL FindMovieByID(int MovieID)
        {
            MovieBLL rv = null;
            MovieDAL dal = ctx.FindMovieByID(MovieID);
            if (dal != null)
            {
                rv = new MovieBLL(dal);
            }
            return rv;
        }
        public List<MovieBLL> GetMovies(int skip, int take)
        {
            List<MovieBLL> rv = new List<MovieBLL>();
            List<MovieDAL> dalitems = ctx.GetMovies(skip, take);
            foreach (MovieDAL dal in dalitems)
            {
                rv.Add(new MovieBLL(dal));
            }
            return rv;
        }
        #endregion
        #region MovieUsers
        public int CreateMovieUser(int MovieID, int UserID, DateTime Date)
        {
            return ctx.CreateMovieUser(MovieID, UserID, Date);
        }
        public void DeleteMovieUser(int MovieUserID)
        {
            ctx.DeleteMovieUser(MovieUserID);
        }
        public void JustUpdateMovieUser(int MovieUserID, int NewMovieID, int NewUserID, DateTime NewDate)
        {
            ctx.JustUpdateMovieUser(MovieUserID, NewMovieID, NewUserID, NewDate);
        }
        public int SafeUpdateMovieUser(int MovieUserID, int NewMovieID, int NewUserID, DateTime NewDate,
                                                        int OldMovieID, int OldUserID, DateTime OldDate)
        {
            return ctx.SafeUpdateMovieUser(MovieUserID, NewMovieID, NewUserID, NewDate, OldMovieID, OldUserID, OldDate);
        }
        public MovieUserBLL FindMovieUserByID(int MovieUserID)
        {
            MovieUserBLL rv = null;
            MovieUserDAL dal = ctx.FindMovieUserByID(MovieUserID);
            if ( dal != null)
            {
                rv = new MovieUserBLL(dal);
            }
            return rv;
        }
        public List<MovieUserBLL> GetMovieUsers(int skip, int take)
        {
            List<MovieUserBLL> rv = new List<MovieUserBLL>();
            List<MovieUserDAL> dalitems = ctx.GetMovieUsers(skip, take);
            foreach (MovieUserDAL dal in dalitems)
            {
                rv.Add(new MovieUserBLL(dal));
            }
            return rv;
        }
        #endregion

    }
}

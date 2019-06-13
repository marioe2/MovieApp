using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    class Mapper
    {
        public void assert(bool test, string message)
        {
            if (!test)
            {
                throw new Exception(message);
            }
        }
        public string GetStringOrNull(System.Data.SqlClient.SqlDataReader r, int i)
        {
            string rv = null;
            if (!r.IsDBNull(i))
            {
                rv = r.GetString(i);
            }
            return rv;
        }
        public int GetInt32OrZero(System.Data.SqlClient.SqlDataReader r, int i)
        {
            int rv = 0;
            if (!r.IsDBNull(i))
            {
                rv = r.GetInt32(i);
            }
            return rv;
        }
        public DateTime GetDateTimeOrMinValue(System.Data.SqlClient.SqlDataReader r, int i)
        {
            DateTime rv = DateTime.MinValue;
            if (!r.IsDBNull(i))
            {
                rv = r.GetDateTime(i);
            }
            return rv;
        }
    }

    class CategoryMapper : Mapper
    {
        int CategoryIDOrdinal;
        int CategoryOrdinal;
        public CategoryMapper(SqlDataReader r)
        {
            CategoryIDOrdinal = r.GetOrdinal("CategoryID");
            assert(0 == CategoryIDOrdinal, "CategoryID is not column 0 as expected");
            CategoryOrdinal = r.GetOrdinal("Category");
            assert(1 == CategoryOrdinal, "Category is not column 1 as expected");
        }
        public CategoryDAL ToCategory(SqlDataReader r)
        {
            CategoryDAL rv = new CategoryDAL();
            rv.CategoryID = GetInt32OrZero(r, CategoryIDOrdinal);
            rv.Category = GetStringOrNull(r, CategoryOrdinal);

            return rv;
        }
    }
    class RoleMapper : Mapper
    {
        int RoleIDOrdinal;
        int RoleOrdinal;
        public RoleMapper(SqlDataReader r)
        {
            RoleIDOrdinal = r.GetOrdinal("RoleID");
            assert(0 == RoleIDOrdinal, "RoleID is not column 0 as expected");
            RoleOrdinal = r.GetOrdinal("Role");
            assert(1 == RoleOrdinal, "Role is not column 1 as expected");
        }
        public RoleDAL ToRole(SqlDataReader r)
        {
            RoleDAL rv = new RoleDAL();
            rv.RoleID = GetInt32OrZero(r, RoleIDOrdinal);
            rv.Role = GetStringOrNull(r, RoleOrdinal);

            return rv;
        }
    }
    class UserMapper : Mapper
    {
        int UserIDOrdinal;
        int UserNameOrdinal;
        int EmailOrdinal;
        int PasswordOrdinal;
        int RoleIDOrdinal;

        int RoleOrdinal;
        public UserMapper(SqlDataReader r)
        {
            UserIDOrdinal = r.GetOrdinal("UserID");
            assert(0 == UserIDOrdinal, "UserID is not column 0 as expected");
            UserNameOrdinal = r.GetOrdinal("UserName");
            assert(1 == UserNameOrdinal, "UserName is not column 1 as expected");
            EmailOrdinal = r.GetOrdinal("Email");
            assert(2 == EmailOrdinal, "Email is not column 2 as expected");
            PasswordOrdinal = r.GetOrdinal("Password");
            assert(3 == PasswordOrdinal, "Password is not column 3 as expected");
            RoleIDOrdinal = r.GetOrdinal("RoleID");
            assert(4 == RoleIDOrdinal, "RoleID is not column 4 as expected");
            RoleOrdinal = r.GetOrdinal("Role");
            assert(5 == RoleOrdinal, "Role is not column 5 as expected");
            ;
        }
        public UserDAL ToUser(SqlDataReader r)
        {
            UserDAL rv = new UserDAL();
            rv.UserID = GetInt32OrZero(r, UserIDOrdinal);
            rv.UserName = GetStringOrNull(r, UserNameOrdinal);
            rv.Email = GetStringOrNull(r, EmailOrdinal);
            rv.Password = GetStringOrNull(r, PasswordOrdinal);
            rv.RoleID = GetInt32OrZero(r, RoleIDOrdinal);
            rv.Role = GetStringOrNull(r, RoleOrdinal);
            return rv;
        }
    }
    class MovieMapper : Mapper
    {
        int MovieIDOrdinal;
        int TitleOrdinal;
        int LengthOrdinal;
        int RatingOrdinal;
        int DescriptionOrdinal;
        int TrailerOrdinal;
        int CategoryIDOrdinal;

        int CategoryOrdinal;

        public MovieMapper(SqlDataReader r)
        {
            MovieIDOrdinal = r.GetOrdinal("MovieID");
            assert(0 == MovieIDOrdinal, "MovieID is not column 0 as expected");
            TitleOrdinal = r.GetOrdinal("Title");
            assert(1 == TitleOrdinal, "Title is not column 1 as expected");
            LengthOrdinal = r.GetOrdinal("Length");
            assert(2 == LengthOrdinal, "Length is not column 2 as expected");
            RatingOrdinal = r.GetOrdinal("Rating");
            assert(3 == RatingOrdinal, "Rating is not column 3 as expected");
            DescriptionOrdinal = r.GetOrdinal("Description");
            assert(4 == DescriptionOrdinal, "Description is not column 4 as expected");
            TrailerOrdinal = r.GetOrdinal("Trailer");
            assert(5 == TrailerOrdinal, "Trailer is not column 5 as expected");
            CategoryIDOrdinal = r.GetOrdinal("CategoryID");
            assert(6 == CategoryIDOrdinal, "CategoryID is not column 6 as expected");
            CategoryOrdinal = r.GetOrdinal("Category");
            assert(7 == CategoryOrdinal, "Category is not column 7 as expected");
        }

        public MovieDAL ToMovie(SqlDataReader r)
        {
            MovieDAL rv = new MovieDAL();
            rv.MovieID = GetInt32OrZero(r, MovieIDOrdinal);
            rv.Title = GetStringOrNull(r, TitleOrdinal);
            rv.Length = GetInt32OrZero(r, LengthOrdinal);
            rv.Rating = GetStringOrNull(r, RatingOrdinal);
            rv.Description = GetStringOrNull(r, DescriptionOrdinal);
            rv.Trailer = GetStringOrNull(r, TrailerOrdinal);
            rv.CategoryID = GetInt32OrZero(r, CategoryIDOrdinal);
            rv.Category = GetStringOrNull(r, CategoryOrdinal);

            return rv;
        }
    }
    class MovieUserMapper : Mapper
    {
        int MovieUserIDOrdinal;
        int MovieIDOrdinal;
        int UserIDOrdinal;
        int DateOrdinal;

        int UserNameOrdinal;
        int TitleOrdinal;
        int LengthOrdinal;

        public MovieUserMapper(SqlDataReader r)
        {
            MovieUserIDOrdinal = r.GetOrdinal("MovieUserID");
            assert(0 == MovieUserIDOrdinal, "MovieUserID is not column 0 as expected");
            MovieIDOrdinal = r.GetOrdinal("MovieID");
            assert(1 == MovieIDOrdinal, "MovieID is not column 1 as expected");
            UserIDOrdinal = r.GetOrdinal("UserID");
            assert(2 == UserIDOrdinal, "UserID is not column 2 as expected");
            DateOrdinal = r.GetOrdinal("Date");
            assert(3 == DateOrdinal, "Date is not column 3 as expected");
            UserNameOrdinal = r.GetOrdinal("UserName");
            assert(4 == UserNameOrdinal, "UserName is not column 4 as expected");
            TitleOrdinal = r.GetOrdinal("Title");
            assert(5 == TitleOrdinal, "Title is not column 5 as expected");
            LengthOrdinal = r.GetOrdinal("Length");
            assert(6 == LengthOrdinal, "Length is not column 6 as expected");
        }
        public MovieUserDAL ToMovieUser(SqlDataReader r)
        {
            MovieUserDAL rv = new MovieUserDAL();
            rv.MovieUserID = GetInt32OrZero(r, MovieUserIDOrdinal);
            rv.MovieID = GetInt32OrZero(r, MovieIDOrdinal);
            rv.UserID = GetInt32OrZero(r, UserIDOrdinal);
            rv.Date = GetDateTimeOrMinValue(r, DateOrdinal);
            rv.UserName = GetStringOrNull(r, UserNameOrdinal);
            rv.Title = GetStringOrNull(r, TitleOrdinal);
            rv.Length = GetInt32OrZero(r, LengthOrdinal);
            return rv;
        }
    }




    public class ContextDAL : IDisposable
    {
        public void Dispose()
        {
            Con.Dispose();
        }

        private System.Data.SqlClient.SqlConnection Con;

        private void Log(Exception ex)
        {

        }

        public ContextDAL()
        {
            Con = new System.Data.SqlClient.SqlConnection();
        }
        public string ConnectionString
        {
            get
            {
                return Con.ConnectionString;
            }
            set
            {
                Con.ConnectionString = value;
            }
        }

        private void EnsureConnected()
        {
            if (Con.State != System.Data.ConnectionState.Open)
            {
                if (Con.State == System.Data.ConnectionState.Broken)
                {
                    Con.Close();
                    Con.Open();
                }
                else if (Con.State == System.Data.ConnectionState.Closed)
                {
                    Con.Open();
                }
            }
        }
        public SqlDataReader ExecuteCommand(SqlCommand cmd)
        {
            if (Con != cmd.Connection)
            {
                cmd.Connection = Con;
            }
            EnsureConnected();
            return cmd.ExecuteReader();
        }
        #region Categories

        public int CreateCategory(string Category)
        {
            int rv = 0;
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateCategory", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", 0);
                    command.Parameters["@CategoryID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@Category", Category);

                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@CategoryID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void DeleteCategory(int CategoryID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteCategory", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public CategoryDAL FindCategoryByID(int CategoryID)
        {
            CategoryDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindCategoryByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        CategoryMapper mapper = new CategoryMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToCategory(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public List<CategoryDAL> GetCategories(int skip, int take)
        {
            List<CategoryDAL> rv = new List<CategoryDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetCategories", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        CategoryMapper mapper = new CategoryMapper(reader);
                        while (reader.Read())
                        {
                            CategoryDAL c = mapper.ToCategory(reader);
                            rv.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void JustUpdateCategory(int CategoryID, string newCategory)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateCategory", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@Category", newCategory);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public int SafeUpdateCategory(int CategoryID, string OldCategory, string newCategory)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateCategory", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@NewCategory", newCategory);
                    command.Parameters.AddWithValue("@OldCategory", OldCategory);

                    rv = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        #endregion categories
        #region Roles
        public int CreateRole(string Role)
        {
            int rv = 0;
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", 0);
                    command.Parameters["@RoleID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@Role", Role);

                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@RoleID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void DeleteRole(int RoleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }

        public RoleDAL FindRoleByID(int RoleID)
        {
            RoleDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindRoleByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper mapper = new RoleMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToRole(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public RoleDAL FindRoleByEmail(string Email)
        {
            RoleDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindRoleByEmail", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", Email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper mapper = new RoleMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToRole(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public RoleDAL FindRoleByUserName(string UserName)
        {
            RoleDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindRoleByUserName", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper mapper = new RoleMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToRole(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public List<RoleDAL> GetRoles(int skip, int take)
        {
            List<RoleDAL> rv = new List<RoleDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetRoles", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        RoleMapper mapper = new RoleMapper(reader);
                        while (reader.Read())
                        {
                            RoleDAL c = mapper.ToRole(reader);
                            rv.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }

        public void JustUpdateRole(int RoleID, string newRole)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@Role", newRole);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public int SafeUpdateRole(int RoleID, string OldRole, string newRole)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateRole", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RoleID", RoleID);
                    command.Parameters.AddWithValue("@NewRole", newRole);
                    command.Parameters.AddWithValue("@OldRole", OldRole);

                    rv = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        #endregion Roles
        #region Movies
        public int CreateMovie(string Title, int Length, string Rating, string Description, string Trailer, int CategoryID)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateMovie", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieID", 0);
                    command.Parameters["@MovieID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@Title", Title);
                    command.Parameters.AddWithValue("@Length", Length);
                    if (null == Rating)
                    {
                        command.Parameters.AddWithValue("@Rating", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Rating", Rating);
                    }
                    command.Parameters.AddWithValue("@Description", Description);
                    if (null == Trailer)
                    {
                        command.Parameters.AddWithValue("@Trailer", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Trailer", Trailer);
                    }
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@MovieID"].Value);

                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public void DeleteMovie(int MovieID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteMovie", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieID", MovieID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public void JustUpdateMovie(int MovieID, string NewTitle, int NewLength, string NewRating, string NewDescription, string NewTrailer, int NewCategoryID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateMovie", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieID", MovieID);

                    command.Parameters.AddWithValue("@Title", NewTitle);
                    command.Parameters.AddWithValue("@Length", NewLength);
                    command.Parameters.AddWithValue("@Rating", NewRating);
                    command.Parameters.AddWithValue("@Description", NewDescription);
                    command.Parameters.AddWithValue("@Trailer", NewTrailer);
                    command.Parameters.AddWithValue("@CategoryID", NewCategoryID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public int SafeUpdateMovie(int MovieID, string NewTitle, int NewLength, string NewRating, string NewDescription, string NewTrailer, int NewCategoryID,
                                                string OldTitle, int OldLength, string OldRating, string OldDescription, string OldTrailer, int OldCategoryID)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateMovie", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieID", MovieID);

                    command.Parameters.AddWithValue("@NewTitle", NewTitle);
                    command.Parameters.AddWithValue("@NewLength", NewLength);
                    command.Parameters.AddWithValue("@NewRating", NewRating);
                    command.Parameters.AddWithValue("@NewDescription", NewDescription);
                    command.Parameters.AddWithValue("@NewTrailer", NewTrailer);
                    command.Parameters.AddWithValue("@NewCategoryID", NewCategoryID);

                    command.Parameters.AddWithValue("@OldTitle", OldTitle);
                    command.Parameters.AddWithValue("@OldLength", OldLength);
                    command.Parameters.AddWithValue("@OldRating", OldRating);
                    command.Parameters.AddWithValue("@OldDescription", OldDescription);
                    command.Parameters.AddWithValue("@OldTrailer", OldTrailer);
                    command.Parameters.AddWithValue("@OldCategoryID", OldCategoryID);

                    rv = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public MovieDAL FindMovieByID(int MovieID)
        {
            MovieDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindMovieByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieID", MovieID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        MovieMapper mapper = new MovieMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToMovie(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public List<MovieDAL> GetMovies(int skip, int take)
        {
            List<MovieDAL> rv = new List<MovieDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetMovies", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        MovieMapper mapper = new MovieMapper(reader);
                        while (reader.Read())
                        {
                            MovieDAL c = mapper.ToMovie(reader);
                            rv.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        #endregion Movies
        #region Users
        public int CreateUser(string UserName, string Email, string Password, int RoleID)
        {
            int rv = 0;
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", 0);
                    command.Parameters["@UserID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@RoleID", RoleID);

                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@UserID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public void DeleteUser(int UserID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public void JustUpdateUser(int UserID, string NewUserName, string NewEmail, string NewPassword, int NewRoleID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@UserName", NewUserName);
                    command.Parameters.AddWithValue("@Email", NewEmail);
                    command.Parameters.AddWithValue("@Password", NewPassword);
                    command.Parameters.AddWithValue("@RoleID", NewRoleID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public int SafeUpdateUser(int UserID, string NewUserName, string NewEmail, string NewPassword, int NewRoleID,
                                              string OldUserName, string OldEmail, string OldPassword, int OldRoleID)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@NewUserName", NewUserName);
                    command.Parameters.AddWithValue("@NewEmail", NewEmail);
                    command.Parameters.AddWithValue("@NewPassword", NewPassword);
                    command.Parameters.AddWithValue("@NewRoleID", NewRoleID);

                    command.Parameters.AddWithValue("@OldUserName", OldUserName);
                    command.Parameters.AddWithValue("@OldEmail", OldEmail);
                    command.Parameters.AddWithValue("@OldPassword", OldPassword);
                    command.Parameters.AddWithValue("@OldRoleID", OldRoleID);

                    rv =command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public UserDAL FindUserByID(int UserID)
        {
            UserDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindUserByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToUser(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public UserDAL FindUserByEmail(string Email)
        {
            UserDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindUserByEmail", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", Email);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToUser(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public UserDAL FindUserByUserName(string UserName)
        {
            UserDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindUserByUserName", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToUser(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public List<UserDAL> GetUsers(int skip, int take)
        {
            List<UserDAL> rv = new List<UserDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetUsers", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        UserMapper mapper = new UserMapper(reader);
                        while (reader.Read())
                        {
                            UserDAL c = mapper.ToUser(reader);
                            rv.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        #endregion Users
        #region MovieUsers
        public int CreateMovieUser(int MovieID, int UserID, DateTime Date)
        {
            int rv = 0;
            try
            {

                EnsureConnected();
                using (SqlCommand command = new SqlCommand("CreateMovieUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieUserID", 0);
                    command.Parameters["@MovieUserID"].Direction = System.Data.ParameterDirection.InputOutput;
                    command.Parameters.AddWithValue("@MovieID", MovieID);
                    command.Parameters.AddWithValue("@UserID", UserID);
                    command.Parameters.AddWithValue("@Date", Date);

                    command.ExecuteNonQuery();

                    rv = Convert.ToInt32(command.Parameters["@MovieUserID"].Value);
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public void DeleteMovieUser(int MovieUserID)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("DeleteMovieUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieUserID", MovieUserID);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public void JustUpdateMovieUser(int MovieUserID, int NewMovieID, int NewUserID, DateTime NewDate)
        {
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("JustUpdateMovieUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieUserID", MovieUserID);

                    command.Parameters.AddWithValue("@MovieID", NewMovieID);
                    command.Parameters.AddWithValue("@UserID", NewUserID);
                    command.Parameters.AddWithValue("@Date", NewDate);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        public int SafeUpdateMovieUser(int MovieUserID, int NewMovieID, int NewUserID, DateTime NewDate,
                                                        int OldMovieID, int OldUserID, DateTime OldDate)
        {
            int rv = 0;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("SafeUpdateMovieUser", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieUserID", MovieUserID);

                    command.Parameters.AddWithValue("@NewMovieID", NewMovieID);
                    command.Parameters.AddWithValue("@NewUserID", NewUserID);
                    command.Parameters.AddWithValue("@NewDate", NewDate);

                    command.Parameters.AddWithValue("@OldMovieID", OldMovieID);
                    command.Parameters.AddWithValue("@OldUserID", OldUserID);
                    command.Parameters.AddWithValue("@OldDate", OldDate);

                    rv =command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public MovieUserDAL FindMovieUserByID(int MovieUserID)
        {
            MovieUserDAL rv = null;
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("FindMovieUserByID", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MovieUserID", MovieUserID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        MovieUserMapper mapper = new MovieUserMapper(reader);
                        if (reader.Read())
                        {
                            rv = mapper.ToMovieUser(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        public List<MovieUserDAL> GetMovieUsers(int skip, int take)
        {
            List<MovieUserDAL> rv = new List<MovieUserDAL>();
            try
            {
                EnsureConnected();
                using (SqlCommand command = new SqlCommand("GetMovieUsers", Con))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@skip", skip);
                    command.Parameters.AddWithValue("@take", take);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        MovieUserMapper mapper = new MovieUserMapper(reader);
                        while (reader.Read())
                        {
                            MovieUserDAL c = mapper.ToMovieUser(reader);
                            rv.Add(c);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
            return rv;
        }
        #endregion MovieUsers

    }
    

}

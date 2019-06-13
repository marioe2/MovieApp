using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MovieUserBLL
    {
        public MovieUserBLL()
        {

        }
        public MovieUserBLL(MovieUserDAL dal)
        {
            this.MovieUserID = dal.MovieUserID;
            this.MovieID = dal.MovieID;
            this.UserID = dal.UserID;
            this.Date = dal.Date;
            this.UserName = dal.UserName;
            this.Title = dal.Title;
            this.Length = dal.Length;
        }
        #region Direct Mappings
        public int MovieUserID { get; set; }
        public int MovieID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        #endregion Direct Mappings

        #region Indirect Mappings
        public string UserName { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        #endregion Indirect Mappings

        public override string ToString()
        {
            return $"MovieUserID:{MovieUserID} MovieID:{MovieID} UserID:{UserID} Date:{Date} UserName:{UserName} Title:{Title} Length:{Length}min";
        }
    }
}

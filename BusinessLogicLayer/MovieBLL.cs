using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MovieBLL
    {
        public MovieBLL()
        {

        }
        public MovieBLL(MovieDAL dal)
        {
            this.MovieID = dal.MovieID;
            this.Title = dal.Title;
            this.Length = dal.Length;
            this.Rating = dal.Rating;
            this.Description = dal.Description;
            this.Trailer = dal.Trailer;
            this.CategoryID = dal.CategoryID;
            this.Category = dal.Category;
        }
             #region direct mappings
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public int CategoryID { get; set; }
        #endregion direct mappings


        #region Indirect Mappings
        public string Category { get; set; }
        #endregion Indirect Mappings

        public override string ToString()
        {
            return $"MovieID:{MovieID} Title:{Title} Length:{Length}min Rating:{Rating} Description:{Description} Trailer:{Trailer} CategoryID:{CategoryID} Category:{Category}";
        }
    }


    
}

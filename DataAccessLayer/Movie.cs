using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MovieDAL
    {
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

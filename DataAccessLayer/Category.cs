using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAL
    {
        #region Direct Mapping
        public int CategoryID { get; set; }
        public string Category { get; set; }
        #endregion Direct Mapping

        public override string ToString()
        {
            return $"CategoryID: {CategoryID} Category: {Category}";
        }
    }
}

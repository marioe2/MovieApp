using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CategoryBLL
    {
        public CategoryBLL()
        {

        }

        public CategoryBLL(CategoryDAL dal)
        {
            this.CategoryID = dal.CategoryID;
            this.Category = dal.Category;
        }
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

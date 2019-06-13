using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoleDAL
    {
        #region Direct Mapping
        public int RoleID { get; set; }

        public string Role { get; set; }
        #endregion
        public override string ToString()
        {
            return $"RoleID:{RoleID} Role:{Role}";
        }
    }
}

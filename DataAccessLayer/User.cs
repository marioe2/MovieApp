using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAL
    {
        #region Direct Mappings
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        #endregion Direct Mappings
        #region Indirect Mappings
        public string Role { get; set; }
        #endregion Indirect Mappings
        public override string ToString()
        {
            return $"UserID:{UserID} UserName:{UserName} Email:{Email} Password:{Password} RoleID:{RoleID} Role:{Role}";
        }
    }
}

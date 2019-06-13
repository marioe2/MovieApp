using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        public UserBLL()
        {

        }

        public UserBLL(UserDAL dal)
        {
            this.UserID = dal.UserID;
            this.UserName = dal.UserName;
            this.Email = dal.Email;
            this.Password = dal.Password;
            this.RoleID = dal.RoleID;
            this.Role = dal.Role;
        }
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

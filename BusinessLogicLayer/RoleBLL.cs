﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
   
    
        public class RoleBLL
        {
            // this ctor is used by MVC and is required to exist
            public RoleBLL()
            {

            }

            // this ctor is an example of one way to convert from the Data Access Layer
            public RoleBLL(RoleDAL dal)
            {
                this.RoleID = dal.RoleID;
                this.Role = dal.Role;
            }
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

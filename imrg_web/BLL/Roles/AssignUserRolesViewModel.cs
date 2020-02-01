using imrg_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace imrg_web.BLL.Roles
{
    public class AssignUserRolesViewModel
    {
        public AspNetUser User { get; set; }
        public string UserId { get; set; }
        public List<AspNetRole> AvailableRoles { get; set; }
        public string RoleId { get; set; }

        public static AssignUserRolesViewModel Create(AspNetUser user, List<AspNetRole> roles)
        {
            var model = new AssignUserRolesViewModel();

            model.User = user;
            model.UserId = user.Id;
            model.AvailableRoles = roles;

            return model;
        }
    }
}
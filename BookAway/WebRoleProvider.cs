using BookAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;

namespace BookAway
{
    public class WebRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {

            BookAwayEntities entities;
            //using (entities = new BookAwayEntities())
            //{
            //    var userRoles = (from c in entities.userRoles where c.username==username
            //                     select c.userRole1).ToArray();
            //    return userRoles;
            //}
            List<string> result = new List<string>();
            using(entities=new BookAwayEntities())
            {
                if (entities.Customers.Any(x => x.CustUsername == username))
                    result.Add("Customer");
                if (entities.AdminLogins.Any(x => x.AdminUsername == username))
                    result.Add("Admin");
                if (entities.HotelOwners.Any(x => x.HOwnerUsername == username))
                    result.Add("Hotel");
            }
            return result.ToArray();

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
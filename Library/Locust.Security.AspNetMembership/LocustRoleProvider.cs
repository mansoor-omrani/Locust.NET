using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Locust.Conversion;
using Locust.Data;
using Locust.Db;

namespace Locust.Security.AspNetMembership
{
    class LocustRoleProvider : RoleProvider
    {
        private IDbHelper db;

        public LocustRoleProvider(IDbHelper db)
        {
            this.db = db;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var users = String.Join(",", usernames);
            var roles = String.Join(",", roleNames);
            var cmd = db.GetCommand("usp1_Users_add_to_roles");
            
            db.ExecuteNonQuery(cmd, new { UserNames = users, RoleNames = roles });
        }
        public override string ApplicationName { get; set; }
        public override void CreateRole(string roleName)
        {
            var cmd = db.GetCommand("usp1_Role_create");
            
            db.ExecuteNonQuery(cmd, new { roleName});
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            var cmd = db.GetCommand("usp1_Role_create");
            var dbr = db.ExecuteNonQuery(cmd, new { roleName, throwOnPopulatedRole });
            
            return dbr.Success;
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            var result = _GetAllRoles();

            return result.Data;
        }
        public DbResult<string[]> _GetAllRoles()
        {
            var cmd = db.GetCommand("usp1_Role_get_all");
            var args = new
            {
                roles = CommandParameter.Output(SqlDbType.VarChar, 4000)
            };
            var dbr = db.ExecuteNonQuery(cmd, args);
            var result = dbr.Copy<string[]>();

            if (dbr.Success)
            {
                var roles = SafeClrConvert.ToString(args.roles.Value);

                result.Data = roles.Split(new char[] { ',' });
            }

            return result;
        }
        public override string[] GetRolesForUser(string username)
        {
            var result = _GetRolesForUser(username);

            return result.Data;
        }
        public DbResult<string[]> _GetRolesForUser(string username)
        {
            var cmd = db.GetCommand("usp1_User_get_roles");
            var args = new
            {
                UserName = username,
                roles = CommandParameter.Output(SqlDbType.VarChar, 4000)
            };
            var dbr = db.ExecuteNonQuery(cmd, args);
            var result = dbr.Copy<string[]>();

            if (dbr.Success)
            {
                var roles = SafeClrConvert.ToString(args.roles.Value);

                result.Data = roles.Split(new char[] { ',' });
            }

            return result;
        }
        public override string[] GetUsersInRole(string roleName)
        {
            var result = _GetUsersInRole(roleName);

            return result.Data;
        }
        public DbResult<string[]> _GetUsersInRole(string roleName)
        {
            var cmd = db.GetCommand("usp1_Role_get_users");
            var args = new
            {
                roleName,
                users = CommandParameter.Output(SqlDbType.VarChar, 4000)
            };
            var dbr = db.ExecuteNonQuery(cmd, args);
            var result = dbr.Copy<string[]>();

            if (dbr.Success)
            {
                var users = SafeClrConvert.ToString(args.users.Value);

                result.Data = users.Split(new char[] { ',' });
            }

            return result;
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            var result = _IsUserInRole(username, roleName);

            return result.Data;
        }
        public DbResult<bool> _IsUserInRole(string username, string roleName)
        {
            var cmd = db.GetCommand("usp1_User_is_in_role");
            var args = new
            {
                username,
                roleName,
                Result = CommandParameter.Output(SqlDbType.Bit)
            };
            var dbr = db.ExecuteNonQuery(cmd, args);
            var result = dbr.Copy<bool>();

            if (dbr.Success)
            {
                result.Data = SafeClrConvert.ToBoolean(args.Result.Value);
            }

            return result;
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            _RemoveUsersFromRoles(usernames, roleNames);
        }
        public DbResult _RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            var users = String.Join(",", usernames);
            var roles = String.Join(",", roleNames);
            var cmd = db.GetCommand("usp1_Users_remove_from_roles");
            var dbr = db.ExecuteNonQuery(cmd, new { UserNames = users, RoleNames = roles });

            return dbr.Copy();
        }
        public override bool RoleExists(string roleName)
        {
            var result = _RoleExists(roleName);

            return result.Data;
        }

        public DbResult<bool> _RoleExists(string roleName)
        {
            var cmd = db.GetCommand("usp1_Role_exists");
            var args = new
            {
                roleName,
                Result = CommandParameter.Output(SqlDbType.Bit)
            };
            var dbr = db.ExecuteNonQuery(cmd, args);
            var result = dbr.Copy<bool>();
            
            if (dbr.Success)
            {
                result.Data = SafeClrConvert.ToBoolean(args.Result.Value);
            }

            return result;
        }
    }
}

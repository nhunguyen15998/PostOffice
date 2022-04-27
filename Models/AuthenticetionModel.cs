using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace post_office.Models
{
    public class AuthenticetionModel
    {
        public static int id;
        public static int roleId;
        public static string name;
        public static string roleName;
        public static int branchId;
        public static string branchName;
        public static string avt;


        public static List<PermissionModel> permissions = new List<PermissionModel>();

        public static bool hasPermission(string permissionCode)
        {
            foreach (var item in permissions)
            {
                if (item.code == permissionCode)
                {
                    return true;
                }

            }
            if (permissions.Count == 0) return false;
            return false;
        }
        public static void ClearSession()
        {
            permissions.Clear();
            id = 0;
            roleId = 0;
            name = null;
            roleName = null;
            branchId = 0;
            branchName = null;
            avt = "";


        }
        public static void SetCurrent(int Id, int roleID, string _name, string _roleName,  int brnId, string brnName,string _avt,List<PermissionModel> lsPermission)
        {
            id = Id;
            roleId = roleID;
            name = _name;
            roleName = _roleName;
            permissions = lsPermission;
            branchId = brnId;
            branchName = brnName;
            avt = _avt;
        }
    }
}

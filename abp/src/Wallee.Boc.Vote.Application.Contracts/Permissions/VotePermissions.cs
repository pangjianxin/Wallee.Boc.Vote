﻿namespace Wallee.Boc.Vote.Permissions;

public static class VotePermissions
{
    public const string GroupName = "Vote";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";
    public class OrganizationUnits
    {
        public const string Default = GroupName + ".OrganizationUnit";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
        public const string ManageRoles = Default + ".ManageRoles";
        public const string ManageUsers = Default + ".ManageUsers";
    }

    public class Appraisements
    {
        public const string Default = GroupName + ".Appraisements";
        public const string Update = Default + ".Update";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}

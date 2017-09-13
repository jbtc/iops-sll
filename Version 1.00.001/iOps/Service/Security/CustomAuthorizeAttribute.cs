using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace iOps.Service.Security
{
    /// <summary>
    /// <para>[CustomAuthorize([RequireAll],[Users],[Roles],[Groups],[Tasks])]</para>
    /// <para>Used to apply authentication to a action method.</para>
    /// <para>&#160;</para>
    /// <para><param name="RequireAll">RequireAll: TRUE - All parameters passed must pass the authenication process to be authorized (Default Value)]</param></para>
    /// <para>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;
    ///         FALSE - Any single parameter must pass authentication to be authorized </para>
    /// <para><param name="Users">Users: List of UserNames who have access [optional]</param></para>
    /// <para><param name="Roles">Roles: List of Roles who have access [optional]</param></para>
    /// <para><param name="Groups">Groups: List of Groups who have access [optional]</param></para>
    /// <para><param name="Tasks">Tasks: List of Tasks who have access [optional]</param></para>
    /// </summary>
    /// <remarks>
    /// <para>Author: Crane Whitehead</para>
    /// <para>Developed: 10/8/2014</para>
    /// </remarks>
    /// <example>
    ///     [CustomAuthorize(RequireAll = false, Users = "crane", Roles = "Admin", Groups = "Administrators", Tasks = "Add Security1")]
    ///     This will pass if any of the paramters pass authentication
    ///     
    ///     [CustomAuthorize(Users = "crane", Roles = "Admin", Groups = "Administrators", Tasks = "Add Security1")]
    ///     This will only pass if ALL the parameters pass authentication
    ///     
    ///     [CustomAuthorize(Roles = "Admin")]
    ///     [CustomAuthorize(Groups = "Administrators")]
    ///     [CustomAuthorize(Tasks = "Add Security")]
    ///     You may stack attributes for segmentation so each attribute must pass authentication
    ///     
    ///     NOTE: RequireAll will only be applied to the current attribute so the following are Invalid and will not be authorized:
    ///     [CustomAuthorize(RequireAll = True)]
    ///     [CustomAuthorize(RequireAll = false)]
    ///     [CustomAuthorize()]
    /// </example>
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private string UsersConfigKey { get; set; }
        private string RolesConfigKey { get; set; }
        private string GroupsConfigKey { get; set; }
        private string TasksConfigKey { get; set; }
        private string RequireAllConfigKey { get; set; }
        private bool _RequireAll = true;

        public string Groups { get; set; }
        public string Tasks { get; set; }
        public bool RequireAll
        {
            get { return _RequireAll; }
            set { _RequireAll = value; }
        }

        /// <summary>
        /// CurrentUser Property
        /// </summary>
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        /// <summary>
        /// OnAuthorization(AuthorizationContext filterContext)
        /// </summary>
        /// <param name="filterContext">filterContext</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                // Set Parameter Counters
                int validatedParameters = 0;
                int submittedParameters = (new[]{
                                                !String.IsNullOrEmpty(Users), 
                                                !String.IsNullOrEmpty(Roles), 
                                                !String.IsNullOrEmpty(Groups), 
                                                !String.IsNullOrEmpty(Tasks)
                                            }).Count(t => t);

                // Set defaults from web.config
                var authorizedUsers = ConfigurationManager.AppSettings[UsersConfigKey];
                var authorizedRoles = ConfigurationManager.AppSettings[RolesConfigKey];
                var authorizedGroups = ConfigurationManager.AppSettings[GroupsConfigKey];
                var authorizedTasks = ConfigurationManager.AppSettings[TasksConfigKey];
                bool authorizedRequireAll;
                if (!Boolean.TryParse(ConfigurationManager.AppSettings[RequireAllConfigKey], out authorizedRequireAll))
                {
                    authorizedRequireAll = false;
                }

                // Set Authorization Variables
                Users = String.IsNullOrEmpty(Users) ? authorizedUsers : Users;
                Roles = String.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;
                Groups = String.IsNullOrEmpty(Groups) ? authorizedGroups : Groups;
                Tasks = String.IsNullOrEmpty(Tasks) ? authorizedTasks : Tasks;
                RequireAll = (new[] { authorizedRequireAll, RequireAll }).Count(t => t) > 0 ? true : false;

                // Perform Authorization Checks
                if (!String.IsNullOrEmpty(Users))
                {
                    if (Users.Contains(CurrentUser.UserName.ToString()))
                    {
                        validatedParameters++;
                        if (!RequireAll)
                        {
                            return;
                        }
                    }
                }
                if (!String.IsNullOrEmpty(Roles))
                {
                    if (CurrentUser.IsInRole(Roles))
                    {
                        validatedParameters++;
                        if (!RequireAll)
                        {
                            return;
                        }
                    }
                }
                if (!String.IsNullOrEmpty(Groups))
                {
                    if (CurrentUser.IsInGroup(Groups))
                    {
                        validatedParameters++;
                        if (!RequireAll)
                        {
                            return;
                        }
                    }
                }
                if (!String.IsNullOrEmpty(Tasks))
                {
                    if (CurrentUser.IsInTask(Tasks))
                    {
                        validatedParameters++;
                        if (!RequireAll)
                        {
                            return;
                        }
                    }
                }

                // Re-Route if no parameters passed or Authenticaitoin fails
                if (submittedParameters == 0 || validatedParameters != submittedParameters)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
                }

            }

        }
    }
}
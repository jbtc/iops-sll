using System;
using System.Linq;
using System.Security.Principal;

namespace iOps.Service.Security
{
    /// <summary>
    /// CustomPrincipal Classs
    /// </summary>
    public class CustomPrincipal : IPrincipal
    {

        /// <summary>
        /// CustomPrincipal(string Username)
        /// </summary>
        /// <param name="Username">Username</param>
        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        /*************************************************************
         * Property Declarations
         *************************************************************/
        public IIdentity Identity { get; private set; }
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] SecurityRoles { get; set; }
        public string[] SecurityGroups { get; set; }
        public string[] SecurityTasks { get; set; }

        /// <summary>
        /// IsInRole(string role)
        /// </summary>
        /// <param name="role">role</param>
        /// <returns>bool</returns>
        public bool IsInRole(string role)
        {
            if (SecurityRoles != null && SecurityRoles.Length > 0 && SecurityRoles.Any(r => role.Equals(r)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// IsInRole(string role)
        /// </summary>
        /// <param name="Group">Group</param>
        /// <returns>bool</returns>
        public bool IsInGroup(string group)
        {
            if (SecurityGroups != null && SecurityGroups.Length > 0 && SecurityGroups.Any(g => group.Equals(g)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// IsInTask(string Task)
        /// </summary>
        /// <param name="Task">Task</param>
        /// <returns>bool</returns>
        public bool IsInTask(string Task)
        {
            if (SecurityTasks != null && SecurityTasks.Length > 0 && SecurityTasks.Any(t => Task.Equals(t)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

    /// <summary>
    /// CustomPrincipalSerializeModel Class
    /// </summary>
    public class CustomPrincipalSerializeModel
    {
        /*************************************************************
        * Property Declarations
        *************************************************************/
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] SecurityRoles { get; set; }
        public string[] SecurityGroups { get; set; }
        public string[] SecurityTasks { get; set; }
    }
}
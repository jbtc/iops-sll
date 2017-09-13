//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iOps.Core.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SecurityRole
    {
        public SecurityRole()
        {
            this.SecurityGroups = new HashSet<SecurityGroup>();
            this.SecurityTasks = new HashSet<SecurityTask>();
            this.Users = new HashSet<User>();
        }
    
        public System.Guid ID { get; set; }
        public string ControlField { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool ReadyForArchive { get; set; }
    
        public virtual ICollection<SecurityGroup> SecurityGroups { get; set; }
        public virtual ICollection<SecurityTask> SecurityTasks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
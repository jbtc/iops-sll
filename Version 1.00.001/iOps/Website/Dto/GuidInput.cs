using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iOps.Resources;

namespace iOps.Website.Dto
{
    public class GuidInput
    {
        public Guid ID { get; set; }
    }

    public class GuidUserCreateInput : GuidInput
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [StrLen(15)]
        [UsernameUnique]
        public string Username { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [StrLen(20)]
        [UIHint("password")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [UIHint("MultiLookup")]
        public IEnumerable<Guid> SecurityRoles { get; set; }
    }

    public class GuidUserEditInput : GuidInput
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [UIHint("MultiLookup")]
        public IEnumerable<Guid> SecurityRoles { get; set; }
    }

    public class GuidChangePasswordInput : GuidInput
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [StrLen(20)]
        [UIHint("password")]
        public string Password { get; set; }
    }

    public class GuidSignInInput
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        // [Display(ResourceType = typeof(Mui), Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [UIHint("Password")]
        //   [Display(ResourceType = typeof(Mui), Name = "Password")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }

    public class GuidDelBtn
    {
        public Guid ID { get; set; }
        public string Controller { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class GuidCountryInput : GuidInput
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [StrLen(20)]
        [Display(ResourceType = typeof(Mui), Name = "Name")]
        public string Name { get; set; }
    }

}
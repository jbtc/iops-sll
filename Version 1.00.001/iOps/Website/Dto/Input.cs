using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using iOps.Resources;

namespace iOps.Website.Dto
{
    public class Input
    {
        public Guid ID { get; set; }
    }

    public class FeedbackInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [StrLen(500)]
        [AdditionalMetadata("DontSurround", true)]
        [UIHint("TinyMCE")]
        public string Comments { get; set; }
    }

    public class UserCreateInput : Input
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
        public IEnumerable<int> SecurityRoles { get; set; }
    }

    public class UserEditInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [UIHint("MultiLookup")]
        public IEnumerable<int> SecurityRoles { get; set; }
    }

    public class UserCreateInputGuid : Input
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
        public IEnumerable<int> SecurityRoles { get; set; }
    }

    public class UserEditInputGuid : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [UIHint("MultiLookup")]
        public IEnumerable<int> SecurityRoles { get; set; }
    }

    public class ChangePasswordInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [StrLen(20)]
        [UIHint("password")]
        public string Password { get; set; }
    }

    public class CountryInput : Input
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [StrLen(20)]
        [Display(ResourceType = typeof(Mui), Name = "Name")]
        public string Name { get; set; }
    }

    public class SignInInput
    {
        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [Display(ResourceType = typeof(Mui), Name = "UserName")]
        public string Username { get; set; }

        [Required(ErrorMessageResourceName = "required", ErrorMessageResourceType = typeof(Mui))]
        [UIHint("Password")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Mui), Name = "Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Mui), Name = "RememberMe")]
        public bool Remember { get; set; }
    }

    public class DelBtn
    {
        public int ID { get; set; }
        public string Controller { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class CropInput
    {
        public int ImageHeight { get; set; }

        public int ImageWidth { get; set; }
        public int ID { get; set; }
        public string FileName { get; set; }
    }
}
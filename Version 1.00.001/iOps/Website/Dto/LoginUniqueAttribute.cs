using System;
using System.ComponentModel.DataAnnotations;
using iOps.Core.Service;
using iOps.Infra;

namespace iOps.Website.Dto
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class UsernameUniqueAttribute : ValidationAttribute
    {
        private static readonly string defaultErrorMessage = "username unique";//MUI.username_unique;

        public UsernameUniqueAttribute()
            : base(defaultErrorMessage)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return defaultErrorMessage;
        }

        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty((string)value)) return true;
            return IoC.Resolve<IUserService>().IsUnique((string)value);
        }
    }
}
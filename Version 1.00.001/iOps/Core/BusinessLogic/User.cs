using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace iOps.Core.Model
{
    /// <summary>
    /// User Partial Class - Validation object for Business Rules
    /// </summary>
    public partial class User : IValidatableObject
    {
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            if (String.IsNullOrWhiteSpace(Username))
            {
                results.Add(new ValidationResult("Username cannot be null or empty."));
            }

            return results;
        }
    }
}

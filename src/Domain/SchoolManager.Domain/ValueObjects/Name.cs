
using SchoolManager.Core.ValueObjects.Base;
using System.Collections.Generic;

namespace SchoolManager.Domain.ValueObjects
{
    public class Name : BaseValueObject
    {
        #region Properties

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        #endregion

        #region Constructor

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            
            IsValid();
        }

        #endregion

        #region Methods

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(FirstName)) 
            {
                AddError(nameof(FirstName), "FirstName is required.");
            }

            if (string.IsNullOrEmpty(LastName))
            {
                AddError(nameof(LastName), "LastName is required.");
            }

            return ValidationResult.IsValid;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        #endregion
    }
}

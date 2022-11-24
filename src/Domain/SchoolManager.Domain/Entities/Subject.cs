
using SchoolManager.Core.DomainObjects;
using SchoolManager.Domain.Base;
using System;
using System.Collections.Generic;

namespace SchoolManager.Domain.Entities
{
    public class Subject : BaseEntity, IAggregateRoot
    {
        #region Properties
        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Enrolment> Enrolments { get; private set; }

        #endregion

        #region Constructor

        protected Subject() { }
        public Subject(Guid id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description; 
        }

        #endregion

        #region Methods

        public void ChangeName(string name) 
        {
            Name = name;
            IsValid();
        }

        public void ChangeDescription(string description) 
        {
            Description = description;
            IsValid();
        }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Name)) 
            {
                AddError(nameof(Name), "Subject name is required");
            }

            if (string.IsNullOrEmpty(Description))
            {
                AddError(nameof(Description), "Subject description is required");
            }

            return ValidationResult.IsValid;
        } 
        
        #endregion
    }
}

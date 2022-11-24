

using SchoolManager.Core.DomainObjects;
using SchoolManager.Domain.Base;
using SchoolManager.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SchoolManager.Domain.Entities
{
    public class Student : BaseEntity, IAggregateRoot
    {
        #region Properties

        public Name Name { get; private set; }
        public List<Enrolment> Enrolments { get; private set; }

        #endregion

        #region Constructor

        protected Student() { }
        public Student(Guid id, Name name)
            : base(id)
        {
            Name = name;
        }

        #endregion

        #region Methods

        public void ChangeName(Name name) 
        {
            Name = name;
            name.IsValid();
        }

        public override bool IsValid()
        {
            return Name.IsValid();
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        #endregion


    }
}

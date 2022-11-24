
using FluentValidation.Results;
using SchoolManager.Core.Messages;
using System;
using System.Collections.Generic;

namespace SchoolManager.Core.DomainObjects
{
    public abstract class Entity
    {
        #region Fields
        
        private List<Event> notifications;

        #endregion

        #region Properties

        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; private set; }
        public IReadOnlyCollection<Event> Notifications => notifications?.AsReadOnly();

        #endregion

        #region Constructor

        public Entity() :
            this(Guid.NewGuid())
        {
        }

        public Entity(Guid id)
        {
            Id = id;
            ValidationResult = new ValidationResult();
        }

        #endregion

        #region Methods

        public abstract bool IsValid();

        protected void AddError(string errorMessage)
        {
            AddError(string.Empty, errorMessage);
        }

        protected void AddError(string propertyName, string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName, errorMessage));
        }

        protected void AddEvent(Event @event)
        {
            notifications ??= new List<Event>();
            notifications.Add(@event);
        }

        protected void RemoveEvent(Event @event)
        {
            notifications?.Remove(@event);
        }

        public void ClearEvents()
        {
            notifications?.Clear();
        }

        public override bool Equals(object obj)
        {
            var comparteTo = obj as Entity;

            if (ReferenceEquals(this, comparteTo))
            {
                return true;
            }

            if (!ReferenceEquals(null, comparteTo))
            {
                return false;
            }

            return Id.Equals(comparteTo.Id);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 839) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion
    }
}

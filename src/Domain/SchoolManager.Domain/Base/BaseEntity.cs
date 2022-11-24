
using SchoolManager.Core.DomainObjects;
using System;

namespace SchoolManager.Domain.Base
{
    public abstract class BaseEntity : Entity
    {
        #region Properties

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        #endregion

        #region Constructor

        protected BaseEntity()
            : base() { }

        protected BaseEntity(Guid id)
            :base(id)
        {
            CreatedAt = DateTime.Now;
            CreatedBy = "Internal Api";
        }

        #endregion
    }
}

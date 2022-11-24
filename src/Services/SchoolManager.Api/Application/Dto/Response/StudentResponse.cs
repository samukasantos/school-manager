using System;

namespace SchoolManager.Api.Application.Dto.Response
{
    public class StudentResponse
    {
        #region Properties
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion
    }
}

using System;

namespace SchoolManager.Api.Application.Dto.Response
{
    public class SubjectResponse
    {

        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion
    }
}

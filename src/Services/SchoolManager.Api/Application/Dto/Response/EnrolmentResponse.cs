using System;

namespace SchoolManager.Api.Application.Dto.Response
{
    public class EnrolmentResponse
    {
        #region Properties

        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public string Name { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Status => EndAt < DateTime.Now ? "Complete" : "Incomplete";

        #endregion
    }
}

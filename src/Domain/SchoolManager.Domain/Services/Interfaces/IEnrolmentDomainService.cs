
using SchoolManager.Domain.Entities;
using System.Collections.Generic;

namespace SchoolManager.Domain.Services.Interfaces
{
    public interface IEnrolmentDomainService
    {
        bool IsElegibleToEnrol(List<Enrolment> enrolments);
    }
}


using SchoolManager.Domain.Entities;
using SchoolManager.Domain.Services.Base;
using SchoolManager.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SchoolManager.Domain.Services
{
    public class EnrolmentDomainService : BaseDomainService, IEnrolmentDomainService
    {
        #region Methods
        
        public bool IsElegibleToEnrol(List<Enrolment> enrolments)
        {
            if(enrolments == null || enrolments.Count == 0) 
            {
                return true;
            }

            var numberOfIncompleteSubjects = 0;

            foreach (var enrolment in enrolments)
            {
                if(enrolment.EndAt > DateTime.Now) 
                {
                    numberOfIncompleteSubjects++;
                }
            }

            return numberOfIncompleteSubjects < 5;
        } 
        
        #endregion
    }
}

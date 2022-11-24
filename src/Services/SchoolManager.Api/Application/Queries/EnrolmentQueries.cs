using SchoolManager.Api.Adapters;
using SchoolManager.Api.Application.Queries.Base;
using SchoolManager.Api.Application.Queries.Interfaces;
using SchoolManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Queries
{
    public class EnrolmentQueries : BaseQuery, IEnrolmentQueries
    {
        #region Fields

        private readonly IEnrolmentRepository enrolmentRepository;

        #endregion

        #region Constructor

        public EnrolmentQueries(IEnrolmentRepository enrolmentRepository)
        {
            this.enrolmentRepository = enrolmentRepository;
        }

        #endregion

        #region Methods

        public async Task<QueryValidationResult> GetAllAsync()
        {
            try
            {
                var result = await enrolmentRepository.GetAllAsync();

                ValidationResult.DataResult = result.ToCollectionResponse();

            }
            catch (Exception e)
            {
                AddError(e.Message);
            }

            return ValidationResult;
        }

        public async Task<QueryValidationResult> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await enrolmentRepository.GetByIdAsync(id);

                ValidationResult.DataResult = result.ToResponse();
            }
            catch (Exception e)
            {
                AddError(e.Message);
            }

            return ValidationResult;
        }

        #endregion
    }
}

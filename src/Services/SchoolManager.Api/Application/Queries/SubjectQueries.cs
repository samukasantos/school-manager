using SchoolManager.Api.Adapters;
using SchoolManager.Api.Application.Queries.Base;
using SchoolManager.Api.Application.Queries.Interfaces;
using SchoolManager.Api.Application.Services.Base;
using SchoolManager.Api.Data.Repositories;
using SchoolManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Queries
{
    public class SubjectQueries : BaseQuery, ISubjectQueries
    {
        #region Fields

        private readonly ISubjectRepository subjectRepository;

        #endregion

        #region Constructor

        public SubjectQueries(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        #endregion

        #region Methods

        public async Task<QueryValidationResult> GetAllAsync()
        {
            try
            {
                var result = await subjectRepository.GetAllAsync();

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
                var result = await subjectRepository.GetByIdAsync(id);

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

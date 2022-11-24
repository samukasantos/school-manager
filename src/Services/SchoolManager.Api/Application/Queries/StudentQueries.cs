using SchoolManager.Api.Adapters;
using SchoolManager.Api.Application.Queries.Base;
using SchoolManager.Api.Application.Queries.Interfaces;
using SchoolManager.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace SchoolManager.Api.Application.Queries
{
    public class StudentQueries : BaseQuery, IStudentQueries
    {

        #region Fields

        private readonly IStudentRepository studentRepository;

        #endregion

        #region Constructor

        public StudentQueries(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        #endregion

        #region Methods

        public async Task<QueryValidationResult> GetAllAsync()
        {
            try
            {
                var result = await studentRepository.GetAllAsync();

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
                var result = await studentRepository.GetByIdAsync(id);

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

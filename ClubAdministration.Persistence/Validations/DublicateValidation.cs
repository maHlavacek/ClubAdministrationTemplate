using ClubAdministration.Core.Contracts;
using ClubAdministration.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClubAdministration.Persistence.Validations
{
    public class DublicateValidation : ValidationAttribute
    {
        private readonly IUnitOfWork _unitOfWork;

        public DublicateValidation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!(value is Member member))
            {
                throw new ArgumentException("Value is not a Member",nameof(value));
            }

            if (_unitOfWork.MemberRepository.HasDublicateMember(member.FirstName, member.LastName))
            {
                return new ValidationResult("Es existiert bereits ein Mitglied mit dem Namen");
            }
            return ValidationResult.Success;
        }
    }
}

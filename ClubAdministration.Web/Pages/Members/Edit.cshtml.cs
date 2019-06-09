using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ClubAdministration.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubAdministration.Core.Entities;
using ClubAdministration.Persistence;

namespace ClubAdministration.Web.Pages.Members
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Member Member { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var member = _unitOfWork.MemberRepository.GetMemberById((int)id);

            Member = new Member
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                Id = member.Id,
                MemberSections = member.MemberSections,
                RowVersion = member.RowVersion
            };
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }


            Member dbMember = _unitOfWork.MemberRepository.GetMemberById(Member.Id);
            dbMember.FirstName = Member.FirstName;
            dbMember.LastName = Member.LastName;
            dbMember.RowVersion = Member.RowVersion;

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Message);
            }

            return RedirectToPage("/Index");           
        }

    }
}

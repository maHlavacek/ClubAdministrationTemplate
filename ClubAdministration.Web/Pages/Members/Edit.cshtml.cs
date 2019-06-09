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
            Member = _unitOfWork.MemberRepository.GetMemberById((int)id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Member member = new Member
            {
                FirstName = Member.FirstName,
                LastName = Member.LastName,
                Id = Member.Id,
                MemberSections = Member.MemberSections
            };

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (ValidationException ex)
            {
                throw new ValidationException(ex.Message);
            }

            return RedirectToPage("/Pages/Index");           
        }

    }
}

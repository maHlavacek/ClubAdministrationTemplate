using System;
using ClubAdministration.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ClubAdministration.Core.Entities;
using ClubAdministration.Core.DataTransferObjects;

namespace ClubAdministration.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public int SectionId { get; set; }


        public MemberDTO[] Members { get; set; }

        public List<SelectListItem> SectionItems { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            LoadSectionItems();
            return Page();
        }


        public IActionResult OnPost()
        {
            Members = _unitOfWork.MemberSectionRepository.GetMembersBySectionId(SectionId).ToArray();
            LoadSectionItems();
            return Page();
        }

        public void LoadSectionItems()
        {
            SectionItems = _unitOfWork
                .SectionRepository
                .GetAll()
                .Select(item => new SelectListItem(
                                    item.Name,
                                    item.Id.ToString())
                                    ).ToList();
        }

    }
}

using System;
using ClubAdministration.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ClubAdministration.Core.Entities;

namespace ClubAdministration.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// 
        [BindProperty]
        public int SectionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MemberDTOs[] Members { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SelectListItem> SectionItems { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// OnGet
        /// </summary>
        /// <returns></returns>
        public IActionResult OnGet()
        {
            SectionItems = _unitOfWork
                            .SectionRepository
                            .GetAll()
                            .Select(item => new SelectListItem(
                                                item.Name, 
                                                item.Id.ToString())
                                                ).ToList();
           // Members = _unitOfWork.MemberSectionRepository.GetMembersBySectionId(SectionId).ToArray();
            return Page();
        }
        /// <summary>
        /// On Post
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            throw new NotImplementedException();
        }

    }
}

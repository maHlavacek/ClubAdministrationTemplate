using System;
using ClubAdministration.Core.Contracts;
using ClubAdministration.Core.Entities;
using ClubAdministration.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubAdministration.Web.ApiControllers
{
    /// <summary>
    /// API-Controller für die Abfrage von Mitgliedern
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructor mit DI
        /// </summary>
        /// <param name="unitOfWork"></param>
        public MembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Liefert alle Namen der Mitglieder
        /// </summary>
        /// <response code="200">Die Abfrage war erfolgreich.</response>
        // GET: api/Categories
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string[]> GetLockerNumbers()
        {
            return _unitOfWork.MemberRepository.GetAll();
        }


        /// <summary>
        /// Spezialroute zum Abfragen von Sektionen eines Mitglieds
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("{lastName}/{firstName}/sections")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string lastName, string firstName)
        {
            if(lastName.Length < 2)
            {
                return BadRequest($"{nameof(lastName)} is to short");
            }
            if (firstName.Length < 2)
            {
                return BadRequest($"{nameof(firstName)} is to short");
            }
            Member member = _unitOfWork.MemberRepository.GetMemberByName(lastName, firstName);
            if(member == null)
            {
                return NotFound();
            }

            var result = _unitOfWork.MemberSectionRepository.GetSectionsByMember(member);

            return Ok(result);
        }

    }
}
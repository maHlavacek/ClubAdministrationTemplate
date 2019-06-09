using System.Linq;
using ClubAdministration.Core.Contracts;
using ClubAdministration.Core.DataTransferObjects;
using ClubAdministration.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubAdministration.Persistence
{
    public class MemberSectionRepository : IMemberSectionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MemberSectionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRange(MemberSection[] memberSections)
        {
            _dbContext.MemberSections.AddRange(memberSections);
        }

        public MemberDTO[] GetMembersBySectionId(int id)
        {
           return _dbContext.MemberSections.Where(w => w.SectionId==id).Select(s => new MemberDTO
                  {
                      FirstName = s.Member.FirstName,
                      LastName = s.Member.LastName,
                      SectionId = s.SectionId,
                      CountSections = s.Member.MemberSections.Count(),
                      MemberId = s.MemberId
                  })
                  .OrderBy(o => o.LastName)
                  .ToArray();
        }
    }
}
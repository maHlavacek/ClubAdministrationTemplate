using System.Data.Common;
using System.Linq;
using ClubAdministration.Core.Contracts;
using ClubAdministration.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubAdministration.Persistence
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MemberRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool HasDublicateMember(Member member)
        {
            return _dbContext.Members.Any(m => m.FirstName == member.FirstName && m.LastName == member.LastName);
        }

        public Member GetMemberById(int id)
        {
           return _dbContext.Members.Single(m => m.Id == id);
        }
    }

}
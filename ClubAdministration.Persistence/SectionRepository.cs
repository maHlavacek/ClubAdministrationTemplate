using System.Linq;
using ClubAdministration.Core.Contracts;
using ClubAdministration.Core.Entities;

namespace ClubAdministration.Persistence
{
    public class SectionRepository : ISectionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SectionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Section[] GetAll()
        {
            return _dbContext.Sections.ToArray();
        }
    }
}
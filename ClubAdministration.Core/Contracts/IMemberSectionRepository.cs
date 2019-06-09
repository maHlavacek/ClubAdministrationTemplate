using ClubAdministration.Core.Entities;

namespace ClubAdministration.Core.Contracts
{
    public interface IMemberSectionRepository
    {
        void AddRange(MemberSection[] memberSections);
    }
}

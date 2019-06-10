using ClubAdministration.Core.DataTransferObjects;
using ClubAdministration.Core.Entities;

namespace ClubAdministration.Core.Contracts
{
    public interface IMemberSectionRepository
    {
        void AddRange(MemberSection[] memberSections);
        MemberDTO[] GetMembersBySectionId(int id);

        string[] GetSectionsByMember(Member member);
    }
}

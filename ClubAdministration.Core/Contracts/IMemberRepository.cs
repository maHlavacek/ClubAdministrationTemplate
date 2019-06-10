using System;
using ClubAdministration.Core.Entities;

namespace ClubAdministration.Core.Contracts
{
    public interface IMemberRepository
    {
        Member GetMemberById(int id);
        bool HasDublicateMember(Member member);
        string[] GetAll();
        Member GetMemberByName(string lastName, string firstName);
    }
}

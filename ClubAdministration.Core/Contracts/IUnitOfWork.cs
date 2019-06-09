using System;

namespace ClubAdministration.Core.Contracts
{
    public interface IUnitOfWork: IDisposable
    {
 
        IMemberRepository MemberRepository { get; }
        ISectionRepository SectionRepository { get; }
        IMemberSectionRepository MemberSectionRepository { get; }

        int SaveChanges();

        void DeleteDatabase();

        void MigrateDatabase();
    }
}

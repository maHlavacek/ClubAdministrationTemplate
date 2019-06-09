using System;
using System.Collections.Generic;
using System.Text;

namespace ClubAdministration.Core.DataTransferObjects
{
    public class MemberDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SectionId { get; set; }
        public int CountSections { get; set; }

        public int MemberId { get; set; }
    }
}

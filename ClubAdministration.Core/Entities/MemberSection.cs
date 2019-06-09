using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GitStat.Core.Entities;

namespace ClubAdministration.Core.Entities
{
    public class MemberSection : EntityObject
    {
        public int MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }

        public int SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }

    }
}

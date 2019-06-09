using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GitStat.Core.Entities;

namespace ClubAdministration.Core.Entities
{
    public class Section : EntityObject
    {
        public string Name { get; set; }

        public ICollection<MemberSection> MemberSections { get; set; }
    }
}

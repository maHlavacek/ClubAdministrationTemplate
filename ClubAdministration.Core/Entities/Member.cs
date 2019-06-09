using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GitStat.Core.Entities;

namespace ClubAdministration.Core.Entities
{
    public class Member : EntityObject
    {
        [Required]
        [MinLength(2,ErrorMessage = "FirstNames minimum length is 2")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "FirstNames minimum length is 2")]
        public string LastName { get; set; }

        public ICollection<MemberSection> MemberSections { get; set; }



    }
}

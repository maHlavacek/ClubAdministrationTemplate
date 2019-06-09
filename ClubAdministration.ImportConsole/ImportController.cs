using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClubAdministration.Core.Entities;
using Utils;

namespace ClubAdministration.ImportConsole
{
    public class ImportController
    {
        const string Filename = "members.csv";

        public static MemberSection[] ReadFromCsv()
        {
            string[][] matrix = MyFile.ReadStringMatrixFromCsv(Filename, false);

            var members = matrix
                         .GroupBy(line => line[0] + '_' + line[1])
                         .Select(grp => new Member
                         {
                             FirstName = grp.First()[1],
                             LastName = grp.First()[0]
                         })
                         .ToArray();

            var sections = matrix
                          .GroupBy(line => line[2])
                          .Select(grp => new Section
                          {
                              Name = grp.Key
                          })
                          .ToArray();

            var memberSections = matrix
                                .Select(line => new MemberSection
                                {
                                    Member = members.Single(m => m.FirstName == line[1] && m.LastName == line[0]),
                                    Section = sections.Single(s => s.Name == line[2])
                                })
                                .ToArray();

            return memberSections;

        }

    }
}

﻿using System.Linq;
using ClubAdministration.Core.Contracts;
using ClubAdministration.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClubAdministration.Persistence
{
    public class MemberSectionRepository : IMemberSectionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MemberSectionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRange(MemberSection[] memberSections)
        {
            _dbContext.MemberSections.AddRange(memberSections);
        }
    }
}
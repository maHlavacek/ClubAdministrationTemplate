﻿using System;
using ClubAdministration.Core.Entities;

namespace ClubAdministration.Core.Contracts
{
    public interface IMemberRepository
    {
        Member GetMemberById(int id);
    }
}

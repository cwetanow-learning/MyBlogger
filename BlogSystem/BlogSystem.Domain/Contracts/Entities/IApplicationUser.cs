﻿using BlogSystem.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Contracts
{
    public interface IApplicationUser
    {
        string Name { get; set; }

        IEnumerable<IPost> Posts { get; }

        IEnumerable<IComment> Comments { get; set; }
    }
}
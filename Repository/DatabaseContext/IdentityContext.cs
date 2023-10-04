﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DatabaseContext
{
    public class IdentityContext:IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options):base(options)
        {
            
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FF.Models {
    public class FFIdentityDbContext : IdentityDbContext<IdentityUser> {
        public FFIdentityDbContext(DbContextOptions<FFIdentityDbContext> options) : base(options) { }
        
    }
}

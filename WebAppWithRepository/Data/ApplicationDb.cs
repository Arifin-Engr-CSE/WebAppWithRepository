using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppWithRepository.Models;

namespace WebAppWithRepository.Data
{
    public class ApplicationDb:DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb>options):base(options)
        {

        }
        public DbSet<Company> companies { get; set; }
    }
}

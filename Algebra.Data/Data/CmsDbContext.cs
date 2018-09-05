using Algebra.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algebra.Data
{
    public class CmsDbContext: DbContext
    {
        public CmsDbContext(DbContextOptions<CmsDbContext> options)
            : base(options)
        {
        }

        public DbSet<NewMembersFrom> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public IList<NewMembersFrom> GetForms()
        {
            return Forms.FromSql("[cms_algebratheclub].[dbo].[GetMembersData]").ToList();
        }
    }
}

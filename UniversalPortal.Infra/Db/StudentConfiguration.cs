using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversalPortal.Application.Entities;

namespace UniversalPortal.Infra.Db
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique().HasDatabaseName("IX_Student_Email");
            builder.HasIndex(x => x.Code).IsUnique().HasDatabaseName("IX_Student_Code");
        }
    }
}

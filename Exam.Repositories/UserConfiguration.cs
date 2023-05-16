using Exam.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Repositories;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(e => e.LastName)
            .IsRequired();
        builder.Property(e => e.PhoneNumber)
            .IsRequired();
        builder.Property(e => e.NationalCode)
            .IsRequired();
    }
}
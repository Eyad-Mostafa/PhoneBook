using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Entities;

namespace PhoneBook.Data.Config;

public class ContactsConfiguartion : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.PhoneNumber)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(15)
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder.Property(x => x.Category)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(15)
            .IsRequired();

        builder.ToTable("Contacts");

    }
}

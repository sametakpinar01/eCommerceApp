using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Data.Entities
{
    public class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(RoleId))]
        public RoleEntity Role { get; set; }
    }
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(nameof(UserEntity.Email))
                .IsRequired();
            builder.Property(nameof(UserEntity.FirstName))
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(nameof(UserEntity.LastName))
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(nameof(UserEntity.Password))
                .IsRequired();
            builder.Property(nameof(UserEntity.RoleId))
                .IsRequired();
            builder.Property(nameof(UserEntity.Enabled))
                .IsRequired()
                .HasDefaultValue(true);
            builder.Property(nameof(UserEntity.CreatedAt))
                .IsRequired();
            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}

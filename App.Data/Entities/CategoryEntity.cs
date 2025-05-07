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
    public class CategoryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
        [MinLength(3)]
        public string Color { get; set; }
        [MinLength(2)]
        public string IconCssClass { get; set; }
        public DateTime CreatedAt { get; set; }


    }
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.Property(nameof(CategoryEntity.Name))
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(nameof(CategoryEntity.Color))
                .IsRequired()
                .HasMaxLength(6);
            builder.Property(nameof(CategoryEntity.IconCssClass))
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(nameof(CategoryEntity.CreatedAt))
                .IsRequired();
                

        }
    }
}

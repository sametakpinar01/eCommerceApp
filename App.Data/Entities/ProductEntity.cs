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
    public class ProductEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Details { get; set; }
        public byte StockAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Enabled { get; set; }



        [ForeignKey(nameof(SellerId))]
        public UserEntity Seller { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity Category { get; set; }

    }
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(nameof(ProductEntity.SellerId))
                .IsRequired();
            builder.Property(nameof(ProductEntity.CategoryId))
                .IsRequired();
            builder.Property(nameof(ProductEntity.Name))
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(nameof(ProductEntity.Price))
                .IsRequired();
            builder.Property(nameof(ProductEntity.Details))               
                .HasMaxLength(1000);
            builder.Property(nameof(ProductEntity.StockAmount))
                .IsRequired();
            builder.Property(nameof(ProductEntity.CreatedAt))
                .IsRequired();
            builder.Property(nameof(ProductEntity.Enabled))
                .IsRequired()
                .HasDefaultValue(true);
            builder.HasOne(p => p.Seller)
                .WithMany()
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}

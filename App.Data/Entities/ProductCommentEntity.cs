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
    public class ProductCommentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        [MinLength(2)]
        public string Text { get; set; }
        [Range(1, 5)]
        public byte StarCount { get; set; }
        
        public bool IsConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductEntity Product { get; set; }
    }
    public class ProductCommentEntityConfiguration : IEntityTypeConfiguration<ProductCommentEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCommentEntity> builder)
        {
            builder.Property(nameof(ProductCommentEntity.ProductId))
                .IsRequired();
            builder.Property(nameof(ProductCommentEntity.UserId))
                .IsRequired();
            builder.Property(nameof(ProductCommentEntity.Text))
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(nameof(ProductCommentEntity.StarCount))
                .IsRequired();
            builder.Property(nameof(ProductCommentEntity.IsConfirmed))
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(nameof(ProductCommentEntity.CreatedAt))
                .IsRequired();
            builder.HasOne(pc => pc.User)
                .WithMany()
                .HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pc => pc.Product)
                 .WithMany()
                 .HasForeignKey(pc => pc.ProductId)
                 .OnDelete(DeleteBehavior.NoAction);



        }
    }

}

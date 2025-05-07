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
    public class OrderItemEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Range(1, byte.MaxValue)]
        public byte Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }


        [ForeignKey(nameof(OrderId))]
        public OrderEntity Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public ProductEntity Product { get; set; }



    }
    public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.Property(nameof(OrderItemEntity.OrderId))
                .IsRequired();
            builder.Property(nameof(OrderItemEntity.ProductId))
                .IsRequired();
            builder.Property(nameof(OrderItemEntity.Quantity))
                .IsRequired();
            builder.Property(nameof(OrderItemEntity.UnitPrice))
                .IsRequired();
            builder.Property(nameof(OrderItemEntity.CreatedAt))
                .IsRequired();
            builder.HasOne(oi => oi.Order)
               .WithMany()
               .HasForeignKey(oi => oi.OrderId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(oi => oi.Product)
               .WithMany()
               .HasForeignKey(oi => oi.ProductId)
               .OnDelete(DeleteBehavior.NoAction);


        }
    }
}

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
    public class OrderEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [MinLength(2)]
        public string OrderCode { get; set; }
        [MinLength(2)]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }

    }
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(nameof(OrderEntity.UserId))
                .IsRequired();
            builder.Property(nameof(OrderEntity.OrderCode))
                .IsRequired();               
            builder.Property(nameof(OrderEntity.Address))
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(nameof(OrderEntity.CreatedAt))
                .IsRequired();
            builder.HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);



        }
    }
}

// 파일 위치: Infrastructure/Data/EntityTypeConfigurations/TodoConfiguration.cs

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            // PK 및 자동 생성 설정
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd()
                   .HasDefaultValueSql("NEWID()");

            // Title 제약
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            // IsCompleted 필수 설정
            builder.Property(t => t.IsCompleted)
                   .IsRequired();

            // UserId 인덱스 (선택)
            builder.HasIndex(t => t.UserId);

            // 관계 설정
            builder.HasOne(t => t.User)
                   .WithMany(u => u.Todos)
                   .HasForeignKey(t => t.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
// 파일 위치: Infrastructure/Data/EntityTypeConfigurations/CharacterConfiguration.cs

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            // PK 및 자동 생성 설정
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            // 문자열 속성 제약
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.PersonaPrompt)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(c => c.YinYangRate)
                   .IsRequired()
                   .HasMaxLength(10);

            // UserId 조회 성능을 위한 인덱스
            builder.HasIndex(c => c.UserId);

            // User ↔ Characters 관계 설정
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Characters)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
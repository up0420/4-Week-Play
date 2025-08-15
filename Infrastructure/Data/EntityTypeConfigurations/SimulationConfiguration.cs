using Core.Entities;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations
{
    public class SimulationConfiguration : IEntityTypeConfiguration<Simulation>
    {
        public void Configure(EntityTypeBuilder<Simulation> b)
        {
            b.ToTable("Simulations");

            b.HasKey(x => x.Id);

            // 기존 Scenario/Result/Timestamp 제거 → 현재 모델에 맞춤
            b.Property(x => x.Type)
                .HasConversion<int>()     // enum 저장
                .IsRequired();

            b.Property(x => x.OptionsJson)
                .HasColumnType("longtext"); // MySQL 계열이라면 longtext/mediumtext/텍스트 선택

            b.Property(x => x.StartedAt)
                .HasColumnType("datetime");

            b.Property(x => x.UserId).IsRequired();
            b.Property(x => x.CharacterId).IsRequired();

            b.HasIndex(x => x.UserId);
            b.HasIndex(x => x.CharacterId);

            // 네비게이션 없이 FK로 관계
            b.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne<Character>()
                .WithMany()
                .HasForeignKey(x => x.CharacterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

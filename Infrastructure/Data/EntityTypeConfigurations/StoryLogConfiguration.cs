using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations
{
    public class StoryLogConfiguration : IEntityTypeConfiguration<StoryLog>
    {
        public void Configure(EntityTypeBuilder<StoryLog> b)
        {
            b.ToTable("StoryLogs");

            b.HasKey(x => x.Id);

            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            b.Property(x => x.Content)
                .IsRequired();

            // 기존 Timestamp → CreatedAt으로 매핑
            b.Property(x => x.CreatedAt)
                .HasColumnType("datetime");

            b.Property(x => x.UserId)
                .IsRequired();

            b.HasIndex(x => x.UserId);

            // 네비게이션 속성 없이 FK 기반으로 관계 설정
            b.HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

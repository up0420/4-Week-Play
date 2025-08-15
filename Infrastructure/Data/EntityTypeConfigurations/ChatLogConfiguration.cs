using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntityTypeConfigurations
{
    public class ChatLogConfiguration : IEntityTypeConfiguration<ChatLog>
    {
        public void Configure(EntityTypeBuilder<ChatLog> b)
        {
            b.ToTable("ChatLogs");

            b.HasKey(x => x.Id);

            // 기존 Content → UserMessage/CharacterResponse로 분리
            b.Property(x => x.UserMessage)
                .IsRequired();

            b.Property(x => x.CharacterResponse)
                .IsRequired(false);

            // 기존 Timestamp → CreatedAt으로 매핑
            b.Property(x => x.CreatedAt)
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
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using System;

namespace Api.Dtos
{
    public class FortuneRequestDto
    {
        public Guid? UserId { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

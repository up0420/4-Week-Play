namespace Core.Enums
{
    /// <summary>
    /// 실시간 알림/이벤트 유형
    /// </summary>
    public enum NotificationType
    {
        System           = 0, // 시스템/공지
        CharacterMessage = 1, // 캐릭터(조상/부모/미래/본인) 알림
        Todo             = 2, // 할일/Todo 알림
        Simulation       = 3, // 시뮬레이션 진행/결과
        Fortune          = 4, // 오늘의 운세/사주 관련
        Admin            = 5, // 관리자 수동 알림
        // 필요시 확장
    }
}

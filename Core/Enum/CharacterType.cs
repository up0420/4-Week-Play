namespace Core.Enums
{
    /// <summary>
    /// 4주 캐릭터 유형 (사주 각 주柱)
    /// </summary>
    public enum CharacterType
    {
        YearAncestor = 0,   // 년주: 조상님/집안/뿌리 (ex. 금)
        MonthParent  = 1,   // 월주: 부모님/외적 배경 (ex. 토)
        DaySelf      = 2,   // 일주: 현재의 나 (ex. 수)
        TimeFuture   = 3    // 시주: 미래의 나 (ex. 화)
    }
}

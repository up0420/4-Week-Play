namespace Core.Enums
{
    /// <summary>
    /// 시뮬레이션 종류(경영/성장/이벤트 등)
    /// </summary>
    public enum SimulationType
    {
        Unknown      = 0, // 미지정/기타
        LifeTycoon   = 1, // 인생 경영 시뮬레이션
        Career       = 2, // 직업/진로 시뮬
        Investment   = 3, // 재테크/투자 시뮬
        FamilyEvent  = 4, // 가족/관계 이벤트
        // 필요시 추가
    }
}

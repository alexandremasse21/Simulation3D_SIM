public readonly struct LevelResult
{
    public int LevelIndex { get; }
    public float Duration { get; }
    public int Penalty { get; }

    public LevelResult(int levelIndex, float duration, int penalty)
    {
        LevelIndex = levelIndex; 
        Duration = duration;
        Penalty = penalty;
    }
}

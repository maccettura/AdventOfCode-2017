namespace AdventOfCode
{
    public interface ISolver
    {
        int Day { get; }
        string Title { get; }
        void SolvePart1();
        void SolvePart2();
    }
}
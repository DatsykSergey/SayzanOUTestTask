namespace Input
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsPressed { get; }
    }
}
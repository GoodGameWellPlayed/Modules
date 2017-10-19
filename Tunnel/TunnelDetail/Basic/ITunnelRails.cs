public interface ITunnelRails
{
    int Count { get; }
    TunnelVector2 GetRail(int railId);
}

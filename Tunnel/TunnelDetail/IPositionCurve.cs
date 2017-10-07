public interface IPositionCurve
{
    float Length { get; }
    PositionRotation GetPositionRotation(float distance);
}


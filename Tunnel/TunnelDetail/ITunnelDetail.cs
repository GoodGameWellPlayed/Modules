public class TunnelDetail
{
    float Length { get; }
    float LengthBefore { get; }
    ITunnelDetail DetailBefore { get; }
    ITunnelDetail DetailAfter { get; }

    bool Move(TunnelVector3 speed, TunnelTransform transform)
    {
        TunnelVector3 newLocalPosition = transform.LocalPosition + speed;

        if (newLocalPosition.Depth < 0)
        {
            if (PreviousDetail != null)
            {
                PreviousDetail.PutComponentInside(positionDescriptor, new TunnelVector3(PreviousDetail.Depth,
                    positionDescriptor.PositionVectorLocal.Angle, positionDescriptor.PositionVectorLocal.Height));

                TunnelVector3 newSpeed = new TunnelVector3(newLocalPosition.Depth,
                    0, 0);

                PreviousDetail.MoveComponent(positionDescriptor, newSpeed, objectTransform);
            }
            else
            {
                PutComponentInside(positionDescriptor,
                    new TunnelVector3(0, newLocalPosition.Angle, newLocalPosition.Height), objectTransform);
            }
        }
        else if (newLocalPosition.Depth > Depth)
        {
            if (NextDetail != null)
            {
                NextDetail.PutComponentInside(positionDescriptor, new TunnelVector3(0,
                    positionDescriptor.PositionVectorLocal.Angle, positionDescriptor.PositionVectorLocal.Height));

                TunnelVector3 newSpeed = new TunnelVector3(
                    newLocalPosition.Depth - Depth, 0, 0);

                NextDetail.MoveComponent(positionDescriptor, newSpeed, objectTransform);
            }
            else
            {
                PutComponentInside(positionDescriptor,
                    new TunnelVector3(Depth, newLocalPosition.Angle, newLocalPosition.Height), objectTransform);
            }
        }
        else
        {
            PutComponentInside(positionDescriptor, newLocalPosition, objectTransform);
        }
    }
}

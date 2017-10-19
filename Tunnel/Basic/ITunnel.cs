using UnityEngine;

public interface ITunnel
{
    void PutInTunnel(Transform transform, TunnelVector3 globalPosition);
    void PutInCenter(Transform transform, float depth);
    float Length { get; }
}


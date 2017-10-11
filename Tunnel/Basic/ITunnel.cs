using UnityEngine;

public interface ITunnel
{
    void PutInTunnel(Transform transform, TunnelVector3 globalPosition);
    float Length { get; }
}


using UnityEngine;

[CreateAssetMenu(fileName = "TileSurfaceInfo", menuName = "Tiles/TileSurfaceInfo", order = 1)]
public class TileSurfaceInfo : ScriptableObject
{
    [Range(0, 2f)]
    [SerializeField] private float _speedMultiplier;
    [Range(0, 2f)]
    [SerializeField] private float _damageDealt;

    public float SpeedMultiplier { get { return _speedMultiplier; } }
    public float DamageDealt { get { return _damageDealt; } }
}

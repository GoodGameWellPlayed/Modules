public interface ISpawnableObject
{
    IDespawner Despawner { get; set; }
    void OnAfterSpawn();
    void OnBeforeDespawn();
}

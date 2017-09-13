public interface IPoolableObject
{
    void Destroy();
    void OnAfterSpawn();
    void OnBeforeDespawn();
    void OnSpawnerUpdate();
    void Despawn();
    void SetActive(bool isActive);
}
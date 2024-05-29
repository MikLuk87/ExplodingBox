using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Box : MonoBehaviour
{
    [SerializeField, Range(1, 100)] private float _spawnChance = 100f;

    public float GetSpawnChance()
    {
        return _spawnChance;
    }

    public void SetSpawnChance(float spawnChance)
    {
        _spawnChance = spawnChance;
    }

    private void OnMouseDown()
    {
        Spawner spawner = new Spawner();

        spawner.Split(GetComponent<Box>());
        Destroy(gameObject);
    }
}
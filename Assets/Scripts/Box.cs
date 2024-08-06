using UnityEngine;

[RequireComponent(typeof(Spawner))]

public class Box : MonoBehaviour
{
    [SerializeField, Range(1, 200)] private float _spawnChance = 200f;
    [SerializeField] private float _reduction = 2f;
  
    private void OnMouseDown()
    {
        Spawner spawner = GetComponent<Spawner>();

        spawner.Spawn(this);
        Destroy(gameObject);
    }

    public float SpawnChance()
    {
        return _spawnChance;
    }

    private void Start()
    {
        _spawnChance /= _reduction;
        transform.localScale /= _reduction;
    }
}
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Box : MonoBehaviour
{
    [SerializeField, Range(1, 200)] private float _spawnChance = 200f;
    [SerializeField] private float _reduction = 2f; 

    private void OnMouseDown()
    {
        Spawner spawner = new Spawner();

        spawner.Spawn(this);
        Destroy(gameObject);
    }

    public float SpawnChance()
    {
        return _spawnChance;
    }

    private void Start()
    {
        Exploder exploder = new Exploder();
        
        Initialize();
        exploder.AddToExplosionList(GetComponent<Rigidbody>());
    }

    private void Initialize()
    {
        _spawnChance /= _reduction;
        transform.localScale /= _reduction;
    }
}
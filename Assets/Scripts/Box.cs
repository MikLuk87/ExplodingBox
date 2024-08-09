using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Spawner))]

public class Box : MonoBehaviour
{
    [SerializeField, Range(1, 200)] private float _spawnChance = 200;
    [SerializeField] private float _reduction = 2f;

    public float SpawnChance { get { return _spawnChance; } private set { } }

    private void OnMouseDown()
    {
        Spawner spawner = GetComponent<Spawner>();

        spawner.Spawn(this);
        Destroy(gameObject);
    }

    private void Start()
    {
        _spawnChance /= _reduction;
        transform.localScale /= _reduction;
    }

    public Rigidbody GetRigidbody()
    {
        if (GetComponent<Rigidbody>() == null)
        {
            this.AddComponent<Rigidbody>();
        }

        return GetComponent<Rigidbody>();
    }
}
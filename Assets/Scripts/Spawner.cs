using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Box))]
[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(Rigidbody))]

public class Spawner : MonoBehaviour
{

    [SerializeField] private float _reduction = 2f;

    private Box _box;
    private Exploder _explosives;

    private int _minQuantity = 2;
    private int _maxQuantity = 7;
    private int _maxRandom = 100;

    private void OnMouseDown()
    {
        GameObject newBox;
        List<Rigidbody> explodebleObjects = new List<Rigidbody>();

        _box = GetComponent<Box>();
        _explosives = GetComponent<Exploder>();

        if (Random.Range(0, _maxRandom) <= _box.SpawnChance)
        {
            transform.localScale /= _reduction;
            _box.SpawnChance /= _reduction;

            for (int i = 0; i < Random.Range(_minQuantity, _maxQuantity); i++)
            {
                newBox = Instantiate(gameObject, transform.position, transform.rotation);
                explodebleObjects.Add(newBox.GetComponent<Rigidbody>());
            }

            _explosives.Explode(explodebleObjects);
        }

        Destroy(gameObject);
    }
}
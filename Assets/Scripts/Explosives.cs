using System.Collections.Generic;
using UnityEngine;

public class Explosives : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _reduction = 2f;
    [SerializeField, Range(1, 100)] private float _spawnChance = 100f;

    private static System.Random _random = new System.Random();

    private int _minQuantity = 2;
    private int _maxQuantity = 7;
    private int _maxRandom = 100;

    private bool _willExplode = false;


    private void OnMouseUpAsButton()
    {
        ChanceToSplit();
        Destroy(gameObject);

        if (_willExplode)
        {
            Explode();
        }
    }

    private void Split()
    {
        gameObject.transform.localScale /= _reduction;
        _spawnChance /= _reduction;

        for (int i = 0; i < GetRandomQuantity(); i++)
        {
            ChangeColor();
            Instantiate(gameObject, transform.position, transform.rotation);
        }
    }

    private void ChangeColor()
    {
        gameObject.GetComponent<Renderer>().material.color = GetRandomColor();
    }

    private void ChanceToSplit()
    {
        int i = Random.Range(0, _maxRandom);

        if (i <= _spawnChance)
        {
            Split();
            _willExplode = true;
        }
    }

    private Color GetRandomColor()
    {
        var colors = new[] {
             Color.blue,
             Color.red,
             Color.green,
             Color.yellow};

        return colors[_random.Next(0, colors.Length)];
    }

    private int GetRandomQuantity()
    {
        return _random.Next(_minQuantity, _maxQuantity);
    }

    private void Explode()
    {
        foreach (Rigidbody explodebleObject in GetExplodedleObjects())
        {
            explodebleObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        _willExplode = false;
    }

    private List<Rigidbody> GetExplodedleObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> box = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                box.Add(hit.attachedRigidbody);
            }
        }

        return box;
    }
}

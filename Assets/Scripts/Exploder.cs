using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    private List<Rigidbody> _explosionBoxes = new List<Rigidbody>();

    public void Explode()
    {
        foreach (Rigidbody explosionBox in _explosionBoxes)
        {
            explosionBox.AddExplosionForce(_explosionForce, explosionBox.transform.position, _explosionRadius);
        }

        _explosionBoxes.Clear();
    }

    public List<Rigidbody> GetExplosionBoxes()
    {
        return _explosionBoxes;
    }

    public void SetExplosionBoxes(Rigidbody rigidbody)
    {
        _explosionBoxes.Add(rigidbody);
    }
}
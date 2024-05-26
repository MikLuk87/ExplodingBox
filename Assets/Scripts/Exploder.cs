using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(List<Rigidbody> ExplodebleObjects)
    {
        foreach (Rigidbody explodebleObject in ExplodebleObjects)
        {
            explodebleObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        ExplodebleObjects.Clear();
    }
}
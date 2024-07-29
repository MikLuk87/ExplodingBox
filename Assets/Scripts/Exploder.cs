using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder
{
    private float _explosionForce = 300;
    private List<Rigidbody> _explosionBoxes = new List<Rigidbody>();

    public void Explode()
    {
        DelayedExplosion();
        Debug.Log("Explode");
        _explosionBoxes.Clear();
    }

    public void AddToExplosionList(Rigidbody rigidbody)
    {
        _explosionBoxes.Add(rigidbody);
    }

    private IEnumerator DelayedExplosion()
    {
        yield return new WaitForSeconds(2f);

        foreach (Rigidbody explosionBox in _explosionBoxes)
        {
            Debug.Log("Force");
            explosionBox.AddForce(Random.Range(0, _explosionForce), Random.Range(0, _explosionForce), Random.Range(0, _explosionForce));
        }
    }
}
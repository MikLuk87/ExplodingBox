using UnityEngine;

public class Spawner : MonoBehaviour
{
    private readonly int _maxRandom = 100;
    private int _minQuantity = 2;
    private int _maxQuantity = 7;
    private int _explodeForce = 600;

    public void Spawn(Box box)
    {
        if (Random.Range(0, _maxRandom) <= box.SpawnChance)
        {
            Rigidbody parentRb = box.GetRigidbody();
            Rigidbody childrenRb;

            int randomQuantity = Random.Range(_minQuantity, _maxQuantity);

            for (int i = 0; i < randomQuantity; i++)
            {
                childrenRb = Instantiate(parentRb, box.transform.position, box.transform.rotation);
                childrenRb.AddForce(Random.Range(_explodeForce * -1, _explodeForce), Random.Range(0, _explodeForce), Random.Range(_explodeForce * -1, _explodeForce));
            }
        }
    }
}
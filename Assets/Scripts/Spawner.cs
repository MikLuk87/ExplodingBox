using UnityEngine;

public class Spawner : MonoBehaviour
{
    private readonly int _maxRandom = 100;
    private int _minQuantity = 2;
    private int _maxQuantity = 7;
    private int _explodeForce = 600;

    public void Spawn(Box box)
    {
        if (Random.Range(0, _maxRandom) <= box.SpawnChance())
        {
            GameObject explodebleBox;

            for (int i = 0; i < Random.Range(_minQuantity, _maxQuantity); i++)
            {
                explodebleBox = Instantiate(box.gameObject, box.transform.position, box.transform.rotation);
                explodebleBox.GetComponent<Rigidbody>().AddForce(Random.Range(_explodeForce * -1, _explodeForce), Random.Range(0, _explodeForce), Random.Range(_explodeForce * -1, _explodeForce));
            }
        }
    }
}